using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public int speed = 100;
    public bool isMoving = false;

    void Start() {
    }

    void Update() {

        // Debounce: Prevents the rotation from being interrupted when a different button is pressed.
        if (isMoving) {
            return;
        }

        // Checks user input and initiates a roll to the target direction.
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            StartCoroutine(Roll(Vector3.right));
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            StartCoroutine(Roll(Vector3.left));
        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            StartCoroutine(Roll(Vector3.forward));
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            StartCoroutine(Roll(Vector3.back));
        }
    }

    IEnumerator Roll(Vector3 direction) {
        isMoving = true;

        float remainingAngle = 90f;
        Vector3 rotationCenter = transform.position + (direction/2) + (Vector3.down/2);
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle  > 0f){
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }
        
        // Aligns the new position of the cube to the grid.
        Vector3 alignedPosition = transform.position;
        alignedPosition.x = Mathf.Round(alignedPosition.x);
        alignedPosition.z = Mathf.Round(alignedPosition.z);
        transform.position = alignedPosition;

        isMoving = false;
    }
}
