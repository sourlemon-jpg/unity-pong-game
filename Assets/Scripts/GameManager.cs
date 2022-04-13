using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private int playerScore;
    public Ball ballScript;
    private int aiScore;
    // public int currentRally;
    // public TMP_Text currentRallyText;

    public AudioSource compWin;
    public AudioSource playerWin;
    public GameObject secondBall;
    public GameObject playButton;
    private int a = 0;
    public TMP_Text playerScoreText;
    public TMP_Text aiScoreText;

    public Transform ball;
    private Rigidbody2D ballRb;

    private void Awake()
    {
        Pause();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        aiScore = 0;
        ballRb = ball.GetComponent<Rigidbody2D>();
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }
    
    public void ToPlay()
    {
        playButton.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void SetScore(bool isPlayer)
    {
        if (isPlayer)
        {
            playerScore++;
            playerWin.Play();
            if (ballScript.currentRally >= 15)
            {
                Destroy(GameObject.Find("Ball(Clone)"));
            }
            
            // currentRally++;
            playerScoreText.text = playerScore.ToString();
            // currentRallyText.text = currentRally.ToString();
        }
        else
        {
            aiScore++;
            compWin.Play();
            if (ballScript.currentRally >= 15)
            {
                Destroy(GameObject.Find("Ball(Clone)"));
            }
            aiScoreText.text = aiScore.ToString();
        }

        ball.position = Vector2.zero;
        ballRb.velocity = Vector2.zero;

        Invoke("RestartBall", 1.5f); 
    }

    private void Update()
    {
        if (a == 0)
        {
            if (ballScript.currentRally == 15)
            {
                Instantiate(secondBall, transform.position, transform.rotation);
                a = 1;
            }
        }
        
    }
    void RestartBall()
        {
            ballRb.velocity = new Vector2(Random.Range(0, 2) == 0 ? 0.7f : -0.7f, Random.Range(-1.0f, 1.0f)) *
                              ball.GetComponent<Ball>().speed;
            Destroy(GameObject.Find("Ball(Clone)"));
            ballScript.currentRally = 0;
            ballScript.currentRallyText.text = ballScript.currentRally.ToString();
            a = 0;
        }
    }


