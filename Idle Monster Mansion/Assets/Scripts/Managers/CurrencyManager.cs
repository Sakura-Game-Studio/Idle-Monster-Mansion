using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager current;

    public int TotalSoftCurrency = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }
    
    public void AddSoftCurrency(int ammount)
    {
        TotalSoftCurrency += ammount;
    }

    
    
}
