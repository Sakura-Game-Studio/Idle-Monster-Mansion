using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterRoomUpgradeScreen : MonoBehaviour
{
    public static MonsterRoomUpgradeScreen Instance;
    
    [SerializeField] private GameObject _upgradePanel;
    
    [Header("Close Panel")] [SerializeField]
    private Button _closeButton;
    
    [Header("Basic Info")] [SerializeField]
    private TextMeshProUGUI _monsterName;

    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _monsterIcon;

    [Header("Stats Info")] [SerializeField]
    private TextMeshProUGUI _currentIncome;

    [SerializeField] private TextMeshProUGUI _currentTime;
    [SerializeField] private TextMeshProUGUI _currentCapacity;

    [SerializeField] private TextMeshProUGUI _upgradeIncome;
    [SerializeField] private TextMeshProUGUI _upgradeTime;
    [SerializeField] private TextMeshProUGUI _upgradeCapacity;

    [Header("Upgrade Button")] 
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TextMeshProUGUI _upgradeButtonText;
    [SerializeField] private TextMeshProUGUI _upgradeCostText;

    [SerializeField] private Color _upgradeAvailableColor = Color.green;
    [SerializeField] private Color _notAvailableColor = Color.red;

    private int _roomId = 1;
    private bool _isOpen;

    private void Start()
    {
        Instance = this;
        _closeButton.onClick.AddListener(ClosePanel);
        _upgradeButton.onClick.AddListener(UpgradeRoom);
    }

    public void EarnedMoney()
    {
        if (_isOpen)
        {
            ConfigureButtonColor();
        }
    }

    public void TogglePanel(int index)
    {
        if (_isOpen)
        {
            if (index == _roomId) 
                ClosePanel();
            else
            {
                OpenPanel(index);
            }
        }
        else
        {
            OpenPanel(index);
        }
    }
    
    private void OpenPanel(int index)
    {
        _isOpen = true;
        _roomId = index;
        ConfigureRoomInfo();
        _upgradePanel.gameObject.SetActive(true);
    }

    private void ClosePanel()
    {
        _isOpen = false;
        _upgradePanel.gameObject.SetActive(false);
    }

    private void ConfigureRoomInfo()
    {
        RoomSettings room = RoomsStats.Instance.getRoomSettings(_roomId);

        _monsterName.text = $"{room.roomName} - lv{room.level}";
        _description.text = $"Room {_roomId} for {room.name}";
        
        ConfigureButtonColor();
        
        if (room.IsLocked())
        {
            _currentIncome.text = "0g";
            _upgradeIncome.text = $"{room.baseIncomeRate}g";
            _currentTime.text = "--s";
            _upgradeTime.text = $"{room.baseCompletionTime}";

            _upgradeButtonText.text = "UNLOCK!";
            _upgradeCostText.text = $"{room.costToUnlock}g";
        }
        else
        {
            _currentIncome.text = $"{room.GetIncomeRate()}g";
            _upgradeIncome.text = $"+{room.GetUpgradeIncomeDifference()}g";
            double completionTime = Math.Round(room.GetCompletionTime(), 2);
            _currentTime.text = $"{completionTime}s";
            _upgradeTime.text = $"{room.GetUpgradeTimeDifference()}s";
            
            _upgradeButtonText.text = "UPGRADE!";
            _upgradeCostText.text = $"{room.GetUpgradeCost()}g";
        }
    }

    private void ConfigureButtonColor()
    {
        var room = RoomsStats.Instance.getRoomSettings(_roomId);
        if (room.IsLocked())
        {
            _upgradeButton.image.color = room.CanUnlock() ? _upgradeAvailableColor : _notAvailableColor;
        }
        else
        {
            _upgradeButton.image.color = room.CanUpgrade() ? _upgradeAvailableColor : _notAvailableColor;
        }
    }


    private void UpgradeRoom()
    {
        var room = RoomsStats.Instance.getRoomSettings(_roomId);

        if (room.IsLocked())
        {
            room.Unlock();
            ConfigureRoomInfo();
        }
        else
        {
            room.UpgradeRoom();
            ConfigureRoomInfo();
        }
    }






}
