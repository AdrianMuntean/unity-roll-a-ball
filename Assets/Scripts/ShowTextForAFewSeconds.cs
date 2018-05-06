using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextForAFewSeconds : MonoBehaviour {

    public float timeToBeDisplayed;

    public Text text;

    private List<string> listOfText = new List<string>();
    private float time;
    private int index = 0;
    private int noOfFontIncreases = 20;
    // Use this for initialization
    void Start () {
        text.enabled = true;
        time = Time.time;
        listOfText.Add("Welcome, this is the first level");
        listOfText.Add("Use the arrow keys for moving the ball");
        listOfText.Add("The goal is to reach the end of each level");
        listOfText.Add("There is only one rule:");
        listOfText.Add("Don't leave the game surface!");
    }

    // Update is called once per frame
    void Update () {
        if (index == 4 && noOfFontIncreases-- > 0)
        {
            text.fontSize += 1;
        }
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

    private string getText()
    {
        if (index >= listOfText.Count)
        {
            return "";
        }

        return listOfText[index];
    }
}
