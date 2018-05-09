using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLevel1 : MonoBehaviour {

    public GameObject level2PlayButton;
    public GameObject level2Text;

    private string highestScore_key = "HIGHESTSCORE_L1";
    // Use this for initialization
    void Start () {
        level2PlayButton.gameObject.SetActive(false);
        level2Text.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt(highestScore_key) != 0)
        {
            level2PlayButton.gameObject.SetActive(true);
            level2Text.gameObject.SetActive(true);
        }
	}
}
