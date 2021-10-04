using System;
using TMPro;
using UnityEngine;

public class MonsterRoom : MonoBehaviour
{
    public int id;

    [SerializeField] private DesignerMonsterRoom _roomStats;

    [SerializeField] private TextMeshProUGUI incomeRateUpgradeText;
    [SerializeField] private TextMeshProUGUI incomeRateUpgradeCost;

    // Start is called before the first frame update
    void Start() {
        UpgradeCost();
        UpdateIncomeRate();
    }

    public void GenerateMoney()
    {
        CurrencyManager.current.TotalSoftCurrency += getCurrentIncomeRate();
    }

    public void UnlockRoom()
    {
        if (CurrencyManager.current.HasMoney(_roomStats.costToUnlock)) {
            CurrencyManager.current.AddSoftCurrency(-_roomStats.costToUnlock);
            _roomStats.locked = false;
        }
    }

    public void UpgradeIncome()
    {
        if (CurrencyManager.current.HasMoney(_roomStats.currentIncomeCost) && !_roomStats.locked)
        {
            CurrencyManager.current.AddSoftCurrency(-_roomStats.currentIncomeCost);
            _roomStats.level += 1;
            UpgradeCost();
            UpdateIncomeRate();
            UpdateCompletionTime();
            incomeRateUpgradeCost.text = "" + _roomStats.currentIncomeCost;
        }
    }

    private void UpgradeCost()
    {
        _roomStats.currentIncomeCost = (int) Math.Round(_roomStats.baseCost * Mathf.Pow(_roomStats.incomeCostMultiplier, _roomStats.level));
    }

    private void UpdateIncomeRate()
    {
        _roomStats.currentIncomeRate = _roomStats.baseIncomeRate * _roomStats.level;
    }
    
    private int GetNextIncomeRate() {
        return _roomStats.baseIncomeRate * (_roomStats.level + 1);
    }

    public int getCurrentIncomeRate() {
        return _roomStats.currentIncomeRate;
    }

    public void UpdateCompletionTime() {
        _roomStats.currentCompletionTime =
            _roomStats.baseCompletionTime * (_roomStats.level / _roomStats.completionTimeMultiplier);
    }
}
