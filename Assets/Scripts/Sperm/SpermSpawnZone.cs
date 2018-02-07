using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermSpawnZone : MonoBehaviour 
{
    private const float randomMagnitudeX = 0.6f;
    private const float randomMinZ = 2;
    private const float randomMaxZ = 3;

    // ==================
    // public interface
    // ==================
    public SpawnDetails GenerateNewSpawnDetails()
    {
        SpawnDetails details = new SpawnDetails();
        details.position = GenerateSpawnPosition();
        details.rotation = CalculateRotation(details.position);
        //details.startForceDirection = CalculateForceDirection(details.position);

        return details;
    }

    // ================
    // private helper
    // ================
    private Vector3 GetPosition()
    {
        return transform.position;
    }

    private Vector3 GenerateSpawnPosition()
    {
        float xAdjustment = Random.Range(-randomMagnitudeX, randomMagnitudeX);
        float zAdjustment = Random.Range(randomMinZ, randomMaxZ);

        return GetPosition() + new Vector3(xAdjustment, 0, zAdjustment);
    }

    private Quaternion CalculateRotation(Vector3 spawnPos)
    {
        return Quaternion.LookRotation(CalculateForceDirection(spawnPos));
    }

    private Vector3 CalculateForceDirection(Vector3 spawnPos)
    {
        Vector3 currentPos = GetPosition();
        Vector3 delta = spawnPos - currentPos;
        return delta / delta.magnitude;
    }
}
