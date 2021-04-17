using UnityEngine;

namespace Balloon
{
    public class LevelLostChecker : MimiBehaviour
    {
        [SerializeField]
        private Level m_level;

        private bool bNoLifesLeft => m_level.iLifesLeft <= 0;

        protected virtual void Start()
		{
            m_level.evLifesChanged += checkLevelLost;
        }

        protected virtual void OnDestroy()
		{
            m_level.evLifesChanged -= checkLevelLost;
        }

		private void checkLevelLost()
		{
            if (this.bNoLifesLeft)
                m_level.eCurrentState = Level.State.Lost;
        }
	}
}