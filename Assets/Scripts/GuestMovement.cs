using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GuestMovement : MonoBehaviour {
    public GameObject gameController;
    private RoomsPositions positionRoom;
    private RoomsStats roomStatsArray;
    private RoomSettings currentRoomStats;
    
    private Transform[] currentRoom = new Transform[]{};
    
    private int currentPosition = 0;
    private int nextPosition = 1;

    private bool rotateDirection = false;

    private float timeToMove = 2;
    private float currentTime = 0;

    private float timerToExecute;
    private float currentTimeToExecute = 0;

    private bool executing = false;

    private int currentRoomNumber = 1;

    public Sprite[] sprites;
    public Sprite[] spritesScare;

    private int spriteNumber;
    
    public SpriteRenderer spriteRender;

    public int angle;

    public CurrencyManager currencyManager;
    public TimerImageController timerImageController;
    public MonsterControl monsterControl;
    
    // Start is called before the first frame update
    void Start() {
        ChangeSprite();
        guestRotate();
        
        gameController = GameObject.Find("Game Controller");
        positionRoom = gameController.GetComponent<RoomsPositions>();
        roomStatsArray = gameController.GetComponent<RoomsStats>();
        currencyManager = gameController.GetComponent<CurrencyManager>();
        timerImageController = gameController.GetComponent<TimerImageController>();
        monsterControl= gameController.GetComponent<MonsterControl>();
        
            
        currentRoomStats = roomStatsArray.SetupStats();
        currentRoom = positionRoom.SetupPosition();
        positionRoom.SetBusy(currentRoom, currentPosition);
        transform.position = currentRoom[0].position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToMove && !executing) {
            currentTime = 0;
            MoveToNextPosition();
        }
        
        if (executing) {
            currentTimeToExecute += Time.deltaTime;
            if (currentTimeToExecute >= timerToExecute - 2) {
                monsterControl.Scare(currentRoomNumber);
                GuestScare();
            }
            guestResetRotation();
        }
        
        CheckCurrentPosition();

        if (currentTimeToExecute >= timerToExecute) {
            currentTimeToExecute = 0;
            if (positionRoom.GetPositionState(currentRoom, currentRoomNumber, nextPosition)) {
                currentRoomNumber = 12;
                MoveToNextPosition();
            }
            monsterControl.ResetScare(currentRoomNumber);
            GuestResetSprite();
            executing = false;
            currencyManager.EarnMoney(currentRoomStats);
        }
        
        if (currentRoomNumber == 13 && currentPosition == 5) {
            positionRoom.SetEmpty(currentRoom, currentPosition);
            Destroy(gameObject);
        }
    }

    public void MoveToNextPosition() {
        if (!executing) {
            if (currentPosition < currentRoom.Length - 1)
            {
                if (!positionRoom.GetPositionState(currentRoom, currentRoomNumber, nextPosition)) {
                    transform.position = currentRoom[nextPosition].position;

                    positionRoom.SetEmpty(currentRoom, currentPosition);
                    positionRoom.SetBusy(currentRoom, nextPosition);

                    guestRotate();

                    currentPosition++;
                    nextPosition++;
                }
                else
                {
                    guestResetRotation();
                }
            }
            else {
                if (!positionRoom.GetPositionState(currentRoom, currentRoomNumber, nextPosition)) {
                    if (currentRoomNumber >= 2 && currentRoomNumber <= 11) {
                        while (roomStatsArray.GetNextRoom(currentRoomNumber - 1).IsLocked() && currentRoomNumber <= 11) {
                            currentRoomNumber++;
                            if(currentRoomNumber == 12){
                                break;
                            }
                        }
                    }
                    if(currentRoomNumber < 12)
                        currentRoomStats = roomStatsArray.GetNextRoom(currentRoomNumber - 1);

                    currentRoomNumber++;
                    positionRoom.SetEmpty(currentRoom, currentPosition);
                    currentRoom = positionRoom.ChangeRoom(currentRoomNumber);

                    nextPosition = 1;
                    currentPosition = 0;
                    transform.position = currentRoom[currentPosition].position;

                    guestRotate();

                    positionRoom.SetBusy(currentRoom, currentPosition);
                }else {
                    guestResetRotation();
                }
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
        spriteNumber = number;
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

    public void GuestScare() {
        switch (spriteNumber) {
            case 1:
                spriteRender.sprite = spritesScare[0];
                break;
            case 2:
                spriteRender.sprite = spritesScare[1];
                break;
            case 3:
                spriteRender.sprite = spritesScare[2];
                break;
            case 4:
                spriteRender.sprite = spritesScare[3];
                break;
        }
    }
    
    public void GuestResetSprite() {
        switch (spriteNumber) {
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
        String nameRoom = CheckPosition(currentRoomNumber);
        timerToExecute = currentRoomStats.GetCompletionTime();

        if (!nameRoom.Equals("Null")) {
            if (currentPosition == 4) {
                if (executing == false) {
                    timerImageController.TimerON(currentRoomNumber, timerToExecute);
                }
                executing = true;
            }
        }
    }
    
    public string CheckPosition(int RoomNumber) {
        if (RoomNumber == 2) {
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
            return "Null";
        }
    }
}
