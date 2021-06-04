using UnityEngine;
using ARPG.Stats;
using System.Collections;
using System;

namespace ARPG.Stats
{
    
    public class Experience : MonoBehaviour
    {
        [SerializeField] float experiencePoints = 0;
        public void GainExperience(float experience)
        {
            experiencePoints+= experience;
        }


        public float GetPoints()
        {
            return experiencePoints;
        }
        /*public float GetPercentage()
        {

            return 100 * (experiencePoints / GetComponent<BaseStats>().GetHealth());
        }*/
    }
}