using UnityEngine;
using ARPG.Stats;
using System.Collections;

namespace ARPG.Resources
{
    public class Health: MonoBehaviour 
    {
        [SerializeField] float healthPoints = 100f;
        bool isDead = false;

        private void Start() {
            
            healthPoints = GetComponent<BaseStats>().GetHealth();
            StartCoroutine("TestTakeDamage");
        }

        /*private void Update() {
            StartCoroutine("TestTakeDamage");
              
        }*/

        private IEnumerator TestTakeDamage()
        {
            
            while(healthPoints > 0)
            {
                healthPoints = healthPoints - 5;
                yield return new WaitForSeconds(5f);
            }
            
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            Debug.Log("Enemy Health:" + healthPoints);
            print("Enemy Health:" + healthPoints);
            if (healthPoints == 0)
            {
                Die();
            }
        }

        public float GetPercentage()
        {
            
            return 100* (healthPoints / GetComponent<BaseStats>().GetHealth());
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

}