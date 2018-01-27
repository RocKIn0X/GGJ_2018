using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermArmyManager : MonoBehaviour 
{
    [SerializeField]
    private Transform leftOvary, rightOvary;
    public SpermBot spermPrefab;
    public SpermSpawnPoint spawnPoint;
    private const float minSpeed = 10, maxSpeed = 30;

    private const int numSpawnAtBeginning = 20;

    private void Awake()
    {
        for (int i = 0; i < numSpawnAtBeginning; i++)
        {
            Vector3 spawnPos = spawnPoint.GenerateSpawnPosition();
            Quaternion spawnDirection = spawnPoint.CalculateRotation(spawnPos);
            SpermBot newBot = Instantiate(spermPrefab, spawnPos, spawnDirection) as SpermBot;

            if (Random.Range(0, 2) == 1)
                newBot.SetTargetPosition(leftOvary.position);
            else
                newBot.SetTargetPosition(rightOvary.position);


            //newBot.SetInitialVelocity(spawnPoint.CalculateDirection(spawnPos) * Random.Range(minSpeed, maxSpeed));
            newBot.SetSpeed(Random.Range(minSpeed,maxSpeed));
        }
    }

}
