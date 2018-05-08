using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpdate : MonoBehaviour {

    public Text timeBox;
    public Text savedTime;
    public Transform canvas;
    public GameObject gameObject;
    public int initialTimeInMinutes;

    private int seconds = 0;
    private int minutes = 0;
    private float elapsedTime;

    private Boolean timesUp = false;
    private Boolean updatedTimeBoxFormat = false;

	// Use this for initialization
	void Start () {
        timeBox.text = "" + initialTimeInMinutes + ":00";
        elapsedTime = Time.time;
        seconds = 1;
        minutes = initialTimeInMinutes;
	}
	
	// Update is called once per frame
	void Update () {
        if (savedTime.text.StartsWith("DEAD"))
        {
            elapsedTime = Time.time;
            restoreTime();
            return;
        }

        float currentTime = Time.time;
		if (currentTime - elapsedTime >= 1)
        {
            elapsedTime = currentTime;
            updateTime();
        }
	}

    private void restoreTime()
    {
        if (savedTime.text.Length == 4)
        {
            minutes = initialTimeInMinutes;
            seconds = 1;
            savedTime.text = "";
            timeBox.text = "" + initialTimeInMinutes + ":00";
            return;
        }
        string savedTimeValue = savedTime.text.Substring(4);
        int separatorIndex = savedTimeValue.IndexOf(':');
        minutes = int.Parse(savedTimeValue.Substring(0, separatorIndex));
        seconds = int.Parse(savedTimeValue.Substring(separatorIndex + 1));
        savedTime.text = savedTimeValue;
    }

    private void updateTime()
    {
        if (paused())
        {
            return;
        }

        seconds--;
        checkTime();
        if (timesUp)
        {
            updateFont();
            return;
        }

        if (seconds == 0)
        {
            minutes--;
            seconds = 59;
        }

        timeBox.text = "" + minutes + ":" + seconds;
    }

    private bool paused()
    {
        return timeBox.text.Equals("PAUSED") || timeBox.text.Equals("-");
    }

    private void updateFont()
    {
        if (updatedTimeBoxFormat)
        {
            return;
        }

        updatedTimeBoxFormat = true;

        timeBox.fontSize += 8;
        timeBox.color = new Color(1, 0, 0);
       
    }

    private void checkTime()
    {
        if (minutes == 0 && seconds == 0 && !timesUp)
        {
            canvas.gameObject.SetActive(true);
            gameObject.gameObject.SetActive(false);
            timesUp = true;
            timeBox.text = "0:00";
        }
    }
}
