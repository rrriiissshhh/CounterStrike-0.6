﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PowerUp : MonoBehaviour
{
    float powertime = 0f;
    bool powerup = false;
    bool multiplepowerup = false;
    // Health powerup variables
    bool healthpower = false;
    float healthtimelimit = 10;
    float currenthealth = 0f;
    float healthboost = 100f;
    public PlayerNetworkMover pnm;
    // Flash powerup variables
    bool speedpower = false;
    float speedtimelimit = 10;
    float speedboost = 2f;
    public FirstPersonController fps;



    // Use this for initialization
    void Start()
    {
        powertime = 0f;

    }


    // Update is called once per frame
    void Update()
    {
        // #########################
        //INitalise Health
        if (Input.GetKeyDown(KeyCode.Q) && (!powerup || multiplepowerup))
        {
            Debug.Log(currenthealth);
            currenthealth = pnm.health;
            pnm.health += healthboost;
            healthpower = true;
            powerup = true;
        }
        //During Health power up
        if (healthpower)
        {
            if (powertime < healthtimelimit)
            {
                powertime += Time.deltaTime;
            }
            else
            {
                pnm.health = Mathf.Min(currenthealth, pnm.health);
                powertime = 0f;
                healthpower = false;
                powerup = false;

            }

        }
        // ###########################
        if (Input.GetKeyDown(KeyCode.T) && (!powerup || multiplepowerup))
        {
            fps.m_WalkSpeed *= speedboost;
            fps.m_RunSpeed *= speedboost;
            speedpower = true;
            powerup = true;

        }

        if (speedpower)
        {
            if (powertime < speedtimelimit)
            {
                powertime += Time.deltaTime;
            }
            else
            {
                fps.m_WalkSpeed /= speedboost;
                fps.m_RunSpeed /= speedboost;
                powerup = false;
                speedpower = false;

            }
        }

    }
}