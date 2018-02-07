using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryBackground : MonoBehaviour {
    private Image srcImg;

    public Sprite winImg;
    public Sprite winImg2;
    void Awake() {
        srcImg = gameObject.GetComponent<Image>();
        float rand = Random.Range(0, 2);

        if (rand == 0) {
            srcImg.sprite = winImg;
        } else {
            srcImg.sprite = winImg2;
        }
    }

}
