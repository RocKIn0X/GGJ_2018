using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermMovement : MonoBehaviour {

    private GameObject head;
    private GameObject tail;
    private float headRotation = 0;
    private float tailRotation = 0;

    private Rigidbody rigidbody;

    private const float force = 50;
    private const float flickSensitivity = 450;
    private const float flickBoost = 5f;
    private const float speedLimit = 8f;

    private void Awake()
    {
        head = this.gameObject.transform.GetChild(0).gameObject;
        tail = this.gameObject.transform.GetChild(1).gameObject;

        rigidbody = GetComponent<Rigidbody>();
    }
    
	void Update () {
        PushInTailDirection();
        ClampVelocity();

        if (Input.GetKey(KeyCode.A)) {
            headRotation -= Time.deltaTime * flickSensitivity;
//            headRotation = -90f;
        } else{
            headRotation += Time.deltaTime * flickSensitivity;
//            headRotation = 0f;
        }

        headRotation = Mathf.Clamp(headRotation, -45, 45);
        

        if (Input.GetKey(KeyCode.D)) {
            tailRotation += Time.deltaTime * flickSensitivity;
        } else {
            tailRotation -= Time.deltaTime * flickSensitivity;
        }

        tailRotation = Mathf.Clamp(tailRotation, -45, 45);
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

        bool isFlicking = (tailRotation > -45 && tailRotation < 45);
        float tailMultiplier = isFlicking? flickBoost : 1;

        rigidbody.AddForceAtPosition(head.transform.GetChild(0).transform.up * force * tailMultiplier * Time.deltaTime, head.transform.position);
        rigidbody.AddForceAtPosition(tail.transform.GetChild(0).transform.up * force * tailMultiplier * Time.deltaTime, tail.transform.position);
        //this.transform.position += tail.transform.up * speed * Time.deltaTime;
    }

    private void ClampVelocity()
    {
        Vector2 currentVelo = rigidbody.velocity;
        float veloMagnitude = currentVelo.magnitude;
        Vector2 adjustedVelo;

        if (veloMagnitude >= speedLimit)
            adjustedVelo = currentVelo * speedLimit / veloMagnitude;
        else
            adjustedVelo = currentVelo;

        rigidbody.velocity = adjustedVelo;
    }
}
