using System;
using System.Collections;
using System.Collections.Generic;
using ARPG.Combat;
using ARPG.Core;
using ARPG.Movement;
using ARPG.Resources;
using UnityEngine;

namespace ARPG.Control {
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseRadius = 5f;
        [SerializeField] float suspicionTime = 5f;
        [SerializeField] float dwellingTime = 3f;
        [SerializeField] float waypointTolerance = 1f;
        public Path patrolPath;
        Fighter fighter;
        GameObject player;
        Vector3 guardPosition;
        Health health;
        Mover mover;
        float timeSinceLastSawPlayer = Mathf.Infinity;
        float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        int currentWaypointIndex = 0;

        private void Start() {
             fighter = GetComponent<Fighter>();
             player = GameObject.FindWithTag("Player");
             health = GetComponent<Health>();
             guardPosition = transform.position;
             mover = GetComponent<Mover>();
        }

        private void Update() 
        {
            if (health.IsDead()) {
                return;
            }
            if (IsInChaceDistance() && fighter.canAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                AttackBehaviour();
            }
            else if(timeSinceLastSawPlayer < suspicionTime)
            {
                SuspiciousBehaviour();
            }
            else
            {
                PatrolBehaviour();
            }
            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArrivedAtWaypoint += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = guardPosition;

            if (patrolPath != null) 
            {
                if (IsAtWayPoint())
                {
                    timeSinceArrivedAtWaypoint = 0;
                    CycleWayPoint();
                }
                nextPosition = GetCurrentWaypoint();
            }

            if (timeSinceArrivedAtWaypoint > dwellingTime) 
            {
                mover.StartMoveAction(nextPosition);
            }
        }

        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetWaypoint(currentWaypointIndex);
        }

        private void CycleWayPoint()
        {
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }

        private bool IsAtWayPoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }

        private void SuspiciousBehaviour()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehaviour()
        {
            fighter.Attack(player);
        }

        private bool IsInChaceDistance() 
        {
            return Vector3.Distance(transform.position, player.transform.position) < chaseRadius;
        }
    }
}

