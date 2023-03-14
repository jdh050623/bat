using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    float rotationZ;
    bool swing;
    public GameObject swingEffect;
    // Start is called before the first frame update
    void Start()
    {
        rotationZ = 180f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && swing == false)
        {
            swingEffect.SetActive(true);
            StartCoroutine(Co());
            swing = true;
            
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
        Debug.Log(".5c");
        swingEffect.SetActive(false);
        yield return new WaitForSeconds(.7f);
        Debug.Log("2c");
        swing = false;

        
    }
}
