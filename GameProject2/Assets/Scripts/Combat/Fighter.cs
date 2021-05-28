using UnityEngine;
using ARPG.Movement;
using ARPG.Core;
namespace ARPG.Combat
{

public class Fighter : MonoBehaviour, IAction {

    [SerializeField] float weaponRange = 2f;
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float weaponDamage = 5f;
    Transform target;
    float timeSinceLastAttack = 0;

    private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if(target == null) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }

        }

        private void AttackBehaviour()
        {
            if(timeSinceLastAttack> timeBetweenAttacks)
            {
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceLastAttack = 0;
                HealthEnemy healthComponent = target.GetComponent<HealthEnemy>();
                healthComponent.TakeDamage(weaponDamage);
            }
            
        }
        //Animation Event
        void Hit()
        {
            
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            print("hit");
        }
    public void Cancel()
    {
        target= null;
    }
  
   
    
}

}