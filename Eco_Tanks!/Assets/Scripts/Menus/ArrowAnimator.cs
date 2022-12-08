/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages the animation of the arrow that indicates the ability to move on to the next text box
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimator : MonoBehaviour
{
    //between pos 20 and 13
    public float maxY = 20;
    public float minY = 13;
    public float speed = 0.08f;

    private bool goingUp = true;
    private Vector3 startPositon;
    private Vector3 currentPos;
    // Start is called before the first frame update
    void OnEnable()
    {
        startPositon = gameObject.transform.position;
        currentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(goingUp)
        {
            currentPos.y += speed;
            gameObject.transform.position = currentPos;
            if(currentPos.y >= maxY) { goingUp = false; }
        }
        else
        {
            currentPos.y -= speed;
            gameObject.transform.position = currentPos;
            if (currentPos.y <= minY) { goingUp = true; }
        }

    }

    void OnDisable()
    {
        gameObject.transform.position = startPositon;
    }
}
