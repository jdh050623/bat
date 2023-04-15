using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlusScoreText : MonoBehaviour
{
    public float speed;
    public float alpahSpeed;
    private float destroyTime;
    public static float alpah;
    public static TextMeshPro text;
    public string score;
    
    void Start()
    {
        alpah = 255f;
        destroyTime = speed + 0.1f;
        text = GetComponent<TextMeshPro>();
        text = GetComponentInChildren<TextMeshPro>();
        text.text = score.ToString();
        Invoke("DestroyText",destroyTime);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        if (alpah > 0)
        {
            alpah = alpah - (alpahSpeed * Time.deltaTime);
        }

        if (score == "+5")
        {
            text.color = new Color32(255, 0, 0, (byte)alpah);
        }
        if (score == "+3")
        {
            text.color = new Color32(255, 127, 0, (byte)alpah);
        }
        if (score == "+1")
        {
            text.color = new Color32(255, 212, 0, (byte)alpah);
        }
    }

    private void DestroyText()
    {
        Destroy(gameObject);
    }
}
