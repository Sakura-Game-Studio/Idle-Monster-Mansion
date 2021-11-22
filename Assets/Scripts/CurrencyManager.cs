using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    
    public double currentMoney;

    private void Start()
    {
    	if (PlayerPrefs.HasKey("Money")) {
            currentMoney = Convert.ToDouble(PlayerPrefs.GetString("Money"));
        }
        Instance = this;
    }

    public void EarnMoney(RoomSettings roomSettings) {
        currentMoney += roomSettings.GetIncomeRate();
        currentMoney = Math.Round(currentMoney, 2);
        SaveMoney();
        Debug.Log(currentMoney);
        SaveMoney();
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


    public void SaveMoney() {
        String money = currentMoney.ToString();
        PlayerPrefs.SetString("Money", money);
	}
	
    public void ChangeMoney(double amount)
    {
        currentMoney += amount;
        currentMoney = Math.Round(currentMoney, 2);
        MonsterRoomUpgradeScreen.Instance.EarnedMoney();
        Debug.Log(currentMoney);
        SaveMoney();

    }
}
