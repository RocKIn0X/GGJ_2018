using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermMovement : MonoBehaviour {
    public float speed = 0.5f;

    private GameObject head;
    private GameObject tail;
    private float headRotation = 0;
    private float tailRotation = 0;

	void Start () {
        head = this.gameObject.transform.GetChild(0).gameObject;
        tail = this.gameObject.transform.GetChild(1).gameObject;
    }
	
	void Update () {
        this.transform.position += Vector3.up * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A)) {
            headRotation = -90f;
        } else if (Input.GetKeyUp(KeyCode.A)) {
            headRotation = 0f;
        }
        

        if (Input.GetKeyDown(KeyCode.D)) {
            tailRotation = 90f;
        } else if (Input.GetKeyUp(KeyCode.D)) {
            tailRotation = 0f;
        }

        head.transform.eulerAngles = new Vector3(0f, 0f, headRotation);
        tail.transform.eulerAngles = new Vector3(0f, 0f, tailRotation);
    }
}
