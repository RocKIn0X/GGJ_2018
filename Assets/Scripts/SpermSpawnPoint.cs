using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermSpawnPoint : MonoBehaviour 
{
    private const float spawnRadius = 3;

    public Vector3 GenerateSpawnPosition()
    {
        return GetPosition() + new Vector3(Random.Range(-spawnRadius,spawnRadius), 0, 0) + new Vector3(0, 0, Random.Range(-spawnRadius,spawnRadius));   
    }

    private Vector3 GetPosition()
    {
        return transform.position;
    }

    public Quaternion CalculateRotation(Vector3 spawnPos)
    {
        return Quaternion.LookRotation(CalculateDirection(spawnPos));
    }

    public Vector3 CalculateDirection(Vector3 spawnPos)
    {
        Vector3 currentPos = GetPosition();
        Vector3 delta = spawnPos - currentPos;
        return delta / delta.magnitude;
    }
}
