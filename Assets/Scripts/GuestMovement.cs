using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GuestMovement : MonoBehaviour {
    public GameObject gameController;
    private RoomsPositions positionRoom;
    
    private Transform[] currentRoom = new Transform[]{};
    
    private int currentPosition = 0;
    private int nextPosition = 1;

    private bool rotateDirection = false;

    private float timeToMove = 2;
    private float currentTime = 0;

    private bool inTimer = false;

    private int currentRoomNumber = 1;

    public Sprite[] sprites;
    public SpriteRenderer spriteRender;

    public int angle;
    
    // Start is called before the first frame update
    void Start() {
        ChangeSprite();
        guestRotate();
        
        gameController = GameObject.Find("Game Controller");
        positionRoom = gameController.GetComponent<RoomsPositions>();
        
        currentRoom = positionRoom.SetupPosition();
        positionRoom.SetBusy(currentRoom, currentPosition);
        transform.position = currentRoom[0].position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        currentTime += Time.deltaTime;
        //CheckCurrentPosition();
        if (currentTime >= timeToMove) {
            currentTime = 0;
            if (!inTimer) {
                MoveToNextPosition();
            }
        }
    }

    public void MoveToNextPosition() {
        if (currentPosition < currentRoom.Length - 1) {
            if (!positionRoom.GetPositionState(currentRoom, currentRoomNumber, nextPosition)) {
                transform.position = currentRoom[nextPosition].position;
            
                positionRoom.SetEmpty(currentRoom, currentPosition);
                positionRoom.SetBusy(currentRoom, nextPosition);
            
                guestRotate();
        
                currentPosition++;
                nextPosition++;
            } else {
                guestResetRotation();
            }
        } else {
            if (!positionRoom.GetPositionState(currentRoom, currentRoomNumber, nextPosition)) {
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
            } else {
                guestResetRotation();
            }
        }
    }

    public void guestRotate() {
        if (rotateDirection) {
            transform.rotation = Quaternion.Euler(0,0,-angle);
        }
        else {
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
        rotateDirection = !rotateDirection;
    }
    
    public void guestResetRotation() {
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void ChangeSprite() {
        int number = (int)Random.Range(1, 5);
        switch (number) {
            case 1:
                spriteRender.sprite = sprites[0];
                break;
            case 2:
                spriteRender.sprite = sprites[1];
                break;
            case 3:
                spriteRender.sprite = sprites[2];
                break;
            case 4:
                spriteRender.sprite = sprites[3];
                break;
        }
    }

    public void CheckCurrentPosition() {
        String nameRoom = CheckPosition(currentRoomNumber ,currentPosition);
        if (nameRoom.Equals("Entrance")) {
            
        }
    }
    
    public string CheckPosition(int RoomNumber, int currentPosition) {
        if (RoomNumber == 2 && currentPosition == 4) {
            return "Entrance";
        } else if (RoomNumber == 3) {
            return "Room 01";
        } else if (RoomNumber == 4) {
            return "Room 02";
        } else if (RoomNumber == 5) {
            return "Room 03";
        } else if (RoomNumber == 6) {
            return "Room 04";
        } else if (RoomNumber == 7) {
            return "Room 05";
        } else if (RoomNumber == 8) {
            return "Room 06";
        } else if (RoomNumber == 9) {
            return "Room 07";
        } else if (RoomNumber == 10) {
            return "Room 08";
        } else if (RoomNumber == 11) {
            return "Room 09";
        } else if (RoomNumber == 12) {
            return "Room 10";
        } else {
            return null;
        }
    }
}
