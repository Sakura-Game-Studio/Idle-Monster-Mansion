using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour {
    public SpriteRenderer zombie, ghost, skeleton, vampire, demon, werewolf, mummy, scarecrow, slime, samara;
    
    public Sprite zombieSprite, zombieAttackSprite;
    public Sprite ghostSprite, ghostAttackSprite;
    public Sprite skeletonSprite, skeletonAttackSprite;
    public Sprite vampireSprite, vampireAttackSprite;
    public Sprite demonSprite, demonAttackSprite;
    public Sprite werewolfSprite, werewolfAttackSprite;
    public Sprite mummySprite, mummyAttackSprite;
    public Sprite scarecrowSprite, scarecrowAttackSprite;
    public Sprite slimeSprite, slimeAttackSprite;
    public Sprite samaraSprite, samaraAttackSprite;


    public void Scare(int currentRoomNumber) {
        switch (currentRoomNumber) {
            case 3:
                zombie.sprite = zombieAttackSprite;
                break;
            case 4:
                ghost.sprite = ghostAttackSprite;
                break;
            case 5:
                skeleton.sprite = skeletonAttackSprite;
                break;
            case 6:
                vampire.sprite = vampireAttackSprite;
                break;
            case 7:
                demon.sprite = demonAttackSprite;
                break;
            case 8:
                werewolf.sprite = werewolfAttackSprite;
                break;
            case 9:
                mummy.sprite = mummyAttackSprite;
                break;
            case 10:
                scarecrow.sprite = scarecrowAttackSprite;
                break;
            case 11:
                slime.sprite = slimeAttackSprite;
                break;
            case 12:
                samara.sprite = samaraAttackSprite;
                break;
        }
    }

    public void ResetScare(int currentRoomNumber) {
        switch (currentRoomNumber) {
            case 3:
                zombie.sprite = zombieSprite;
                break;
            case 4:
                ghost.sprite = ghostSprite;
                break;
            case 5:
                skeleton.sprite = skeletonSprite;
                break;
            case 6:
                vampire.sprite = vampireSprite;
                break;
            case 7:
                demon.sprite = demonSprite;
                break;
            case 8:
                werewolf.sprite = werewolfSprite;
                break;
            case 9:
                mummy.sprite = mummySprite;
                break;
            case 10:
                scarecrow.sprite = scarecrowSprite;
                break;
            case 11:
                slime.sprite = slimeSprite;
                break;
            case 12:
                samara.sprite = samaraSprite;
                break;
        }
    }
}
