using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class CollectablesPanel : MimiBehaviour
    {
        private const string c_strAnimatorShowParameterName = "Show";

        [SerializeField]
        private Animator m_animator;
        
        public IEnumerator showTimed(float _fDuration)
		{
            show();
            yield return new WaitForSeconds(_fDuration);
            hide();
        }

        public void show()
		{
            m_animator.SetBool(c_strAnimatorShowParameterName, true);
        }

        public void hide()
		{
            m_animator.SetBool(c_strAnimatorShowParameterName, false);
        }
    }
}