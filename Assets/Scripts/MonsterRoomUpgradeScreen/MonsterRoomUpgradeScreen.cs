using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterRoomUpgradeScreen : MonoBehaviour
{
    [Header("Basic Info")]
    [SerializeField] private TextMeshProUGUI _monsterName;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _monsterIcon;
    
    [Header("Stats Info")]
    [SerializeField] private TextMeshProUGUI _currentIncome;
    [SerializeField] private TextMeshProUGUI _currentTime;
    [SerializeField] private TextMeshProUGUI _currentCapacity;

    [SerializeField] private TextMeshProUGUI _upgradeIncome;
    [SerializeField] private TextMeshProUGUI _upgradeTime;
    [SerializeField] private TextMeshProUGUI _upgradeCapacity;

    [Header("Upgrade Button")] 
    [SerializeField] private Button _upgradeButton;

    [SerializeField] private Color _upgradeAvailableColor = Color.green;
    [SerializeField] private Color _notAvailableColor = Color.red;

    
    
    
    
    
}
