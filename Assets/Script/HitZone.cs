using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    public static int area; //���� HitZone�� ���� ������ �������� 1�� �ö󰡰� ���򱸿��� ����ĥ������ 1�� ������ ���ֳ� ������ 3,2,1
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
                Debug.Log("����");
                hit = true;
                areaZone = "RZone";
            }

            if (area == 2)
            {
                Debug.Log("��Ȳ");
                hit = true;
                areaZone = "OZone";
            }

            if (area == 1)
            {
                Debug.Log("���");
                hit = true;
                areaZone = "YZone";
            }
        }
        
    }

}
