using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowConfetti : MonoBehaviour
{
    public GameObject ConfettiPrefab;

    [Space]
    public float spawnVerticalCoordinate = 5f; // Vertical coordinate of where the confetties will spawn
    public float destroyVerticalCoordinate = -5f; // Vertical coordinate of where the confetties will destroy

    [Space]
    public float spawnAreaSize = 5f; //  Width of horizontal area where confetties will spawn
    public float minSpeed = 1f;
    public float maxSpeed = 1.5f;
    public int confettiSpawnCount = 5;

    [Space]
    public Color[] colors;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }


    IEnumerator SpawnRoutine()
    {
        var waitTime = new WaitForSeconds(.3f);
        while (true)
        {
            for (int i=1; i <= confettiSpawnCount; i++)
            {
                SpawnConfetti();
            }
            yield return waitTime;
        }
    }

    private confetti SpawnConfetti()
    {
        var spawnX = Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2);
        var spawnPos = new Vector3(spawnX, spawnVerticalCoordinate);

        var confettiObject = Instantiate(ConfettiPrefab, spawnPos,Quaternion.identity,transform);
        var confetti = confettiObject.GetComponent<confetti>();
        confetti.color = colors[Random.Range(0, colors.Length)];
        confetti.speed = Random.Range(minSpeed, maxSpeed);
        confetti.destroyCoordinate = destroyVerticalCoordinate;

        return confetti;
    }

   
}
