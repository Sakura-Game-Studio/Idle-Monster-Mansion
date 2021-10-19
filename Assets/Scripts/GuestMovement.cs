using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestMovement : MonoBehaviour {
    public GameObject gameController;
    private RoomsPositions positionRoom;
    
    private Transform[] currentRoom = new Transform[]{};
    
    private int currentPosition = 0;
    private int nextPosition = 1;

    private bool rotateDirection = false;

    private float timeToMove = 2;
    private float currentTime = 0;

    private int currentRoomNumber = 1;
    
    // Start is called before the first frame update
    void Start() {
        gameController = GameObject.Find("Game Controller");
        positionRoom = gameController.GetComponent<RoomsPositions>();
        
        currentRoom = positionRoom.SetupPosition();
        positionRoom.SetBusy(currentRoom, currentPosition);
        transform.position = currentRoom[0].position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToMove) {
            currentTime = 0;
            MoveToNextPosition();
        }
    }

    public void MoveToNextPosition() {
        
        if (currentPosition < currentRoom.Length - 1) {
            transform.position = currentRoom[nextPosition].position;
            
            positionRoom.SetEmpty(currentRoom, currentPosition);
            positionRoom.SetBusy(currentRoom, nextPosition);
            
            guestRotate();
        
            currentPosition++;
            nextPosition++;
        }
        else {
            currentRoomNumber++;
            positionRoom.SetEmpty(currentRoom, currentPosition);
            currentRoom = positionRoom.ChangeRoom(currentRoomNumber);
            
            if (currentRoom == null) {
                Destroy(gameObject);                
            } else {
                nextPosition = 1;
                currentPosition = 0;
                transform.position = currentRoom[currentPosition].position;

                guestRotate();
                
                positionRoom.SetBusy(currentRoom, currentPosition);
            }
        }
    }

    public void guestRotate() {
        if (rotateDirection) {
            transform.rotation = Quaternion.Euler(0,0,-10);
        }
        else {
            transform.rotation = Quaternion.Euler(0,0,10);
        }
        rotateDirection = !rotateDirection;
    }
}