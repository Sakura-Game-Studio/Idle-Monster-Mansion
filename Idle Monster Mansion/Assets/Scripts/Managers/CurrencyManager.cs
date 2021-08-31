using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager current;

    public int TotalSoftCurrency = 0;

    [SerializeField] private TextMeshProUGUI totalSoftCurrencyText;
    
    // Start is called before the first frame update
    void Start()
    {
        current = this;
        totalSoftCurrencyText.text = "" + TotalSoftCurrency;
    }

    public void AddSoftCurrency(int amount)
    {
        TotalSoftCurrency += amount;
        totalSoftCurrencyText.text = "" + TotalSoftCurrency;
    }

    public bool HasMoney(int amount)
    {
        if (TotalSoftCurrency >= amount)
            return true;
        return false;
    }
    
}
