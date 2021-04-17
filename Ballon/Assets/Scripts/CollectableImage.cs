using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class CollectableImage : MimiBehaviour
    {
		private const string c_strFilledAnimatorParameter = "Filled";
		[SerializeField]
        private Animator m_animator;

        public void setFilled()
		{
            m_animator.SetBool(c_strFilledAnimatorParameter, true);
        }
    }
}