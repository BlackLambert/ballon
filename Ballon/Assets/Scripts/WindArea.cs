using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class WindArea : MimiBehaviour
    {
        [SerializeField]
        public float m_fForce = 10;
        [SerializeField]
        private ParticleSystem m_particleSystem;
        [SerializeField]
        private DestroyAfterSeconds m_destroyAfterSeconds;
        [SerializeField]
        private float m_fSecondsTillDeactivation = 2f;
        [SerializeField]
        private float m_fDestractionDelay = 1f;

        private bool m_bActivated = false;

        public Vector3 v3NormalizedForceDirection => transform.forward.normalized;

        public void updateSize(Vector3 _v3StartPos, Vector3 _v3Direction)
		{
            Vector3 v3EndPos = _v3StartPos + _v3Direction;
            trans.LookAt(v3EndPos);
            m_transThis.localScale = new Vector3(trans.localScale.x, trans.localScale.y, _v3Direction.magnitude);
            m_transThis.localPosition = _v3StartPos + (_v3Direction / 2);
            ParticleSystem.MainModule main = m_particleSystem.main;
            main.startLifetime = _v3Direction.magnitude / main.startSpeed.constant;
        }

        public void activate()
		{
            if (m_bActivated)
                return;
            m_bActivated = true;
            m_destroyAfterSeconds.Activate();
            StartCoroutine(startDestruction());
        }

        private IEnumerator startDestruction()
		{
            yield return new WaitForSeconds(m_fSecondsTillDeactivation);
            deactivate();
            yield return new WaitForSeconds(m_fDestractionDelay);
            Destroy(gameObject);
        }

        private void deactivate()
		{
            ParticleSystem.EmissionModule emission = m_particleSystem.emission;
            emission.enabled = false;
            m_bActivated = false;
        }

        private void OnTriggerStay(Collider _other)
		{
            if (!m_bActivated)
                return;

            WindTarget windTarget = _other.GetComponentInChildren<WindTarget>();
            if (windTarget == null)
                return;
            float fCurrentSpeed = windTarget.rigid.velocity.magnitude;
            if (fCurrentSpeed >= windTarget.fMaxSpeed)
                return;
            float fDelta = Mathf.Min(windTarget.fMaxSpeed - fCurrentSpeed, m_fForce);
            windTarget.rigid.AddForce(v3NormalizedForceDirection * fDelta, ForceMode.VelocityChange);
        }
    }
}