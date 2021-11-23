using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    
    public double currentMoney;

    [SerializeField] private TextMeshProUGUI _currentMoneyText;

    private void Start()
    {
        Instance = this;
    	if (PlayerPrefs.HasKey("Money")) {
            currentMoney = Convert.ToDouble(PlayerPrefs.GetString("Money"));
            _currentMoneyText.text = $"{currentMoney}g";
        }
    }

    public void EarnMoney(RoomSettings roomSettings) {
        currentMoney += roomSettings.GetIncomeRate();
        currentMoney = Math.Round(currentMoney, 2);
        Debug.Log(currentMoney);
        _currentMoneyText.text = $"{currentMoney}g";
        MonsterRoomUpgradeScreen.Instance.EarnedMoney();
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
        _currentMoneyText.text = $"{currentMoney}g";
        Debug.Log(currentMoney);
        SaveMoney();

    }
}
