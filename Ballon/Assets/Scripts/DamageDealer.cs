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
		private bool bIsImmortal => m_iImmortalityTime > 0;
		private bool bIsDead => _level.iLifesLeft <= 0;
		private bool bIsSpeedSmallerThanThreshold => m_balloon.rigid.velocity.magnitude < m_fSpeedDamageThreshold;

		private void OnCollisionEnter(Collision collision)
		{
			if (this.bIsDead || this.bIsImmortal || !bIsDamageDealer(collision) || this.bIsSpeedSmallerThanThreshold)
				return;
			dealDamage();
		}

		protected virtual void Update()
		{
			if (m_iImmortalityTime > 0)
				m_iImmortalityTime -= Time.deltaTime;
		}

		private static bool bIsDamageDealer(Collision collision)
		{
			// Checking for just the ground tag is a little hacky.
			return collision.collider.gameObject.tag == c_strGroundTag;
		}

		private void dealDamage()
		{
			m_balloon.applyDamage();
			_level.iLifesLeft--;

			if (_level.iLifesLeft <= 0)
				m_balloon.kill();
			else
				m_iImmortalityTime = m_fImmortalityTimeAfterHit;
		}
	}
}