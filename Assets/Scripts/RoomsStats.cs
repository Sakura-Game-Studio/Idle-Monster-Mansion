using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsStats : MonoBehaviour {
    public RoomSettings[] roomSettingsArray;

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
