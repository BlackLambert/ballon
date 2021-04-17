using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class RandomizeYRotation : MimiBehaviour
    {
        protected virtual void Start()
		{
            float fRotationAngle = Random.value * 360;
            Vector3 v3formerEuler = m_transThis.rotation.eulerAngles;
            Vector3 v3EulerRotation = new Vector3(v3formerEuler.x, fRotationAngle, v3formerEuler.z);
            m_transThis.rotation = Quaternion.Euler(v3EulerRotation);
		}
    }
}