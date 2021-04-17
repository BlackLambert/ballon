using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class DestroyWindAreaAfterActivation : MimiBehaviour
    {
        [SerializeField]
        private WindArea m_windArea;
        [SerializeField]
        private float m_fDeactivationDelay = 2f;

        protected virtual void Start()
		{
            m_windArea.evOnActivated += initDestruction;
        }

		private void initDestruction()
		{
			m_windArea.evOnActivated -= initDestruction;
			StartCoroutine(startDestruction());
		}

		private IEnumerator startDestruction()
		{
			yield return new WaitForSeconds(m_fDeactivationDelay);
			m_windArea.deactivate();
			m_windArea.startDestruction();
		}
	}
}