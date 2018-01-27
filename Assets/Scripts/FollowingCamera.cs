using UnityEngine;

public class FollowingCamera : MonoBehaviour 
{
    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private bool setAtBeginning;
    [SerializeField]
    private bool xyCoord = true;

    private const float followSpeed = 3f;

    private void Awake()
    {
        if (setAtBeginning)
            SetXYPosition(targetTransform.position);
    }

    private void LateUpdate()
    {
        LerpTo(targetTransform.position);
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
