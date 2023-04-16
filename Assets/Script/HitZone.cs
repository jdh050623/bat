using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitZone : MonoBehaviour
{
    public static int area; //공이 HitZone의 색깔 구역에 들어갈때마다 1씩 올라가고 색깔구역을 지나칠때마다 1씩 내려감 빨주노 순서로 3,2,1
    public static string ballColor;
    public static bool hit;
    private int score;
    public static int topScore;
    public static int currentScore;
    public static bool recordBreaking;//최고기록 갱신중

    public GameObject scoreText;
    public AudioSource[] ballHit; 
    void Start()
    {
        recordBreaking = false;
        currentScore = 0;
        if (!PlayerPrefs.HasKey("TOP_Score"))
        {
            PlayerPrefs.SetInt("TOP_Score", 0); 
        }
        else
        {
            topScore = PlayerPrefs.GetInt("TOP_Score");
        }
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            ballColor = "redBall";
        }

        if (collision.gameObject.tag == "Blue")
        {
            ballColor = "blueBall";
        }
    }

    public void HitArea()
    {
        if (!hit)
        {
            if (area == 3)
            {
                score = 5;
                ballHit[0].Play();
                HitAreaScore();
            }

            if (area == 2)
            {
                score = 3;

                ballHit[1].Play();
                HitAreaScore();
            }

            if (area == 1)
            {
                ballHit[2].Play();
                score = 1;
                HitAreaScore();
            }
        }
    }

    public void HitAreaScore()
    {
        Ball.ballHit = true;
        hit = true;
        GameObject text = Instantiate(scoreText);
        text.GetComponent<PlusScoreText>().score = "+"+score.ToString();

        currentScore = currentScore + score;
        if (topScore <= currentScore)
        {
            recordBreaking = true;
            topScore = currentScore;
            PlayerPrefs.SetInt("TOP_Score", topScore);
        }
    }
}
