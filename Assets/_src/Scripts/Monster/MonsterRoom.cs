using System;
using TMPro;
using UnityEngine;

public class MonsterRoom : MonoBehaviour
{
    public int id;

    [SerializeField] private DesignerMonsterRoom _roomStats;

    public int incomeLevel = 0;

    public int baseIncomeCost;
    public int baseIncomeRate;

    public float incomeCostMultiplier;

    public int currentIncomeRate;
    public int currentIncomeCost;

    [SerializeField] private TextMeshProUGUI incomeRateUpgradeText;
    [SerializeField] private TextMeshProUGUI incomeRateUpgradeCost;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMoney()
    {
        
    }

    public void UnlockRoom()
    {
        UpgradeIncome();
    }

    public void UpgradeIncome()
    {
        if (CurrencyManager.current.HasMoney(currentIncomeCost))
        {
            CurrencyManager.current.AddSoftCurrency(-currentIncomeCost);
            incomeLevel += 1;
            currentIncomeCost = UpgradeCost(incomeLevel, _roomStats.baseIncomeCost, _roomStats.incomeCostMultiplier);
            UpdateIncomeRate();
            incomeRateUpgradeCost.text = "" + currentIncomeCost;
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
    
    private int GetNextIncomeRate()
    {
        return baseIncomeRate * (incomeLevel + 1);
    }

}
