using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class YRotator : MimiBehaviour
    {
        [SerializeField]
        private float _fDeltaRotation = 3f;

        protected virtual void Update()
		{
            m_transThis.Rotate(Vector3.up, _fDeltaRotation * Time.deltaTime);
		}
    }
}