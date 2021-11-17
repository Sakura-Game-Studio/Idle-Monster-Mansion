using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

    public double currentMoney;

    public void EarnMoney(RoomSettings roomSettings) {
        currentMoney += roomSettings.GetIncomeRate();
        Debug.Log(currentMoney);
    }
}