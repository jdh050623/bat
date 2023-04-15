using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartManager : MonoBehaviour
{
    public int healRequiredScore;
    public static int heartCount;
    private int healNum;

    public Image[] heart;
    public GameObject reGame;

    void Start()
    {
        heartCount = 3;
        healNum = healRequiredScore;
    }

    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 0;
            Debug.Log("a누름");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1;
            Debug.Log("D누름");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            
            Debug.Log("S누름");
        }*/

        if (heartCount >= 3)
        {
            heart[2].color = new Color32(255, 255, 255, 255);
        }
        if (heartCount == 2)
        {
            heart[1].color = new Color32(255, 255, 255, 255);
            heart[2].color = new Color32(55, 55, 55, 255);
        }
        if (heartCount == 1)
        {
            heart[0].color = new Color32(255, 255, 255, 255);
            heart[1].color = new Color32(55, 55, 55, 255);
        }
        if (heartCount <= 0)
        {
            heart[0].color = new Color32(55, 55, 55, 255);
            reGame.SetActive(true);
            ButtonManager.dontClick = true;
            Time.timeScale = 0;
        }

        if(HitZone.currentScore >= healNum && heartCount <= 2)
        {
            healNum = healNum + healRequiredScore;
            heartCount++;
            Debug.Log("치유합니다");
        }
    }
}
