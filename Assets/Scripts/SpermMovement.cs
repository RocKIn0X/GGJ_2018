using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermMovement : MonoBehaviour {

    private GameObject head;
    private GameObject tail;
    private float headRotation = 0;
    private float tailRotation = 0;

    private Rigidbody rigidbody;

    private const float force = 60;
    private const float flickSensitivity = 450;
    private const float flickBoost = 5f;
    private const float speedLimit = 6f;
    private const float maxAngularVelo = 10000;
    private const float flickAngle = 30f;
    private const float headAngle = 35f;

    private void Awake()
    {
        head = this.gameObject.transform.GetChild(0).gameObject;
        tail = this.gameObject.transform.GetChild(1).gameObject;

        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = Vector3.forward * 7;
    }
    
	void Update () {
        PushInTailDirection();
        ClampVelocity();

        if (Input.GetKey(KeyCode.A)) {
            headRotation -= Time.deltaTime * flickSensitivity;
            if (Input.GetKey(KeyCode.D))
            {
                tailRotation -= Time.deltaTime * flickSensitivity;
            }
            else
            {
                tailRotation += Time.deltaTime * flickSensitivity;
            }
        } else{
            headRotation += Time.deltaTime * flickSensitivity;
            if (Input.GetKey(KeyCode.D))
            {
                tailRotation += Time.deltaTime * flickSensitivity;
            }
            else
            {
                tailRotation -= Time.deltaTime * flickSensitivity;
            }
        }

        headRotation = Mathf.Clamp(headRotation, -headAngle, headAngle);
        

        //if (Input.GetKey(KeyCode.D)) {
        //    tailRotation += Time.deltaTime * flickSensitivity;
        //} else {
        //    tailRotation -= Time.deltaTime * flickSensitivity;
        //}

        tailRotation = Mathf.Clamp(tailRotation, -flickAngle, flickAngle);
        //if (headRotation - tailRotation > 0) {
        //    this.transform.position += Vector3.right * 2f * Time.deltaTime;
        //} else if (headRotation - tailRotation < 0) {
        //    this.transform.position += Vector3.left * 2f * Time.deltaTime;
        //} else {

        //}
        head.transform.localEulerAngles = new Vector3(0f, 0f, headRotation);
        tail.transform.localEulerAngles = new Vector3(0f, 0f, tailRotation);

        //Debug.Log(rigidbody.velocity.magnitude); 
    }

    void PushInTailDirection()
    {
        //this.transform.position += head.transform.GetChild(0).transform.up * speed * Time.deltaTime;
        //this.transform.position += tail.transform.GetChild(0).transform.up * speed * Time.deltaTime;
        Debug.DrawRay(head.transform.position, -head.transform.GetChild(0).transform.up * force*1000, Color.red);
        Debug.DrawRay(tail.transform.position, -tail.transform.GetChild(0).transform.up * force*1000, Color.red);

        bool isFlicking = (tailRotation > -flickAngle && tailRotation < flickAngle);
        float tailMultiplier = isFlicking? flickBoost : 1;

        rigidbody.AddForceAtPosition(head.transform.GetChild(0).transform.up * force * tailMultiplier * Time.deltaTime, head.transform.position);
        //rigidbody.AddForceAtPosition(tail.transform.GetChild(0).transform.up * force * tailMultiplier * Time.deltaTime, tail.transform.position);
        //this.transform.position += tail.transform.up * speed * Time.deltaTime;
    }

    private void ClampVelocity()
    {
        Vector3 currentVelo = rigidbody.velocity;
        float veloMagnitude = currentVelo.magnitude;
        Vector3 adjustedVelo;

        if (veloMagnitude >= speedLimit)
            adjustedVelo = currentVelo * speedLimit / veloMagnitude;
        else
            adjustedVelo = currentVelo;

        rigidbody.velocity = adjustedVelo;

        //rigidbody.angularVelocity = new Vector3(rigidbody.angularVelocity.x, Mathf.Clamp(rigidbody.angularVelocity.y, -maxAngularVelo, maxAngularVelo), rigidbody.angularVelocity.z);
    }

    public void Die()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.mass = 0.1f;

    }
}
