using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class LevelLostChecker : MimiBehaviour
    {
        [SerializeField]
        private Level m_level;

        protected virtual void Start()
		{
            m_level.evLifesChanged += checkLevelLost;
        }

        protected virtual void OnDestroy()
		{
            m_level.evLifesChanged -= checkLevelLost;
        }

		private void checkLevelLost()
		{
            if (m_level.iLifes <= 0)
                m_level.state = Level.State.Lost;
        }
	}
}