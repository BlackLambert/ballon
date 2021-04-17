using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class RandomizeScale : MimiBehaviour
    {
        [SerializeField]
        private float m_fMin;
        [SerializeField]
        private float m_fMax;

        protected virtual void Start()
		{
            float fScale = Random.value * (m_fMax - m_fMin) + m_fMin;
            m_transThis.localScale = new Vector3(fScale, fScale, fScale);
		}
    }
}