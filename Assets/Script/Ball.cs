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

    void Start()
    {
        m_StartPosition = transform.position;
        HitZone.area = 0;
        HitZone.hit = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Ãâ¹ß
        {
            m_IsStart = true;
        }

        if (m_IsStart)
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

            if (nextPosition == m_Target.position) //µµÂøÇßÀ½
            {
                Arrival = true;
                m_IsStart = false;
            }

            if (transform.localScale.x < 1f)
            {
                transform.localScale = new Vector2(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f);
            }
        }

        if (Arrival)
        {
            Debug.Log("µµÂø");
            transform.position = new Vector2(0, transform.position.y - 0.08f);
            StartCoroutine(Destroy());
        }

        //
    }

    Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("»èÁ¦");
        HitZone.area = 0;
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "YellowZone")
        {
            HitZone.area++;
            Debug.Log(HitZone.area);
        }

        if (collision.tag == "OrangeZone")
        {
            HitZone.area++;
            Debug.Log(HitZone.area);
        }

        if (collision.tag == "RedZone")
        {
            HitZone.area++;
            Debug.Log(HitZone.area);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "YellowZone")
        {
            HitZone.area--;
            Debug.Log(HitZone.area);
        }

        if (collision.tag == "OrangeZone")
        {
            HitZone.area--;
            Debug.Log(HitZone.area);
        }

        if (collision.tag == "RedZone")
        {
            HitZone.area--;
            Debug.Log(HitZone.area);
        } 
    }
}
