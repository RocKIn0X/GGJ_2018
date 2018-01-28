using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggBreakthroughEvent : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        print("something enter " + other.gameObject.tag );

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Victory");
            return;
        }

        if(other.gameObject.tag == "OtherSperm")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*100);
            return;
        }
    }
}
