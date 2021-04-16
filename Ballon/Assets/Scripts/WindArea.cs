using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class WindArea : MonoBehaviour
    {
        [SerializeField]
        public float m_fForce = 10;

        public Vector3 v3NormalizedForceDirection => transform.forward.normalized;


        private void OnTriggerStay(Collider _other)
		{
            WindTarget windTarget = _other.GetComponentInChildren<WindTarget>();
            if (windTarget == null)
                return;
            float fCurrentSpeed = windTarget.rigid.velocity.magnitude;
            if (fCurrentSpeed >= windTarget.fMaxSpeed)
                return;
            float fDelta = Mathf.Min(windTarget.fMaxSpeed - fCurrentSpeed, m_fForce);
            windTarget.rigid.AddForce(v3NormalizedForceDirection * fDelta, ForceMode.VelocityChange);
            Debug.Log(windTarget.rigid.velocity.magnitude);
        }
    }
}