using UnityEngine;
using ARPG.Stats;
using System.Collections;
using System;
using ARPG.Core;

namespace ARPG.Npc
{

    public enum QuestState {
        Start, No, Yes, InSearch, Found, Returned
    }
    public class Quest : MonoBehaviour
    {
        public QuestState State = QuestState.Start;

        public void QStart()
        {
            Debug.Log("Hello traveler bring me brick i give you money");
            State = QuestState.Yes;
        }

        internal void DisplayTask()
        {
            Debug.Log("Bring me brick");
        }

        internal void Cancel()
        {
            State = QuestState.Start;
        }

        internal void ShowTask()
        {
            throw new NotImplementedException();
        }

        internal void SendHome()
        {
            throw new NotImplementedException();
        }

        internal void Reward()
        {
            throw new NotImplementedException();
        }
    }
}