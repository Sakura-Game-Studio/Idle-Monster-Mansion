using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSettings : MonoBehaviour {
    public string roomName;
    
    public int costToUnlock;
    public bool locked;

    public int level = 1;
    
    public double baseCost;
    public double baseIncomeRate;
    
    public float incomeCostMultiplier = 1.1f;

    public float baseCompletionTime;
    public float completionTimeMultiplier;
    
    public double currentCostUpgrade;
    public double currentIncomeRate;
    public float currentCompletionTime;

    private GameObject gameController;
    private CurrencyManager currencyManager;

    public RoomSettings previousRoom;

    public Image lockedImage;

    private void Start() {
        
        if (PlayerPrefs.HasKey(roomName)) {
            level = PlayerPrefs.GetInt(roomName);
            UpdateUpgradeCost();
            UpdateIncomeRate();
            UpdateCompletionTime();
        }else {
            currentCompletionTime = baseCompletionTime;
            currentCostUpgrade = baseCost;
            currentIncomeRate = baseIncomeRate;
        }

        gameController = GameObject.Find("Game Controller");
        currencyManager = gameController.GetComponent<CurrencyManager>();
    }

    public float GetCompletionTime() {
        return currentCompletionTime;
    }
    
    public void UpdateCompletionTime() {
        currentCompletionTime = baseCompletionTime - (level / completionTimeMultiplier);
    }

    public double GetIncomeRate() {
        return currentIncomeRate;
    }

    public void UpdateIncomeRate() {
        currentIncomeRate = baseIncomeRate * level;
        currentIncomeRate = Math.Round(currentIncomeRate, 2);
    }

    public double GetUpgradeCost() {
        return currentCostUpgrade;
    }
    
    public void UpdateUpgradeCost() {
        currentCostUpgrade = baseCost * (Mathf.Pow(incomeCostMultiplier, level - 1));
        currentCostUpgrade = Math.Round(currentCostUpgrade, 2);
    }

    public int getLevel() {
        return level;
    }

    public void UpdateLevel() {
        level++;
        PlayerPrefs.SetInt(roomName, level);
    }

    public void UpgradeRoom() {
        if (currencyManager.HasUpgradeCost(currentCostUpgrade) && level < 100) {
            UpdateLevel();
            UpdateUpgradeCost();
            UpdateIncomeRate();
            UpdateCompletionTime();
        }
    }

    public bool IsLocked() {
        return locked;
    }

    public void Unlock() {
        if (currencyManager.HasUnlockCost(costToUnlock) && !previousRoom.IsLocked()){
            locked = false;
            var tempColor = lockedImage.color;
            tempColor.a = 0;
            lockedImage.color = tempColor;
        }
    }
    
    public void ClickMouse() {
        if (IsLocked()) {
            Unlock();
        }else {
            UpgradeRoom();
        }
    }
}
