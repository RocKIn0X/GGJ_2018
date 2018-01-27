using UnityEngine;

public class SuperCamera : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private float minY, maxY, startZ, endZ, startTpsZ, endTpsZ;

    private const float angle = 40, dist = 12;//, topY = 127;

    private Vector3 originalDist;
    private const float followSpeed = 3f;
    private const float transitionSpeed = 1f;
    private const float transitionArea = 20;

    private const float dieDist = 8;
    private const float dieAngle = 35;

    private bool dead = false;

    private void Awake()
    {
        transform.position = new Vector3(targetTransform.position.x, minY, targetTransform.position.z);
        transform.eulerAngles = new Vector3(90, 0, 0);
    }

    private void LateUpdate()
    {
        if (Input.GetKey("space"))
        {
            //dead = true;
            //targetTransform.GetComponent<SpermMovement>().Die();
        }
        
        Vector3 currentPos = transform.position;
        Quaternion temp = transform.rotation;

        if(dead)
        {
            //case dead
            currentPos = targetTransform.position - Vector3.forward * Mathf.Cos(Mathf.Deg2Rad * dieAngle) * dieDist + Vector3.up * Mathf.Sin(Mathf.Deg2Rad * dieAngle) * dieDist;
            LerpPosition(currentPos);

            transform.LookAt(targetTransform);
            Quaternion targetRotation = transform.rotation;
            transform.rotation = temp;
            LerpRotation(targetRotation);

            return;
        }

        if (targetTransform.position.z < startTpsZ || targetTransform.position.z > endTpsZ)
        {
            //case top
            currentPos = targetTransform.position;
            currentPos.y = Mathf.Lerp(minY, maxY, (targetTransform.position.z - startZ) / (endZ - startZ));
            LerpPosition(currentPos);

            transform.eulerAngles = new Vector3(90, 0, 0);
            Quaternion targetRotation = transform.rotation;
            transform.rotation = temp;
            LerpRotation(targetRotation);
        }
        else
        {
            //case tps view
            currentPos = targetTransform.position - Vector3.forward * Mathf.Cos(Mathf.Deg2Rad * angle) * dist + Vector3.up * Mathf.Sin(Mathf.Deg2Rad * angle) * dist;
            LerpPosition(currentPos);

            transform.LookAt(targetTransform);
            Quaternion targetRotation = transform.rotation;
            transform.rotation = temp;
            LerpRotation(targetRotation);
        }
    }

    private void LerpPosition(Vector3 newPos)
    {
        if (targetTransform.position.z < startTpsZ && targetTransform.position.z > startTpsZ - transitionArea || targetTransform.position.z > endTpsZ && targetTransform.position.z < endTpsZ + transitionArea)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * followSpeed);
        }
    }

    private void LerpRotation(Quaternion rotation)
    {
        if (targetTransform.position.z < startTpsZ && targetTransform.position.z > startTpsZ - transitionArea || targetTransform.position.z > endTpsZ && targetTransform.position.z < endTpsZ + transitionArea)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * transitionSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * followSpeed);
        }
    }
}
