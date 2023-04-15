using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static bool dontClick;

    void Awake()
    {
        dontClick = false;
        Time.timeScale = 1;
    }

    public void Update()
    {
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void ReBt()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
