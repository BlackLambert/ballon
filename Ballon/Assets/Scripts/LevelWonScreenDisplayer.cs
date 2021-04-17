using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class LevelWonScreenDisplayer : MimiBehaviour
    {
        [SerializeField]
        private LevelWonScreen m_screenPrefab;
        [SerializeField]
        private float m_fDelay = 2;
        [SerializeField]
        private Level m_level;
        [SerializeField]
        private string m_strNextLevelName = "Level";

        protected virtual void Start()
		{
            m_level.evOnStateChanged += checkGameWon;
        }

        protected virtual void OnDestroy()
        {
            m_level.evOnStateChanged += checkGameWon;
        }

		private void checkGameWon()
		{
            if (m_level.state != Level.State.Won)
                return;
            StartCoroutine(startCreatingScreen());
		}

		private IEnumerator startCreatingScreen()
		{
            yield return new WaitForSeconds(m_fDelay);
            LevelWonScreen screen = Instantiate(m_screenPrefab);
            screen.init(m_level.iCollectedCollectablesCount, m_level.iMaxCollectablesCount, m_strNextLevelName);
        }
	}
}