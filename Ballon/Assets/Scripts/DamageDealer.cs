using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class DamageDealer : MonoBehaviour
    {
		private const string c_strGroundTag = "Ground";
		[SerializeField]
        private Balloon m_balloon;
		[SerializeField]
		private float m_fSpeedDamageThreshold = 0.5f;
		[SerializeField]
		private float m_fImmortalityTimeAfterHit = 0.33f;
		[SerializeField]
		private Level _level;

		private float m_iImmortalityTime = 0;
		private bool iIsImmortal => m_iImmortalityTime > 0;

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.gameObject.tag != c_strGroundTag || iIsImmortal)
				return;
			float fCurrentSpeed = m_balloon.rigid.velocity.magnitude;
			Debug.Log($"Current Speed {fCurrentSpeed} | Threshold {m_fSpeedDamageThreshold}");
			if (fCurrentSpeed < m_fSpeedDamageThreshold)
				return;
			
			m_balloon.ApplyDamage();
			_level.iLifes--;

			if (_level.iLifes <= 0)
				m_balloon.Kill();
			else
				m_iImmortalityTime = m_fImmortalityTimeAfterHit;
		}

		protected virtual void Update()
		{
			if (m_iImmortalityTime > 0)
				m_iImmortalityTime -= Time.deltaTime;
		}
	}
}