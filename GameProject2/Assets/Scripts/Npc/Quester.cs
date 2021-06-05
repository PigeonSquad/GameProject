using UnityEngine;
using ARPG.Movement;
using ARPG.Core;
using ARPG.Resources;
using ARPG.Stats;

namespace ARPG.Npc
{
    public class Quester : MonoBehaviour, IAction
    {

        [SerializeField] float questRange = 2f;

        Experience experience;

        public Transform questLocation;
        bool isActive = false;

        public Texture questMessage;
        Quest quest;

        private void Start() {
            experience = GetComponent<Experience>();            
        }

        private void Update()
        {
            Debug.Log("update");
            if (isActive) {
                QuestBehaviour();
                return;
            }

            if (quest == null) return;

            if (!IsInRange())
            {
                GetComponent<Mover>().MoveTo(quest.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                isActive = true;
            }
        }

        public bool IsActive() {
            return isActive;
        }

        public void QuestBehaviour()
        {
            Debug.Log("behave");
            if (Vector3.Distance(transform.position, questLocation.position) < 2f) {
                Debug.Log("wut?");
                experience.GainExperience(20);
                isActive = false;
                quest = null;
            }
            
        }

        private void OnGUI() {
            if (isActive) {
                GUI.DrawTexture(new Rect(100, 100, 100, 100), questMessage);
            }
        }

        private bool IsInRange() 
        {
            return Vector3.Distance(transform.position, quest.transform.position) < questRange;
        }

        public void Interact(GameObject questTarget)
        {
            quest = questTarget.GetComponent<Quest>();
            if (IsInRange())
            isActive = true;
        }

        public void Cancel()
        {
            isActive = false;
            quest = null;
        }
    }
}