using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public void loadLevel (string name) {
        SceneManager.LoadScene(name);
    }

    public void loadGame ()
    {
        SceneManager.LoadScene("TestSpermControl");
    }

    public void loadMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
