using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour {
    [SerializeField]
    private string targetSceneName;

    private Button button;

    //private void OnValidate()
    //{
    //    if (SceneManager.GetSceneByName(targetSceneName) == null)
    //        Debug.LogError("scene name : " + targetSceneName + " is not found in scene management");
    //}

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneManager.LoadScene(targetSceneName);
    }

}
