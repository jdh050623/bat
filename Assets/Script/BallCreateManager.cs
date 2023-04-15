using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreateManager : MonoBehaviour
{
    public GameObject[] ballColor;
    public Transform[] ballSpawnPoint;
    public static bool ballExistence;

    private void Awake()
    {
        ballExistence = false;
    }
    void Update()
    {
        if (!ballExistence)
        {
            ballExistence = true;
            StartCoroutine(BallSpawn());
        }
    }

    IEnumerator BallSpawn()
    {
        int ranBallspawn = Random.Range(0, 2);
        int ranBallColor = Random.Range(0, 2);
        yield return new WaitForSeconds(1.5f);
        Instantiate(ballColor[ranBallColor], ballSpawnPoint[ranBallspawn].position, ballSpawnPoint[ranBallspawn].rotation);
    }
}
