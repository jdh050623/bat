using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public static int area; //공이 HitZone의 색깔 구역에 들어갈때마다 1씩 올라가고 색깔구역을 지나칠때마다 1씩 내려감 빨주노 순서로 3,2,1
    public static string areaZone;
    public static string ballColor;
    public static bool hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Red")
        {
            ballColor = "redBall";
        }

        if (collision.tag == "Blue")
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
                Debug.Log("빨강");
                hit = true;
                areaZone = "RZone";
            }

            if (area == 2)
            {
                Debug.Log("주황");
                hit = true;
                areaZone = "OZone";
            }

            if (area == 1)
            {
                Debug.Log("노랑");
                hit = true;
                areaZone = "YZone";
            }
        }
        
    }

}
