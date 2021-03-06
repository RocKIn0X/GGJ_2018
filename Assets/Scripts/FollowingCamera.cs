﻿using UnityEngine;

public class FollowingCamera : MonoBehaviour 
{
    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private bool setAtBeginning;
    [SerializeField]
    private bool xyCoord = true;
    [SerializeField]
    private bool tps = false;
    [SerializeField]
    private float minY, maxY, startZ, endZ;

    private Vector3 originalDist;
    private const float followSpeed = 3f;

    private void Awake()
    {
        if (setAtBeginning)
            SetXYPosition(targetTransform.position);

        originalDist = transform.position - targetTransform.position;
    }

    private void LateUpdate()
    {
        if(tps)
        {
            transform.position = targetTransform.position + originalDist;
            return;
        }
        LerpTo(targetTransform.position);

        Vector3 currentPos = transform.position;
        currentPos.y = Mathf.Lerp(minY,maxY,(transform.position.z - startZ)/(endZ-startZ));
        transform.position = currentPos;
    }

    private void LerpTo(Vector3 targetPos)
    {
        Vector3 originalPos = transform.position;
        Vector3 lerpedPos;
        lerpedPos = Vector3.Lerp(originalPos, targetPos, Time.deltaTime * followSpeed);
            
        SetXYPosition(lerpedPos);
    }

    private void SetXYPosition(Vector3 newXYZ)
    {
        Vector3 newPos = transform.position;
        if (xyCoord)
        {
            newPos.x = newXYZ.x;
            newPos.y = newXYZ.y;
        }
        else
        {
            newPos.x = newXYZ.x;
            newPos.z = newXYZ.z;
        }

        transform.position = newPos;
    }
}
