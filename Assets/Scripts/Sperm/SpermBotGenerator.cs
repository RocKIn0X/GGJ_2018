using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermBotGenerator : MonoBehaviour 
{
    [SerializeField]
    private SpermSpawnZone spawnZone;
    [SerializeField]
    private SpermBot spermBotPrefab;

    private const int numGenerate = 150;

    private const float startDelay = 2;
    private const float spawnInterval = 0.01f;

    private const float minExplosion = 0, maxExplosion = 0;

    // =================
    // behaviours
    // =================
    private void Awake()
    {
        GenerateSpermBot();
    }

    //==================
    // public interface
    //==================
    public void GenerateSpermBot()
    {
        StopAllCoroutines();
        StartCoroutine(GenerateCoroutine());
    }

    //==================
    // private helper
    //==================
    private IEnumerator GenerateCoroutine()
    {
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < numGenerate; i++)
        {
            SpawnDetails spawnDetails = spawnZone.GenerateNewSpawnDetails();

            Vector3 spawnPos = spawnDetails.position;
            Quaternion spawnRot = spawnDetails.rotation;
            //Vector3 spawnDirection = spawnDetails.startForceDirection;
            //Vector3 spawnForce = spawnDirection * Random.Range(minExplosion, maxExplosion);

            SpermBot newBot = Instantiate(spermBotPrefab, spawnPos, spawnRot) as SpermBot;
            //newBot.InitEssentialValues(spawnForce);
            //newBot.BurstWhenReady();
            newBot.Burst();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
