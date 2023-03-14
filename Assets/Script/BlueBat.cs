using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBat : MonoBehaviour
{
    private Vector3 point;
    private float rotationZ;
    private bool swing;
    public GameObject swingEffect;
    public GameObject scr_HitZone;
    // Start is called before the first frame update
    void Start()
    {
        rotationZ = 180f;
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0));
            if (point.x <= 0 && swing == false)
            {
                swingEffect.SetActive(true);
                StartCoroutine(Co());
                swing = true;
                scr_HitZone.GetComponent<HitZone>().HitArea();
                if (HitZone.ballColor == "blueBall")
                {
                    Debug.Log("ºí·ç´Ù");
                }
                

                
            }
        }
        if(swing == true)
        {
            if (rotationZ < 330)
            {
                rotationZ += 10;
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationZ));
        }
        
        if(swing == false)
        {
            if (rotationZ > 180)
            {
                rotationZ -= 5;
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationZ));
        }
    }

    IEnumerator Co()
    {
        yield return new WaitForSeconds(.3f);
        swingEffect.SetActive(false);
        yield return new WaitForSeconds(.7f);
        swing = false;
    }
}
