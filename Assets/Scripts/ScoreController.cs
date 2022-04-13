using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
        public GameManager gm;
        public bool isPlayerSide;

        private void OnCollisionEnter2D(Collision2D col)
        {
            gm.SetScore(!isPlayerSide);
        }
    }
