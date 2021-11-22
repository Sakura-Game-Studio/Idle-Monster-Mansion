using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

    public double currentMoney;

    private void Start() {
        if (PlayerPrefs.HasKey("Money")) {
            currentMoney = Convert.ToDouble(PlayerPrefs.GetString("Money"));
        }
    }

    public void EarnMoney(RoomSettings roomSettings) {
        currentMoney += roomSettings.GetIncomeRate();
        currentMoney = Math.Round(currentMoney, 2);
        SaveMoney();
        Debug.Log(currentMoney);
    }

    public bool HasUpgradeCost(double costToUpgrade) {
        if (currentMoney >= costToUpgrade) {
            currentMoney -= costToUpgrade;
            currentMoney = Math.Round(currentMoney, 2);
            SaveMoney();
            return true;
        }
        return false;
    }

    public bool HasUnlockCost(double unlockCost) {
        if (currentMoney >= unlockCost) {
            currentMoney -= unlockCost;
            currentMoney = Math.Round(currentMoney, 2);
            SaveMoney();
            return true;
        }
        return false;
    }

    public void SaveMoney() {
        String money = currentMoney.ToString();
        PlayerPrefs.SetString("Money", money);
    }
}
