﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Selection_Controller : MonoBehaviour
{
    public Character_Selection_Controller_Player1 playerOne;
    public Character_Selection_Controller_Player2 playerTwo;
    private float timer;
    public float waitTime;

    private void Update()
    {
        if (playerOne.selected && playerTwo.selected)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                SceneManager.LoadScene("Level_One");
                FindObjectOfType<Audio_Manager>().ResetSounds();
            }
                
        }
        else
            timer = 0;
    }

}
