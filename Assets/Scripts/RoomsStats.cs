using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsStats : MonoBehaviour
{
    public static RoomsStats Instance;
    
    public RoomSettings[] roomSettingsArray;

    private void Start()
    {
        Instance = this;
    }

    public RoomSettings getRoomSettings(int roomNumber) {
        return roomSettingsArray[roomNumber];
    }

    public RoomSettings SetupStats() {
        return roomSettingsArray[0];
    }

    public RoomSettings GetNextRoom(int roomNumber) {
        return roomSettingsArray[roomNumber];
    }
}
