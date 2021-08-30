using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRoom : MonoBehaviour
{
    public string monsterName;
    
    public int incomeLevel = 0;
    public int bankLevel = 0;

    public int baseIncomeCost;
    public int baseBankCost;
    public int baseIncomeRate;
    public int baseBankSize;

    public float incomeCostMultiplier;
    public float bankCostMultiplier;

    public int currentIncomeRate;
    public int currentIncomeCost;
    public int currentBankSize;
    public int currentBankCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateMoney()
    {
        
    }

    private void GetStoredMoney()
    {
        
    }

    private void UpgradeIncome()
    {
        incomeLevel += 1;
        currentIncomeCost = UpgradeCost(incomeLevel, baseIncomeCost, incomeCostMultiplier);
        UpdateIncomeRate();
    }

    private void UpgradeBank()
    {
        bankLevel += 1;
        currentBankCost = UpgradeCost(bankLevel, baseBankCost, bankCostMultiplier);
        UpdateBankSize();
    }

    private int UpgradeCost(int level, int baseCost, float multiplier)
    {
        return (int) Math.Round(baseCost * Mathf.Pow(multiplier, level));
    }

    private void UpdateIncomeRate()
    {
        currentIncomeRate = baseIncomeRate * incomeLevel;
    }

    private void UpdateBankSize()
    {
        currentBankSize = baseBankSize * bankLevel;
    }
    
}
