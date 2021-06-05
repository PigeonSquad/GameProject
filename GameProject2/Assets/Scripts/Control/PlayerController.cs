using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARPG.Combat;
using ARPG.Core;
using ARPG.Resources;
using ARPG.Movement;
namespace ARPG.Control{


public class PlayerController : MonoBehaviour
{
        Health health;
        private void Start()
        {
            health = GetComponent<Health>();
        }
        void Update()
        {
            if (health.IsDead()) return;
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
            if (InteractWithItem()) return;
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
              CombatTarget target=  hit.transform.GetComponent<CombatTarget>();
                    if (target == null)
                    {
                        continue;
                    }
                if(!GetComponent<Fighter>().canAttack(target.gameObject))
                {
                    continue;
                }

              if(Input.GetMouseButtonDown(0))
              {
                  GetComponent<Fighter>().Attack(target.gameObject);
              
              }
              return true;
           }
           return false;
        }

        private bool InteractWithItem()
        {
            RaycastHit hit;
            bool hashit = Physics.Raycast(GetMouseRay(), out hit);

            if (hashit)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    InteractableItems interactable = hit.collider.GetComponent<InteractableItems>();
                }
            }

            return false;
        }
    

}

}