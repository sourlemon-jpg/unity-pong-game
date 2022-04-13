using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource beep;
    public AudioSource wallBeep;
    
    private Rigidbody2D rb;
    public int currentRally;
    public TMP_Text currentRallyText;
    public float speed = 7;
    void Start()
    {
        currentRally = 0 ;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, Random.Range(-1f, 1f))*speed;

    }
    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Paddle"))
        {
            beep.Play();
            currentRally++;
            currentRallyText.text = currentRally.ToString();

            rb.velocity = collision.GetContact(0).normal.magnitude * rb.velocity * 1.002f;
        }

        if (collision.transform.CompareTag("finisher"))
        {
            currentRally = 0;
            currentRallyText.text = currentRally.ToString();
        }
        else
        {
            wallBeep.Play();
            rb.velocity = rb.velocity * 1.001f;
            
        }
        
    }

}