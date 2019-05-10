﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Selection_Controller_Player2 : MonoBehaviour
{
    public Sprite[] portraits;
    public Sprite[] selectedPortraits;
    public Sprite[] arrows;
    public Image portrait;
    public Image leftArrow;
    public Image rightArrow;
    private int index;
    private float selection;
    private bool pressed;
    private float timer;
    public bool selected;
    void Start()
    {
        index = 0;
        timer = 1f;
    }

    void Update()
    { 
        if (!selected)
        {
            timer += Time.deltaTime;
            portrait.sprite = portraits[index];
            if (timer > 0.5f)
            {
                selection = Input.GetAxisRaw("Player2_Rotation");
                if (selection > 0)
                {
                    index++;
                    rightArrow.sprite = arrows[1];
                }
                else if (selection < 0)
                {
                    index--;
                    leftArrow.sprite = arrows[1];
                }
                else
                {
                    leftArrow.sprite = arrows[0];
                    rightArrow.sprite = arrows[0];
                }
                if (index == portraits.Length)
                    index = 0;
                else if (index == -1)
                    index = portraits.Length - 1;
                if (selection != 0)
                    timer = 0f;
            }
            if (Input.GetButtonDown("Player2_Rotation") && Input.GetAxisRaw("Player2_Rotation") == 0)
            {
                leftArrow.sprite = arrows[0];
                rightArrow.sprite = arrows[0];
                selected = true;
            }
        }
        else
        {
            if (index == 0)
                PlayerPrefs.SetString("Player2_Character", "Brutus");
            else if (index == 1)
                PlayerPrefs.SetString("Player2_Character", "Aurelia");
            else if (index == 2)
                PlayerPrefs.SetString("Player2_Character", "Albus");
            else if (index == 3)
                PlayerPrefs.SetString("Player2_Character", "Nubia");
            leftArrow.sprite = arrows[0];
            rightArrow.sprite = arrows[0];

            portrait.sprite = selectedPortraits[index];

            if (Input.GetButtonDown("Player2_Rotation") && Input.GetAxisRaw("Player2_Rotation") == 0)
            {
                selected = false;
                timer = 0.3f;
            }
                
        }
    }
}