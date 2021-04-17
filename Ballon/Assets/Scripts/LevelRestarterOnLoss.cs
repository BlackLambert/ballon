using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Balloon
{
    public class LevelRestarterOnLoss : MimiBehaviour
    {
        [SerializeField]
        private Level m_level;
        [SerializeField]
        private float m_fDelay = 2;
        [SerializeField]
        private string m_strLevelName = "Level1";

        protected virtual void Start()
        {
            m_level.evOnStateChanged += checkLevelRestart;
        }

        protected virtual void OnDestroy()
        {
            m_level.evOnStateChanged -= checkLevelRestart;
        }

		private void checkLevelRestart()
		{
            if (m_level.state != Level.State.Lost)
                return;
            StartCoroutine(initRestart());
		}

        private IEnumerator initRestart()
		{
            yield return new WaitForSeconds(m_fDelay);
            restart();
		}

		private void restart()
		{
            SceneManager.LoadScene(m_strLevelName, LoadSceneMode.Single);
		}
	}
}