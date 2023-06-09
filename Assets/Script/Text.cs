using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI t_topScore;
    public TextMeshProUGUI t_currentScore;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.SetInt("TOP_Score", 0);
        }

        t_currentScore.text = HitZone.currentScore.ToString();
        if(HitZone.recordBreaking == true)
        {
            t_topScore.text = "!TOP " + HitZone.topScore.ToString()+"!";
        }
        else
        {
            t_topScore.text = "TOP " + HitZone.topScore.ToString();
        }
    }
}
