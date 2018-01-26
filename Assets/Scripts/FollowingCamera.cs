using UnityEngine;

public class FollowingCamera : MonoBehaviour 
{
    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private bool setAtBeginning;

    private const float followSpeed = 3f;

    private void Awake()
    {
        if (setAtBeginning)
            SetXYPosition(targetTransform.position);
    }

    private void Update()
    {
        LerpTo(targetTransform.position);
    }

    private void LerpTo(Vector2 targetPos)
    {
        Vector2 originalPos = transform.position;
        Vector2 lerpedPos = Vector2.Lerp(originalPos, targetPos,Time.deltaTime*followSpeed);
        SetXYPosition(lerpedPos);
    }

    private void SetXYPosition(Vector3 newXY)
    {
        Vector3 newPos = transform.position;
        newPos.x = newXY.x;
        newPos.y = newXY.y;
        transform.position = newPos;
    }
}
