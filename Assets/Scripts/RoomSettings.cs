using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSettings : MonoBehaviour {
    public string roomName;
    
    public int costToUnlock;
    public bool locked;

    public int level = 1;
    
    public int baseCost;
    public int baseIncomeRate;
    
    public float incomeCostMultiplier = 1.1f;

    public float baseCompletionTime;
    public float completionTimeMultiplier;
    
    public int currentIncomeCost;
    public int currentIncomeRate;
    public float currentCompletionTime;

    private void Start() {
        UpdateCompletionTime();
    }

    public float GetCompletionTime() {
        return currentCompletionTime;
    }
    
    public void UpdateCompletionTime() {
        currentCompletionTime = baseCompletionTime * (level /completionTimeMultiplier);
    }
}
