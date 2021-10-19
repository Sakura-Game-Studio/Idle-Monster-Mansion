using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsPositions : MonoBehaviour {
    
    private Transform[] currentArray;
    
    public Transform[] entrancePositions;
    public Transform[] receptionPositions;
    public Transform[] room01Positions;
    public Transform[] room02Positions; 
    public Transform[] room03Positions; 
    public Transform[] room04Positions; 
    public Transform[] room05Positions; 
    public Transform[] room06Positions;
    public Transform[] room07Positions; 
    public Transform[] room08Positions; 
    public Transform[] room09Positions; 
    public Transform[] room10Positions;
    public Transform[] exitPositions;

    public bool[] entranceBusy;
    public bool[] receptionBusy;
    public bool[] room01Busy;
    public bool[] room02Busy; 
    public bool[] room03Busy; 
    public bool[] room04Busy; 
    public bool[] room05Busy; 
    public bool[] room06Busy;
    public bool[] room07Busy; 
    public bool[] room08Busy; 
    public bool[] room09Busy; 
    public bool[] room10Busy;
    public bool[] exitBusy;

    public Transform[] SetupPosition() {
        return entrancePositions;
    }

    public void SetBusy(Transform[] currentRoom, int currentRoomNumber) {
        if (currentRoom == entrancePositions) {
            entranceBusy[currentRoomNumber] = true;
        } else if (currentRoom == receptionPositions) {
            receptionBusy[currentRoomNumber] = true;
        } else if (currentRoom == room01Positions) {
            room01Busy[currentRoomNumber] = true;
        } else if (currentRoom == room02Positions) {
            room02Busy[currentRoomNumber] = true;
        }  else if (currentRoom == room03Positions) {
            room01Busy[currentRoomNumber] = true;
        } else if (currentRoom == room04Positions) {
            room01Busy[currentRoomNumber] = true;
        } else if (currentRoom == room05Positions) {
            room01Busy[currentRoomNumber] = true;
        } else if (currentRoom == room06Positions) {
            room01Busy[currentRoomNumber] = true;
        } else if (currentRoom == room07Positions) {
            room01Busy[currentRoomNumber] = true;
        } else if (currentRoom == room08Positions) {
            room01Busy[currentRoomNumber] = true;
        } else if (currentRoom == room09Positions) {
            room01Busy[currentRoomNumber] = true;
        } else if (currentRoom == room10Positions) {
            room01Busy[currentRoomNumber] = true;
        }else {
            exitBusy[currentRoomNumber] = true;
        }
    }
    
    public void SetEmpty(Transform[] currentRoom, int currentRoomNumber) {
        if (currentRoom == entrancePositions) {
            entranceBusy[currentRoomNumber] = false;
        } else if (currentRoom == receptionPositions) {
            receptionBusy[currentRoomNumber] = false;
        } else if (currentRoom == room01Positions) {
            room01Busy[currentRoomNumber] = false;
        } else if (currentRoom == room02Positions) {
            room02Busy[currentRoomNumber] = false;
        }  else if (currentRoom == room03Positions) {
            room01Busy[currentRoomNumber] = false;
        } else if (currentRoom == room04Positions) {
            room01Busy[currentRoomNumber] = false;
        } else if (currentRoom == room05Positions) {
            room01Busy[currentRoomNumber] = false;
        } else if (currentRoom == room06Positions) {
            room01Busy[currentRoomNumber] = false;
        } else if (currentRoom == room07Positions) {
            room01Busy[currentRoomNumber] = false;
        } else if (currentRoom == room08Positions) {
            room01Busy[currentRoomNumber] = false;
        } else if (currentRoom == room09Positions) {
            room01Busy[currentRoomNumber] = false;
        } else if (currentRoom == room10Positions) {
            room01Busy[currentRoomNumber] = false;
        }else {
            exitBusy[currentRoomNumber] = false;
        }
    }

    public bool GetPositionState(Transform[] currentRoom, int RoomNumber) {
        if (currentRoom == entrancePositions) {
            return entranceBusy[RoomNumber];
        } else if (currentRoom == receptionPositions) {
            return receptionBusy[RoomNumber];
        } else if (currentRoom == room01Positions) {
            return room01Busy[RoomNumber];
        } else if (currentRoom == room02Positions) {
            return room02Busy[RoomNumber];
        }  else if (currentRoom == room03Positions) {
            return room03Busy[RoomNumber];
        } else if (currentRoom == room04Positions) {
            return room04Busy[RoomNumber];
        } else if (currentRoom == room05Positions) {
            return room05Busy[RoomNumber];
        } else if (currentRoom == room06Positions) {
            return room06Busy[RoomNumber];
        } else if (currentRoom == room07Positions) {
            return room07Busy[RoomNumber];
        } else if (currentRoom == room08Positions) {
            return room08Busy[RoomNumber];
        } else if (currentRoom == room09Positions) {
            return room09Busy[RoomNumber];
        } else if (currentRoom == room10Positions) {
            return room10Busy[RoomNumber];
        }else {
            return exitBusy[RoomNumber];
        }
    }

    public Transform[] ChangeRoom(int currentRoomNumber) {
        Transform[] newArray = new Transform[]{};
        
        if (currentRoomNumber == 2) {
            newArray = receptionPositions;
        } else if (currentRoomNumber == 3) {
            newArray = room01Positions;
        } else if (currentRoomNumber == 4) {
            newArray = room02Positions;
        } else if (currentRoomNumber == 5) {
            newArray = room03Positions;
        } else if (currentRoomNumber == 6) {
            newArray = room04Positions;
        } else if (currentRoomNumber == 7) {
            newArray = room05Positions;
        } else if (currentRoomNumber == 8) {
            newArray = room06Positions;
        } else if (currentRoomNumber == 9) {
            newArray = room07Positions;
        } else if (currentRoomNumber == 10) {
            newArray = room08Positions;
        } else if (currentRoomNumber == 11) {
            newArray = room09Positions;
        } else if (currentRoomNumber == 12) {
            newArray = room10Positions;
        } else if (currentRoomNumber == 13) {
            newArray = exitPositions;
        } else {
            return null;
        }
        
        return newArray;
    }
}