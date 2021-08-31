using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterRoom : MonoBehaviour
{
    public int id;
    
    public string monsterName;
    public int moneyInBank;
    
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

    private float _nextTimeForIncome = 0f;

    [SerializeField] private TextMeshProUGUI incomeRateUpgradeText;
    [SerializeField] private TextMeshProUGUI incomeRateUpgradeCost;
    [SerializeField] private TextMeshProUGUI bankSizeUpgradeText;
    [SerializeField] private TextMeshProUGUI bankSizeUpgradeCost;
    [SerializeField] private TextMeshProUGUI moneyInStorageText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        UpdateCanvasUI();
    }

    // Update is called once per frame
    void Update()
    {
        GenerateMoney();
    }

    private void UpdateCanvasUI()
    {
        moneyInStorageText.text = "" + moneyInBank + "/" + currentBankSize;
        
        incomeRateUpgradeCost.text = "" + currentIncomeCost;
        incomeRateUpgradeText.text = currentIncomeRate + "/s -> " + GetNextIncomeRate() + "/s";

        bankSizeUpgradeCost.text = "" + currentBankCost;
        bankSizeUpgradeText.text = currentBankSize + " -> " + GetNextBankSize();
    }

    private void GenerateMoney()
    {
        if (incomeLevel > 0 && bankLevel > 0)
        {
            if (Time.time >= _nextTimeForIncome)
            {
                _nextTimeForIncome = Time.time + 1f;

                if (moneyInBank >= currentBankSize)
                    return;

                var bankSizeLeft = currentBankSize - moneyInBank;
                if (bankSizeLeft >= currentIncomeRate)
                    moneyInBank += currentIncomeRate;
                else
                    moneyInBank = currentBankSize;
                moneyInStorageText.text = "" + moneyInBank + "/" + currentBankSize;
            }
        }
    }

    public void GetStoredMoney()
    {
        Debug.Log("Getting Money");
        CurrencyManager.current.AddSoftCurrency(moneyInBank);
        moneyInBank = 0;
        moneyInStorageText.text = "" + moneyInBank + "/" + currentBankSize;
    }

    public void UnlockRoom()
    {
        UpgradeBank();
        UpgradeIncome();
    }

    public void UpgradeIncome()
    {
        if (CurrencyManager.current.HasMoney(currentIncomeCost))
        {
            CurrencyManager.current.AddSoftCurrency(-currentIncomeCost);
            incomeLevel += 1;
            currentIncomeCost = UpgradeCost(incomeLevel, baseIncomeCost, incomeCostMultiplier);
            UpdateIncomeRate();
            incomeRateUpgradeCost.text = "" + currentIncomeCost;
            incomeRateUpgradeText.text = currentIncomeRate + "/s -> " + GetNextIncomeRate() + "/s";
        }
    }

    public void UpgradeBank()
    {
        if (CurrencyManager.current.HasMoney(currentBankCost))
        {
            CurrencyManager.current.AddSoftCurrency(-currentBankCost);
            bankLevel += 1;
            currentBankCost = UpgradeCost(bankLevel, baseBankCost, bankCostMultiplier);
            UpdateBankSize();
            bankSizeUpgradeCost.text = "" + currentBankCost;
            bankSizeUpgradeText.text = currentBankSize + " -> " + GetNextBankSize();
        }
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

    private int GetNextIncomeRate()
    {
        return baseIncomeRate * (incomeLevel + 1);
    }

    private int GetNextBankSize()
    {
        return baseBankSize * (bankLevel + 1);
    }
    
}
