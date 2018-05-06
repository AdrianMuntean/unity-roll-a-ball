using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHintAboutScoreAndTime : MonoBehaviour {

    public float timeToBeDisplayed;
    public Text text;
    public Text textThatNeedToBeEmpty;

    private List<string> listOfText = new List<string>();
    private float time;
    private int index = 0;
    private int noOfFontIncreases = 20;
    private int sizeOfOtherHints = 5;
    private bool startHint = false;
    // Use this for initialization
    void Start()
    {
        text.enabled = false;
        time = Time.time;
        listOfText.Add("In the upper left is the score panel");
        listOfText.Add("Score increases with every colectible item");
        listOfText.Add("Next to the score is the level time");
        listOfText.Add("If the time expires");
        listOfText.Add("You have to start over.");

        listOfText.Add("In any moment press ESC to open the pause menu");
        listOfText.Add("Try it!");
    }
	
	// Update is called once per frame
	void Update () {
        if (!startHint)
        {
            if (textThatNeedToBeEmpty.text.Equals(""))
            {
                startHint = true;
                text.enabled = true;
                time = Time.time;
            }
        } 

        if (startHint)
        {
            string textToDisplay = getText();
            text.text = textToDisplay;
            if (Time.time - time > timeToBeDisplayed)
            {
                index++;
                time = Time.time;
            }

            if (textToDisplay.Equals(""))
            {
                text.enabled = false;

            }
        }
		
	}

    private string getText()
    {
        if (index >= listOfText.Count)
        {
            return "";
        }

        return listOfText[index];
    }
}
