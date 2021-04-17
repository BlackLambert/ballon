using System;
using UnityEngine;

namespace Balloon
{
    public class Level : MimiBehaviour
    {
        [SerializeField]
        private int m_iStartLifes = 3;

        public event Action evLifesChanged;
        private int m_iLifesLeft;
        public int iLifesLeft
        {
            get => m_iLifesLeft;
            set
            {
                m_iLifesLeft = value;
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
        private State m_eCurrentState = State.Running;
        public State eCurrentState
        {
            get => m_eCurrentState;
            set
            {
                m_eCurrentState = value;
                evOnStateChanged?.Invoke();
            }
        }

        protected virtual void Start()
		{
            iLifesLeft = m_iStartLifes;
        }


        public enum State
		{
            Running = 0,
            Won = 1,
            Lost = 2
		}
    }
}