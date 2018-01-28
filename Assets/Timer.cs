using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public float timeLimit = 120;
    public string prefix = " time left : ";
    private float timeCounter = 0;
    private Text text;
    private bool start = false;

    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = GetTimeLeftString();
        StartTimer();
    }

    private void Update()
    {
        if(start)
        {
            timeCounter += Time.deltaTime;
            text.text = GetTimeLeftString();

            if(timeCounter >= timeLimit)
            {
                OnTimeOut();
            }
        }
    }

    private void OnTimeOut()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void StartTimer()
    {
        start = true;
    }

    public string GetTimeLeftString()
    {
        return prefix + ((timeLimit - timeCounter)/2).ToString("#.##") + " hours";
    }
}
