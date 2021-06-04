using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    public static int mana = 100;
    public GameObject player;
    public Slider manaBar;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReduceMana", 1, 1);
    }

    void ReduceMana()
    {
        mana = mana - 5;
        manaBar.value = mana;

        //Debug.Log("Mana:" + mana);
        if (mana <= 0)
        {
            Debug.Log("Not enough mana");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
