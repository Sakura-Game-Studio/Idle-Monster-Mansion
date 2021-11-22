using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

    public double currentMoney;

    public void EarnMoney(RoomSettings roomSettings) {
        currentMoney += roomSettings.GetIncomeRate();
        currentMoney = Math.Round(currentMoney, 2);
        Debug.Log(currentMoney);
    }

    public bool HasUpgradeCost(double costToUpgrade) {
        if (currentMoney >= costToUpgrade) {
            currentMoney -= costToUpgrade;
            currentMoney = Math.Round(currentMoney, 2);
            return true;
        }
        return false;
    }

    public bool HasUnlockCost(double unlockCost) {
        if (currentMoney >= unlockCost) {
            currentMoney -= unlockCost;
            currentMoney = Math.Round(currentMoney, 2);
            return true;
        }
        return false;
    }
}
