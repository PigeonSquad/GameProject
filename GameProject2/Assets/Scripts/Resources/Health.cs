using UnityEngine;
using ARPG.Stats;
namespace ARPG.Resources
{
    public class Health: MonoBehaviour 
    {
        [SerializeField] float healthPoints = 100f;
        bool isDead = false;

        private void Start() {
            healthPoints = GetComponent<BaseStats>().GetHealth();
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

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

}