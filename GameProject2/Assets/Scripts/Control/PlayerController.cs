using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARPG.Combat;
using ARPG.Core;
using ARPG.Movement;
namespace ARPG.Control{


public class PlayerController : MonoBehaviour
{ 
    HealthEnemy health;
    private void Start() {
        health = GetComponent<HealthEnemy>();
    }
    
    void Update()
        {
            if(health.IsDead()) return;
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;

        }

        private bool InteractWithMovement()
        {
          
            RaycastHit hit;
            bool hashit = Physics.Raycast(GetMouseRay(), out hit);
            if (hashit)
            {
                if(Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private bool InteractWithCombat()
    {
       RaycastHit[] hits= Physics.RaycastAll(GetMouseRay());
       foreach (RaycastHit hit in hits)
       {
          CombatTarget target = hit.transform.GetComponent<CombatTarget>();
          if (target == null) 
          {
              continue;
          }
            if(!GetComponent<Fighter>().canAttack(target.gameObject))
            {
                continue;
            }

          if(Input.GetMouseButton(0))
          {
              GetComponent<Fighter>().Attack(target.gameObject);
              
          }
          return true;
       }
       return false;
    }

}

}