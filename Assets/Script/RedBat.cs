using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBat : MonoBehaviour
{
    private Vector3 point;
    private float rotationZ = 180;
    private bool swing;
    public GameObject swingEffect;
    public GameObject scr_HitZone;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rotationZ >= 180 && !ButtonManager.dontClick)
        {
            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,0, 0));
            if (point.x > 0 && swing == false)
            {
                swingEffect.SetActive(true);
                StartCoroutine(SwingDelay());
                swing = true;
                if (HitZone.ballColor == "redBall")
                {
                    scr_HitZone.GetComponent<HitZone>().HitArea();
                }
            }
        }
        if (swing == true)
        {
            if (rotationZ > 30)
            {
                rotationZ -= 2000 * Time.deltaTime;
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationZ));
        }
        
        if(swing == false)
        {
            if (rotationZ < 180)
            {
                rotationZ += 1000 * Time.deltaTime;
            }
            else
            {
                rotationZ = 180;
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationZ));
        }
    }

    IEnumerator SwingDelay()
    {
        yield return new WaitForSeconds(.3f);
        swingEffect.SetActive(false);
        HitZone.hit = false;

        yield return new WaitForSeconds(.7f);
        swing = false;  
    }
}
