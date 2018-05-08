using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rigidbody;

    public float speed;
    public Text scoreBoard;
    public Text noOfLives;
    public Text gameMessageBox;
    public Text levelTime;
    public Text savedLevelTime;
    public Text finalScoreText;
    public Transform endLevelMenu;

    public Material wood;
    public Material stone;
    public Material paper;

    private float reviveX;
    private float reviveY;
    private float reviveZ;
    private float startTimeOfDisplay;
    private int score;
    bool doneLevel;

    private Material savedMaterial;
    private Vector3 savedScale;
    private float savedSpeed = 10;

    private void Start()
    {
        doneLevel = false;
        score = 0;
        startTimeOfDisplay = 0f;
        reviveX = 0;
        reviveY = 0.5f;
        reviveZ = 0;
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = wood;
        savedMaterial = wood;
        savedScale = new Vector3(1f, 1f, 1f);
    }

    public void FixedUpdate()
    {
        if (doneLevel)
        {
            return;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed);
    }

    public void Update()
    {
       // PlayerPrefs.DeleteAll();
        if (rigidbody.position.y < -4)
        {
            Debug.Log(savedLevelTime.text);
            Debug.Log("Player died");
            rigidbody.position = new Vector3(reviveX, reviveY, reviveZ);
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            int livesLeft = int.Parse(noOfLives.text);
            livesLeft--;
            noOfLives.text = "" + livesLeft;
            savedLevelTime.text = "DEAD" + savedLevelTime.text;
            Debug.Log("Saved time: " + savedLevelTime.text);
            speed = savedSpeed;
            transform.localScale = savedScale;
            GetComponent<Renderer>().material = savedMaterial;
        }

        checkGameMessageExpiration();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Pick up - red":
                other.gameObject.SetActive(false);
                updateScore(10);
           break;
            case "Pick up - blue":
                other.gameObject.SetActive(false);
                updateScore(50);
                break;
          case "Pick up - yellow":
                other.gameObject.SetActive(false);
                updateScore(100);
           break;
            case "Save":
                saveCoordinates(other);
                saveTime();
                other.gameObject.SetActive(false);
                UpdateMessageBox("YOUR PROGRESS WAS SAVED");

                savedSpeed = speed;
                savedScale = transform.localScale;
                savedMaterial = GetComponent<Renderer>().material;
                break;
            case "End game":
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                doneLevel = true;
                updateFinalScore();
                levelTime.text = "-";
                endLevelMenu.gameObject.SetActive(true);
                break;
            case "Life":
                int livesLeft = int.Parse(noOfLives.text);
                livesLeft++;
                noOfLives.text = "" + livesLeft;
                other.gameObject.SetActive(false);
                UpdateMessageBox("You have gained one extra life");
                break;
            case "Stone":
                //savedSpeed = speed;
                //savedScale = transform.localScale;
                //savedMaterial = GetComponent<Renderer>().material;
                rigidbody.mass = 1.2f;
                speed = 3;
                //other.gameObject.SetActive(false);
                //transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
                GetComponent<Renderer>().material = stone;
                break;
            case "Paper":
                //savedSpeed = speed;
                //savedScale = transform.localScale;
                //savedMaterial = GetComponent<Renderer>().material;

                speed = 15;
                //other.gameObject.SetActive(false);
                transform.localScale = new Vector3(1f, 1f, 1f);
                GetComponent<Renderer>().material = paper;
                break;

            case "Wood":
                //savedSpeed = speed;
                //savedScale = transform.localScale;
                //savedMaterial = GetComponent<Renderer>().material;

                speed = 10;
                //other.gameObject.SetActive(false);
                transform.localScale = new Vector3(1f, 1f, 1f);
                GetComponent<Renderer>().material = wood;
                break;
        }

        checkGameMessageExpiration();
        //Destroy(other.gameObject);
        
    }

    private void updateFinalScore()
    {
        int secondsLeft = parseSeconds();
        int score = secondsLeft + int.Parse(scoreBoard.text);
        finalScoreText.text = "" + score;
    }

    private int parseSeconds()
    {
        String timeLeftString = levelTime.text;
        
        int separatorIndex = timeLeftString.IndexOf(':');
        
        int timeScore = int.Parse(timeLeftString.Substring(0, 1)) * 60;
        
        timeScore += int.Parse(timeLeftString.Substring(separatorIndex + 1));
        return timeScore;
    }

    private void saveTime()
    {
        savedLevelTime.text = levelTime.text;
        Debug.Log("Saved time:" + savedLevelTime.text);
        Debug.Log("TActual  tiem : " + levelTime.text);
    }

    private void UpdateMessageBox(string textToDisplay)
    {
        gameMessageBox.enabled = true;
        gameMessageBox.text = textToDisplay;
        startTimeOfDisplay = Time.time;
    }

    private void saveCoordinates(Collider other)
    {
        reviveX = other.transform.position.x;
        reviveY = other.transform.position.y;
        reviveZ = other.transform.position.z;
    }

    private void checkGameMessageExpiration()
    {
        if (gameMessageBox.IsActive())
        {
            if (Time.time - startTimeOfDisplay >= 4)
            {
                gameMessageBox.enabled = false;
            }
        }
    }

    private void updateScore(int gainedPoints)
    {
        score += gainedPoints;
        scoreBoard.text = score + "";
    }
}
