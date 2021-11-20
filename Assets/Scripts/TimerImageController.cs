using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerImageController : MonoBehaviour {
    public Image receptionImage, room01Image, room02Image, room03Image, room04Image, room05Image, room06Image, room07Image, room08Image, room09Image, room10Image;
    private float receptionTimer, room01Timer, room02Timer, room03Timer, room04Timer, room05Timer, room06Timer, room07Timer, room08Timer, room09Timer, room10Timer;

    private bool receptionActive = false;
    private bool room01Active = false;
    private bool room02Active = false;
    private bool room03Active = false;
    private bool room04Active = false;
    private bool room05Active = false;
    private bool room06Active = false;
    private bool room07Active = false;
    private bool room08Active = false;
    private bool room09Active = false;
    private bool room10Active = false;

    // Update is called once per frame
    void Update() {
        if (receptionActive) {
            receptionImage.fillAmount -= 1 / receptionTimer * Time.deltaTime;
            if (receptionImage.fillAmount <= 0) {
                receptionImage.fillAmount = 1;
                receptionImage.enabled = false;
                receptionActive = false;
            }
        }
        if (room01Active) {
            room01Image.fillAmount -= 1 / room01Timer * Time.deltaTime;
            if (room01Image.fillAmount <= 0) {
                room01Image.fillAmount = 1;
                room01Image.enabled = false;
                room01Active = false;
            }
        }
        if (room02Active) {
            room02Image.fillAmount -= 1 / room02Timer * Time.deltaTime;
            if (room02Image.fillAmount <= 0) {
                room02Image.fillAmount = 1;
                room02Image.enabled = false;
                room02Active = false;
            }
        }
        if (room03Active) {
            room03Image.fillAmount -= 1 / room03Timer * Time.deltaTime;
            if (room03Image.fillAmount <= 0) {
                room03Image.fillAmount = 1;
                room03Image.enabled = false;
                room03Active = false;
            }
        }
        if (room04Active) {
            room04Image.fillAmount -= 1 / room04Timer * Time.deltaTime;
            if (room04Image.fillAmount <= 0) {
                room04Image.fillAmount = 1;
                room04Image.enabled = false;
                room04Active = false;
            }
        }
        if (room05Active) {
            room05Image.fillAmount -= 1 / room05Timer * Time.deltaTime;
            if (room05Image.fillAmount <= 0) {
                room05Image.fillAmount = 1;
                room05Image.enabled = false;
                room05Active = false;
            }
        }
        if (room06Active) {
            room06Image.fillAmount -= 1 / room06Timer * Time.deltaTime;
            if (room06Image.fillAmount <= 0) {
                room06Image.fillAmount = 1;
                room06Image.enabled = false;
                room06Active = false;
            }
        }
        if (room07Active) {
            room07Image.fillAmount -= 1 / room07Timer * Time.deltaTime;
            if (room07Image.fillAmount <= 0) {
                room07Image.fillAmount = 1;
                room07Image.enabled = false;
                room07Active = false;
            }
        }
        if (room08Active) {
            room08Image.fillAmount -= 1 / room08Timer * Time.deltaTime;
            if (room08Image.fillAmount <= 0) {
                room08Image.fillAmount = 1;
                room08Image.enabled = false;
                room08Active = false;
            }
        }
        if (room09Active) {
            room09Image.fillAmount -= 1 / room09Timer * Time.deltaTime;
            if (room09Image.fillAmount <= 0) {
                room09Image.fillAmount = 1;
                room09Image.enabled = false;
                room09Active = false;
            }
        }
        if (room10Active) {
            room10Image.fillAmount -= 1 / room10Timer * Time.deltaTime;
            if (room10Image.fillAmount <= 0) {
                room10Image.fillAmount = 1;
                room10Image.enabled = false;
                room10Active = false;
            }
        }
    }

    public void TimerON(int currentRoomNumber, float timer) {
        switch (currentRoomNumber) {
            case 2:
                receptionTimer = timer;
                receptionImage.enabled = true;
                receptionActive = true;
                break;
            case 3:
                room01Timer = timer;
                room01Image.enabled = true;
                room01Active = true;
                break;
            case 4:
                room02Timer = timer;
                room02Image.enabled = true;
                room02Active = true;
                break;
            case 5:
                room03Timer = timer;
                room03Image.enabled = true;
                room03Active = true;
                break;
            case 6:
                room04Timer = timer;
                room04Image.enabled = true;
                room04Active = true;
                break;
            case 7:
                room05Timer = timer;
                room05Image.enabled = true;
                room05Active = true;
                break;
            case 8:
                room06Timer = timer;
                room06Image.enabled = true;
                room06Active = true;
                break;
            case 9:
                room07Timer = timer;
                room07Image.enabled = true;
                room07Active = true;
                break;
            case 10:
                room08Timer = timer;
                room08Image.enabled = true;
                room08Active = true;
                break;
            case 11:
                room09Timer = timer;
                room09Image.enabled = true;
                room09Active = true;
                break;
            case 12:
                room10Timer = timer;
                room10Image.enabled = true;
                room10Active = true;
                break;
        }
    }
}
