using UnityEngine;
using ARPG.Combat;
using ARPG.Resources;
using ARPG.Movement;
using ARPG.Npc;

namespace ARPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Health health;
        Quest quest;

        private void Start()
        {
            health = GetComponent<Health>();
            quest = GetComponent<Quest>();
        }

        private void Update()
        {
            if (health.IsDead()) return;
            if (InteractWithCombat()) return;
            if (InteractWithNpc()) return;
            if (InteractWithMovement()) return;

        }

        private bool InteractWithNpc()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                NpcTarget target = hit.transform.GetComponent<NpcTarget>();
                if (target == null)
                {
                    continue;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Quester>().Interact(target.gameObject);

                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {

            RaycastHit hit;
            bool hashit = Physics.Raycast(GetMouseRay(), out hit);
            if (hashit)
            {
                if (Input.GetMouseButton(0))
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
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null)
                {
                    continue;
                }
                if (!GetComponent<Fighter>().canAttack(target.gameObject))
                {
                    continue;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);

                }
                return true;
            }
            return false;
        }
    }
}