using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRoomManager : MonoBehaviour
{
    private static MonsterRoomManager _instance;
    
    public MonsterRoomManager GetInstance()
    {
        if (_instance == null)
            _instance = this;
        return _instance;
    }

    [SerializeField]
    private MonsterRoom[] _monsterRooms;


    public void GenerateMoney(MonsterRoom room)
    {
        CurrencyManager.current.TotalSoftCurrency += room.getCurrentIncomeRate();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
