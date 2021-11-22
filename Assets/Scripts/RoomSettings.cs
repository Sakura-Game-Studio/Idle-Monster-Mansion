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

    public RoomSettings previousRoom;

    private void Start() {
        currentCompletionTime = baseCompletionTime;
        currentCostUpgrade = baseCost;
        currentIncomeRate = baseIncomeRate;
        
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
        }
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
