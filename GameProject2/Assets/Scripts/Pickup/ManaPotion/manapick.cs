using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manapick : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        ManaBar.mana += 20;
        Debug.Log("Mana++");
        if (ManaBar.mana > 100)
        {
            ManaBar.mana = 100;
        }
        Destroy(this.gameObject);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
