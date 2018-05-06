using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rigidbody;

    public float speed;
    public Text scoreBoard;
    public Text noOfLives;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed);
    }

    public void Update()
    {
        if (rigidbody.position.y < -8)
        {
            Debug.Log("Player died");
            rigidbody.position = new Vector3(0, 0.5f, 0);
            int livesLeft = int.Parse(noOfLives.text);
            livesLeft--;
            noOfLives.text = "" + livesLeft;
            if (livesLeft == -1)
            {
                Debug.Log("Plyer died for good");
            }
        }
    }
}
