using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermSpawnPoint : MonoBehaviour 
{
    private const float spawnRadius = 3;

    public Vector3 GenerateSpawnPosition()
    {
        return GetPosition() + new Vector3(Random.Range(-spawnRadius/5,spawnRadius/5), 0, 0) + new Vector3(0, 0, Random.Range(spawnRadius/1.5f,spawnRadius));   
    }

    private Vector3 GetPosition()
    {
        return transform.position;
    }

    public Quaternion CalculateRotation(Vector3 spawnPos)
    {
        return Quaternion.LookRotation(CalculateExplosionDirection(spawnPos));
    }

    public Vector3 CalculateExplosionDirection(Vector3 spawnPos)
    {
        Vector3 currentPos = GetPosition();
        Vector3 delta = spawnPos - currentPos;
        return delta / delta.magnitude;
    }
}
