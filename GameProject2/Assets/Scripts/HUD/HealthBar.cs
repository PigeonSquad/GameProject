using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using ARPG.Resources;
using System;

public class HealthBar : MonoBehaviour
{
    Health health;
    //public static int health = 100;
    //public GameObject player;
    public Slider healthBar;
    // Start is called before the first frame update
    
    private void Awake()
    {
        health = GameObject.FindWithTag("Player").GetComponent<Health>();
        
    }
    private void Update()
    {
        
        healthBar.value = health.GetPercentage();
    }

    /*void ReduceHealth()
    {
        health = health - 5;
        healthBar.value = health;
        
        //Debug.Log("Health:"+health);
        if(health <= 0)
        {
            Debug.Log("Dead");

        }
    }*/

    // Update is called once per frame
    
}
