using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitZone : MonoBehaviour
{
    public static int area; //���� HitZone�� ���� ������ �������� 1�� �ö󰡰� ���򱸿��� ����ĥ������ 1�� ������ ���ֳ� ������ 3,2,1
    public static string ballColor;
    public static bool hit;
    private int score;
    public static int topScore;
    public static int currentScore;
    public static bool recordBreaking;//�ְ��� ������

    public GameObject scoreText;
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
                HitAreaScore();
            }

            if (area == 2)
            {
                score = 3;
                HitAreaScore();
            }

            if (area == 1)
            {
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
