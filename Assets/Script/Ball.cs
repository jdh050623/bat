using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform m_Target;
    public float m_Speed = 10;
    public float m_HeightArc = 1;
    private Vector3 m_StartPosition;
    private bool m_IsStart;
    private bool Arrival;

    public static bool ballHit; 
    
    void Start()
    {
        m_StartPosition = transform.position;
        HitZone.area = 0;
        m_IsStart = true;
        ballHit = false;
    }

    void Update()
    {
        if (m_IsStart) // 시작할때 공이 포물선으로 날아감
        {
            float x0 = m_StartPosition.x;
            float x1 = m_Target.position.x;
            float distance = x1 - x0;
            float nextX = Mathf.MoveTowards(transform.position.x, x1, m_Speed * Time.deltaTime);
            float baseY = Mathf.Lerp(m_StartPosition.y, m_Target.position.y, (nextX - x0) / distance);
            float arc = m_HeightArc * (nextX - x0) * (nextX - x1) / (-0.25f * distance * distance);
            Vector3 nextPosition = new Vector3(nextX, baseY + arc, transform.position.z);

            transform.rotation = LookAt2D(nextPosition - transform.position);
            transform.position = nextPosition;

            if (nextPosition == m_Target.position) //빨간구역 도착함
            {
                Arrival = true;
                m_IsStart = false;
            }

            if (transform.localScale.x < 1f)
            {
                transform.localScale = new Vector2(transform.localScale.x + 3f * Time.deltaTime, transform.localScale.y + 3f * Time.deltaTime);
            }
        }

        if (Arrival) //빨강구역 지남
        {
            if (!ballHit)
            {
                transform.position = new Vector2(0, transform.position.y - 20f * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(0, transform.position.y + 20f * Time.deltaTime);
            }
            StartCoroutine(Destroy());
        }
    }

    Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        BallCreateManager.ballExistence = false;
        if (!ballHit)
        {
            HeartManager.heartCount--;
            Debug.Log("아잇");
        }
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "YellowZone")
        {
            HitZone.area++;
        }

        if (collision.tag == "OrangeZone")
        {
            HitZone.area++;
        }

        if (collision.tag == "RedZone")
        {
            HitZone.area++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "YellowZone")
        {
            HitZone.area--;
        }

        if (collision.tag == "OrangeZone")
        {
            HitZone.area--;
        }

        if (collision.tag == "RedZone")
        {
            HitZone.area--;
        } 
    }
}
