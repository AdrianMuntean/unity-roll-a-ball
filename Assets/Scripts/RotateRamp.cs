using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRamp : MonoBehaviour {

    private const int UP = 1;
    private const int DOWN = 0;
    private const float rotateSpeed = 10; 
    private int moveDirection = DOWN;

	// Update is called once per frame
	void Update () {
        if (moveDirection == UP)
        {
            transform.Rotate(new Vector3(rotateSpeed, 0, 0) * Time.deltaTime);
            if (isUp())
            {
                moveDirection = DOWN;
            }
        }

        if (moveDirection == DOWN)
        {
            transform.Rotate(new Vector3(-rotateSpeed, 0, 0) * Time.deltaTime);
            if (isDown())
            {
                moveDirection = UP;
            }
        }
    }

    private bool isDown()
    {
        return transform.rotation.x <= -60;
    }

    private bool isUp()
    {
        return transform.rotation.x <= -120;
    }
}
