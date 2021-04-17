using UnityEngine;

namespace Balloon
{
    public class Gate : MimiBehaviour
    {
        [SerializeField]
        private Level m_level;

		private void OnTriggerEnter(Collider _colOther)
		{
			checkLevelWon(_colOther);
		}

		private void checkLevelWon(Collider _colOther)
		{
			if (_colOther.GetComponentInChildren<Balloon>() == null)
				return;
			m_level.eCurrentState = Level.State.Won;
		}
	}
}