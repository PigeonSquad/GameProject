using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public static int health = 100;
    public GameObject player;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReduceHealth" ,1,1);
    }

    void ReduceHealth()
    {
        health = health - 5;
        healthBar.value = health;
        
        //Debug.Log("Health:"+health);
        if(health <= 0)
        {
            Debug.Log("Dead");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
