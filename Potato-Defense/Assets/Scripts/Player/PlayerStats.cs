﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // public AudioSource buyingSoundEffect;
    SoundEffectManager sound;

    public static float movementSpeed = 2.0f;
    public static float farmingSpeed = 2.0f;
    public static float attackPower = 2.0f;
    public static float repair = 2.0f;
    
    //skill points should get from PlayerMovement.cs
    public static int skillPoint = 3;
    private static int startPoints = 3;

    //counter for how many upgrade player has clicked
    //indicator for minus functions and changing progress bars' assets
    private int movementLevel = 0;
    private int farmingLevel = 0;
    private int attackLevel = 0;
    private int carpenterLevel = 0;

    //put asset in editor
    public Sprite levelZero;
    public Sprite levelOne;
    public Sprite levelTwo;
    public Sprite levelThree;

    public GameObject progressBarMovement;
    public GameObject progressBarFarm;
    public GameObject progressBarAttack;
    public GameObject progressBarCarpenter;

    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<SoundEffectManager>();
    }
    public static void restart()
    {
        skillPoint = startPoints;
        movementSpeed = 2.0f;
        farmingSpeed = 2.0f;
        attackPower = 2.0f;
        repair = 2.0f;
    }


    void Update()
    {
        changingAssetMoving();
        changingAssetFarming();
        changingAssetAttacking();
        changingAssetCarpenter();

    
    }

    public PlayerStats()
    {
    }

    public void addSkillPoints(int pointsEarned)
    {
        skillPoint += pointsEarned;
    }

    //upgrading functions, put these funciton onto the buttons
    //need to have if statement to check for skillpoints
    public void upgradeMoving()
    {
        if (skillPoint > 0 && movementLevel < 3) 
        {
            movementSpeed += 0.5f;
            skillPoint -= 1;
            movementLevel += 1;           
            //Debug.Log("movement level is " + movementLevel);
        }
        sound.playBAU();
        //buyingSoundEffect.Play();
    }
    public void upgradeFarming()
    {
        if (skillPoint > 0 && farmingLevel < 3)
        {
            farmingSpeed += 0.5f;
            skillPoint -= 1;
            farmingLevel += 1;
        }
        sound.playBAU();
        // buyingSoundEffect.Play();
    }
    public void upgradeAttacking()
    {
        if (skillPoint > 0 && attackLevel < 3)
        {
            attackPower += 0.5f;
            skillPoint -= 1;
            attackLevel +=1;
        }
        sound.playBAU();
        // buyingSoundEffect.Play();

    }
    public void upgradeCarpenter()
    {
        if (skillPoint > 0 && carpenterLevel < 3)
        {
            repair += 2f;
            skillPoint -= 1;
            carpenterLevel +=1;

        }
        sound.playBAU();
        // buyingSoundEffect.Play();
    }

    //minus player stats function
    public void minusMoving()
    {
        if (movementLevel >0)
        {
            movementSpeed -= 0.5f;
            skillPoint += 1;
            movementLevel -= 1;
            //Debug.Log("movement level is " + movementLevel);
        }
        sound.playBAU();
        // buyingSoundEffect.Play();
    }
    public void minusFarming()
    {
        if (farmingLevel >0)
        {
            farmingSpeed -= 0.5f;
            skillPoint += 1;
            farmingLevel -= 1;
        }
        sound.playBAU();
        // buyingSoundEffect.Play();
    }
    public void minusAttacking()
    {
        if (attackLevel >0)
        {
            attackPower -= 0.5f;
            skillPoint += 1;
            attackLevel -= 1;
        }
        sound.playBAU();
        //  buyingSoundEffect.Play();
    }
    public void minusCarpenter()
    {
        if (carpenterLevel >0)
        {
            repair -= 2f;
            skillPoint += 1;
            carpenterLevel -= 1;
        }
        sound.playBAU();
        // buyingSoundEffect.Play();
    }

    //changing progress bars' assets funtions
    public void changingAssetMoving()
    {
        if (movementLevel == 0)
        {
            progressBarMovement.gameObject.GetComponent<SpriteRenderer>().sprite = levelZero;
        }
        else if (movementLevel == 1)
        {
            progressBarMovement.gameObject.GetComponent<SpriteRenderer>().sprite = levelOne;
            
        }
        else if (movementLevel == 2)
        {
            progressBarMovement.gameObject.GetComponent<SpriteRenderer>().sprite = levelTwo;
        }
        else if (movementLevel == 3)
        {
            progressBarMovement.gameObject.GetComponent<SpriteRenderer>().sprite = levelThree;
        }

    }

    public void changingAssetFarming()
    {
      if(farmingLevel ==0)
        {
            progressBarFarm.gameObject.GetComponent<SpriteRenderer>().sprite = levelZero;
        }
      else if (farmingLevel == 1)
        {
            progressBarFarm.gameObject.GetComponent<SpriteRenderer>().sprite = levelOne;
        }
      else if (farmingLevel == 2)
        {
            progressBarFarm.gameObject.GetComponent<SpriteRenderer>().sprite = levelTwo;
        }
      else if (farmingLevel == 3)
        {
            progressBarFarm.gameObject.GetComponent<SpriteRenderer>().sprite = levelThree;
        }

    }

    public void changingAssetAttacking()
    {
        if (attackLevel == 0)
        {
            progressBarAttack.gameObject.GetComponent<SpriteRenderer>().sprite = levelZero;
        }
        else if (attackLevel == 1)
        {
            progressBarAttack.gameObject.GetComponent<SpriteRenderer>().sprite = levelOne;
        }
        else if (attackLevel == 2)
        {
            progressBarAttack.gameObject.GetComponent<SpriteRenderer>().sprite = levelTwo;
        }
        else if (attackLevel == 3)
        {
            progressBarAttack.gameObject.GetComponent<SpriteRenderer>().sprite = levelThree;
        }
    }

    public void changingAssetCarpenter()
    {
        if (carpenterLevel == 0)
        {
            progressBarCarpenter.gameObject.GetComponent<SpriteRenderer>().sprite = levelZero;
        }
        else if (carpenterLevel == 1)
        {
            progressBarCarpenter.gameObject.GetComponent<SpriteRenderer>().sprite = levelOne;
        }
        else if (carpenterLevel == 2)
        {
            progressBarCarpenter.gameObject.GetComponent<SpriteRenderer>().sprite = levelTwo;
        }
        else if (carpenterLevel == 3)
        {
            progressBarCarpenter.gameObject.GetComponent<SpriteRenderer>().sprite = levelThree;
        }
    }

    public int returnSkillPoint()
    {
        return skillPoint;
    }
}

