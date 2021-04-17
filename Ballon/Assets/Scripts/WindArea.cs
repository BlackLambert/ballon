using System;
using System.Collections;
using UnityEngine;

namespace Balloon
{
    public class WindArea : MimiBehaviour
    {
        [SerializeField]
        private float m_fMaxForce = 10;
        [SerializeField]
        private float m_fMinForcePercentage = 0.1f;
        [SerializeField]
        private ParticleSystem m_particleSystem;
        [SerializeField]
        private float m_fMaxParticleSpeed = 5f;
        [SerializeField]
        private float m_fDestructionDelay = 1f;
        [SerializeField]
        private bool m_bActivateOnAwake = false;
        [SerializeField]
        private bool m_bActivateParticlesOnAwake = true;

        public event Action evOnActivated;

		public bool bActivated { get; private set; } = false;
		public float fPreferedForcePercentage { get; set; } = 1f;
        private float fActuralForcePercentage => Mathf.Max(m_fMinForcePercentage, fPreferedForcePercentage);
        public Vector3 v3NormalizedForceDirection => transform.forward.normalized;


        protected override void Awake()
		{
            base.Awake();
            if (m_bActivateOnAwake)
                activate();
            activateParticles(m_bActivateParticlesOnAwake);
        }

		public void updateAreaSize(Vector3 _v3StartPos, Vector3 _v3Direction)
		{
            updateTransform(_v3StartPos, _v3Direction);
            updateParticleSystem(_v3Direction.magnitude);
		}

        private void updateTransform(Vector3 _v3StartPos, Vector3 _v3Direction)
		{
            Vector3 v3EndPos = _v3StartPos + _v3Direction;
            m_transThis.LookAt(v3EndPos);
            m_transThis.localScale = new Vector3(trans.localScale.x, trans.localScale.y, _v3Direction.magnitude);
            m_transThis.localPosition = _v3StartPos + (_v3Direction / 2);
        }

		private void updateParticleSystem(float _fMagnitude)
		{
			ParticleSystem.MainModule main = m_particleSystem.main;
			ParticleSystem.MinMaxCurve startSpeed = main.startSpeed.constant;
			startSpeed.constant = fActuralForcePercentage * m_fMaxParticleSpeed;
            main.startSpeed = startSpeed;
            main.startLifetime = _fMagnitude / main.startSpeed.constant;
        }

		public void activate()
		{
            if (this.bActivated)
                throw new InvalidOperationException();
            this.bActivated = true;
            evOnActivated?.Invoke();
            activateParticles(true);
        }

        public void deactivate()
		{
			if (!this.bActivated)
				throw new InvalidOperationException();
			activateParticles(false);
            this.bActivated = false;
		}

		private void activateParticles(bool _bActivate)
		{
			ParticleSystem.EmissionModule emission = m_particleSystem.emission;
			emission.enabled = _bActivate;
		}

		public IEnumerator startDestruction()
        {
            yield return new WaitForSeconds(m_fDestructionDelay);
            Destroy(gameObject);
        }

        private void OnTriggerStay(Collider _colOther)
		{
            if (!this.bActivated)
                return;

            WindTarget windTarget = _colOther.GetComponentInChildren<WindTarget>();
            if (windTarget == null)
                return;

            float fCurrentSpeed = windTarget.rigid.velocity.magnitude;
            if (fCurrentSpeed >= windTarget.fMaxSpeed)
                return;

            float fDelta = Mathf.Min(windTarget.fMaxSpeed - fCurrentSpeed, fActuralForcePercentage * m_fMaxForce);
            windTarget.rigid.AddForce(v3NormalizedForceDirection * fDelta, ForceMode.VelocityChange);
        }
    }
}