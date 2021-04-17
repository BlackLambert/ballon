using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class Level : MimiBehaviour
    {
        [SerializeField]
        private int m_iStartLifes = 3;

        public event Action evLifesChanged;
        private int m_iLifes;
        public int iLifes
        {
            get => m_iLifes;
            set
            {
                m_iLifes = value;
                evLifesChanged?.Invoke();
            }
        }

        public event Action evOnCollectedCollectablesCountChanged;
        private int m_iCollectedCollectablesCount = 0;
        public int iCollectedCollectablesCount
		{
            get => m_iCollectedCollectablesCount;
            set
			{
                m_iCollectedCollectablesCount = value;
                evOnCollectedCollectablesCountChanged?.Invoke();
            }
		}

        public event Action evOnMaxCollectablesCountChanged;
        private int m_iMaxCollectablesCount = 0;
        public int iMaxCollectablesCount
        {
            get => m_iMaxCollectablesCount;
            set
            {
                m_iMaxCollectablesCount = value;
                evOnMaxCollectablesCountChanged?.Invoke();
            }
        }

        public event Action evOnStateChanged;
        private State m_state = State.Running;
        public State state
        {
            get => m_state;
            set
            {
                m_state = value;
                evOnStateChanged?.Invoke();
            }
        }

        protected virtual void Start()
		{
            iLifes = m_iStartLifes;
        }


        public enum State
		{
            Running = 0,
            Won = 1,
            Lost = 2
		}
    }
}