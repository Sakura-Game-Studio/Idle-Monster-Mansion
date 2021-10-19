using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DesignerMonsterRoom", menuName = "ScriptableObjects/DesignerMonsterRoom", order = 1)]
public class DesignerMonsterRoom : ScriptableObject
{
    public string monsterName;
    
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
}
