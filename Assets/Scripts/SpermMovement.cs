using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermMovement : MonoBehaviour {
    public float speed = 0.5f;


	void Start () {
		
	}
	
	void Update () {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
	}
}
