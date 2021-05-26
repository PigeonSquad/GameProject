using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARPG.Combat;
using ARPG.Movement;
namespace ARPG.Control{


public class PlayerController : MonoBehaviour
{ 
    void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            RaycastHit hit;
            bool hashit = Physics.Raycast(GetMouseRay(), out hit);
            if (hashit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private void InteractWithCombat()
    {
       RaycastHit[] hits= Physics.RaycastAll(GetMouseRay());
       foreach (RaycastHit hit in hits)
       {
          CombatTarget target=  hit.transform.GetComponent<CombatTarget>();
          if(target==null) continue;

          if(Input.GetMouseButtonDown(0))
          {
              GetComponent<Fighter>().Attack(target);
          }
       }
    }

}

}