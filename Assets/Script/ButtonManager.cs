using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static bool dontClick;
    public AudioSource s_button;
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
        s_button.Play();
        Time.timeScale = 1;
        StartCoroutine(SoundEndWait());
    }

    IEnumerator SoundEndWait()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
