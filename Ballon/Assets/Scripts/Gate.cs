using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class Gate : MimiBehaviour
    {
        [SerializeField]
        private Level m_level;


		private void OnTriggerEnter(Collider _colOther)
		{
			if (_colOther.GetComponentInChildren<Balloon>() == null)
				return;
			m_level.state = Level.State.Won;
		}
	}
}