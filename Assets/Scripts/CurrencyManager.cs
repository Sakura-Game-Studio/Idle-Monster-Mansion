using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    
    public double currentMoney;

    private void Start()
    {
        Instance = this;
    }

    public void EarnMoney(RoomSettings roomSettings) {
        var money = roomSettings.GetIncomeRate();
        ChangeMoney(money);
    }

    public bool HasUpgradeCost(double costToUpgrade) {
        if (currentMoney >= costToUpgrade) 
            return true;
        return false;
    }

    public bool HasUnlockCost(double unlockCost) {
        if (currentMoney >= unlockCost) 
            return true;
        return false;
    }

    public void ChangeMoney(double amount)
    {
        currentMoney += amount;
        currentMoney = Math.Round(currentMoney, 2);
        MonsterRoomUpgradeScreen.Instance.EarnedMoney();
        Debug.Log(currentMoney);
    }
}
