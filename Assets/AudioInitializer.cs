using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioInitializer : MonoBehaviour 
{
    void Start () 
    {
        if (SceneManager.GetActiveScene().name == "TestSpermControl")
            AudioController.PlayMusic("doom");
        else if (SceneManager.GetActiveScene().name == "GameOver")
            AudioController.PlayMusic("roongg");
        else if (SceneManager.GetActiveScene().name == "Victory")
            AudioController.PlayMusic("doom");
	}
}
