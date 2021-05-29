using UnityEngine;

namespace ARPG.Combat
{
    public class HealthEnemy: MonoBehaviour 
    {
        [SerializeField] float health = 100f;

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage,0);
            Debug.Log("Enemy Health:" + health);
            print("Enemy Health:" + health);
        }
    }

}