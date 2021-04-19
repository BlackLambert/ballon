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
            m_transThis.Rotate(new Vector3(0, _fDeltaRotation * Time.deltaTime, 0), Space.World);
		}
    }
}