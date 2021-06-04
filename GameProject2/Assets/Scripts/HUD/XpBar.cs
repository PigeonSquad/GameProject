using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using ARPG.Combat;
using ARPG.Resources;

public class XpBar : MonoBehaviour
{

    public static int xp = 0;
    public GameObject player;
    public Image xpbar;
    Health target;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseXp", 1, 1);
    }

    void IncreaseXp()
    {

        
       
        /*if(target.())
        {
            xp = xp + 5;
            xpbar.fillAmount = (float)xp / 100;
        }*/
        //Debug.Log("XP:" + xp);
        if (xp == 100)
        {
            Debug.Log("Level up");
            xp= 0;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
