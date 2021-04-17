using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class IntervalWindAreaDeactivator : MonoBehaviour
    {
        [SerializeField]
        private WindArea m_windArea;
        [SerializeField]
        private float m_fActiveTime = 2;
        [SerializeField]
        private float m_fInactiveTime = 1;

        protected virtual void Start()
		{
            if (m_windArea.bActivated)
                m_windArea.deactivate();
            StartCoroutine(doInterval());
		}

        private IEnumerator doInterval()
		{
            yield return new WaitForSeconds(m_fInactiveTime);
            m_windArea.activate();
            yield return new WaitForSeconds(m_fActiveTime);
            m_windArea.deactivate();
            StartCoroutine(doInterval());
        }
    }
}