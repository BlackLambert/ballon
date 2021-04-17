
using UnityEngine;

namespace Balloon
{
    public class Hook : MimiBehaviour
    {
		private Balloon m_balloon;
		[SerializeField]
		private float m_fMaxHookDistance = 3;
		[SerializeField]
		private Rigidbody m_rigidbody;

		private bool m_bHooked = false;
		private float fDistanceToBalloon => (m_balloon.trans.position - m_transThis.position).magnitude;
		private bool bBalloonIsWithinReach => this.fDistanceToBalloon > m_fMaxHookDistance;

		protected virtual void Start()
		{
			m_balloon = FindObjectOfType<Balloon>();
			if (m_balloon == null)
				throw new MissingComponentException("There has to be a balloon in the scene");
		}

		public void activate()
		{
			if (m_bHooked)
				unhook();
			else
				tryHook();
		}

		private void tryHook()
		{
			if (this.bBalloonIsWithinReach)
				return;
			m_balloon.hookTo(m_rigidbody);
			m_bHooked = true;
		}

		private void unhook()
		{
			m_balloon.unhookFrom(m_rigidbody);
			m_bHooked = false;
		}
	}
}