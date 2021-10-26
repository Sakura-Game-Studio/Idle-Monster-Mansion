using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestSpawner : MonoBehaviour {

    public GameObject guest;
    public float timeToSpawn;
    public float currentTime = 0;

    private GameObject gameController;
    private RoomsPositions positionRoom;
    
    // Start is called before the first frame update
    void Start() {
        gameController = GameObject.Find("Game Controller");
        positionRoom = gameController.GetComponent<RoomsPositions>();
        
        timeToSpawn = (int)Random.Range(5, 10);
        Instantiate(guest);
    }

    // Update is called once per frame
    void FixedUpdate() {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToSpawn) {
            currentTime = 0;
            timeToSpawn = (int)Random.Range(5, 10);
            if (!positionRoom.GetIntialPosition()) {
                Instantiate(guest);
            }
        }
    }
}
