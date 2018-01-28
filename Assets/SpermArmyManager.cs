using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermArmyManager : MonoBehaviour 
{
    [SerializeField]
    private Transform leftOvary, rightOvary;
    public SpermBot smarpSpermPrefab;
    public NaiveSpermBot naiveSpermBot;
    public SpermSpawnPoint spawnPoint;
    private const float minSpeed = 5, maxSpeed = 15;
    private const float minExplosion = 0, maxExplosion = 0;

    private const int numSmartSperm = 10;
    private const int numNaiveSperm = 150;

    private void Awake()
    {
        //for (int i = 0; i < numSmartSperm; i++)
        //{
        //    Vector3 spawnPos = spawnPoint.GenerateSpawnPosition();
        //    if (usedPosition.Contains(spawnPos))
        //    {
        //        i--;
        //        continue;
        //    }
        //    else
        //        usedPosition.Add(spawnPos);

        //    Quaternion spawnDirection = spawnPoint.CalculateRotation(spawnPos);
        //    SpermBot newBot = Instantiate(smarpSpermPrefab, spawnPos, spawnDirection) as SpermBot;
        //    Vector3 forceDirection = spawnPoint.CalculateExplosionDirection(spawnPos);

        //    if (Random.Range(0, 2) == 1)
        //        newBot.InitEssentialValues(leftOvary.position, forceDirection * Random.Range(minExplosion, maxExplosion), Random.Range(minSpeed, maxSpeed));
        //    else
        //        newBot.InitEssentialValues(rightOvary.position, forceDirection * Random.Range(minExplosion, maxExplosion), Random.Range(minSpeed, maxSpeed));
        //    newBot.BurstWhenReady();
        //}
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2);

        List<Vector3> usedPosition = new List<Vector3>();

        for (int i = 0; i < numNaiveSperm; i++)
        {
            Vector3 spawnPos = spawnPoint.GenerateSpawnPosition();
            if (usedPosition.Contains(spawnPos))
            {
                i--;
                continue;
            }
            else
                usedPosition.Add(spawnPos);

            Quaternion spawnDirection = spawnPoint.CalculateRotation(spawnPos);
            NaiveSpermBot newBot = Instantiate(naiveSpermBot, spawnPos, spawnDirection) as NaiveSpermBot;
            Vector3 forceDirection = spawnPoint.CalculateExplosionDirection(spawnPos);
            print(forceDirection);

            if (Random.Range(0, 2) == 1)
                newBot.InitEssentialValues(forceDirection * Random.Range(minExplosion, maxExplosion));
            else
                newBot.InitEssentialValues(forceDirection * Random.Range(minExplosion, maxExplosion));

            newBot.BurstWhenReady();

            yield return new WaitForSeconds(0.01f);
        }
    }

}
