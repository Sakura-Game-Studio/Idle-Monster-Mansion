using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DesignerMonsterRoom", menuName = "ScriptableObjects/DesignerMonsterRoom", order = 1)]
public class DesignerMonsterRoom : ScriptableObject
{
    public string monsterName;

    public int costToUnlock;

    public int baseIncomeCost;
    public int baseIncome;
    public float incomeCostMultiplier;

    public float baseCompletionTime;
    public float completionTimeMultiplier;

    

}
