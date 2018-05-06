using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopLostLivesMenu : MonoBehaviour {

    public Transform canvas;
    public Text noOfLivesLeft;
    public Text timeBox;
    public GameObject gameObject;

    // Update is called once per frame
    void Update () {
		if (int.Parse(noOfLivesLeft.text) == 0)
        {
            canvas.gameObject.SetActive(true);
            gameObject.gameObject.SetActive(false);
            timeBox.text = "-";
        }
	}
}
