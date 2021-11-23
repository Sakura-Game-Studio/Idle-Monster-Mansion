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
        
        if (PlayerPrefs.HasKey(roomName + "locked")) {
            int lockedSave = PlayerPrefs.GetInt(roomName + "locked");
            if (lockedSave == 1) {
                UnlockSave();
            }
        }
    }

    public float GetCompletionTime() {
        return currentCompletionTime;
    }
    
    public void UpdateCompletionTime() {
        currentCompletionTime = baseCompletionTime - (level / completionTimeMultiplier);
    }

    public float GetNextCompletionTime()
    {
        return baseCompletionTime - ((level + 1) / completionTimeMultiplier);
    }

    public double GetUpgradeTimeDifference()
    {
        return Math.Round(GetNextCompletionTime() - GetCompletionTime(), 2);
    }

    public double GetIncomeRate() {
        return currentIncomeRate;
    }

    public void UpdateIncomeRate() {
        currentIncomeRate = baseIncomeRate * level;
        currentIncomeRate = Math.Round(currentIncomeRate, 2);
    }

    public double GetNextIncomeRate()
    {
        return baseIncomeRate * (level+1);
    }

    public double GetUpgradeIncomeDifference()
    {
        return Math.Round(GetNextIncomeRate() - GetIncomeRate(), 2);
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
        if (CanUpgrade()) {
            CurrencyManager.Instance.ChangeMoney(-currentCostUpgrade);
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
        if (CanUnlock()){
            CurrencyManager.Instance.ChangeMoney(-costToUnlock);
            locked = false;
            PlayerPrefs.SetInt(roomName + "locked", 1);
            var tempColor = lockedImage.color;
            tempColor.a = 0;
            lockedImage.color = tempColor;
        }
    }

    public void UnlockSave() {
        locked = false;
        var tempColor = lockedImage.color;
        tempColor.a = 0;
        lockedImage.color = tempColor;
    }

    public bool CanUpgrade()
    {
        if (CurrencyManager.Instance.HasUpgradeCost(currentCostUpgrade) && level < 100)
            return true;
        return false;
    }

    public bool CanUnlock()
    {
        if (CurrencyManager.Instance.HasUnlockCost(costToUnlock) && !previousRoom.IsLocked())
            return true;
        return false;
    }
}
