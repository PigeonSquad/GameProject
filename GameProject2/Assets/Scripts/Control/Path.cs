using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Control
{
    public class Path : MonoBehaviour
    {
        private void OnDrawGizmos() {
            for (int i = 0; i < transform.childCount; i++) {
                Gizmos.DrawSphere(GetWaypoint(i), .5f);
            }
        }   

        public Vector3 GetWaypoint(int i) {
            return transform.GetChild(i).transform.position;
        }

        public int GetNextIndex(int i) {
            return (i + 1) % transform.childCount;
        }
    }
}