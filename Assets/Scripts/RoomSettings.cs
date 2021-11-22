using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start() {
        currentCompletionTime = baseCompletionTime;
        currentCostUpgrade = baseCost;
        currentIncomeRate = baseIncomeRate;
        
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
        currentCostUpgrade = baseCost * (Mathf.Pow(incomeCostMultiplier, level));
        currentCostUpgrade = Math.Round(currentCostUpgrade, 2);
    }

    public int getLevel() {
        return level;
    }

    public void UpdateLevel() {
        level++;
    }

    public void UpgradeRoom() {
        if (currencyManager.HasUpgradeCost(currentCostUpgrade) && level < 100) {
            UpdateUpgradeCost();
            UpdateLevel();
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
