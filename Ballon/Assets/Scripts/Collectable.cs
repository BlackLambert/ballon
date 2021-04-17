using System;
using UnityEngine;

namespace Balloon
{
    public class Collectable : MimiBehaviour
    {
		public event Action<Collectable> evOnCollect;

		private void OnTriggerEnter(Collider _colOther)
		{
			checkIsCollected(_colOther);
		}

		private void checkIsCollected(Collider _colOther)
		{
			if (_colOther.GetComponentInChildren<Balloon>() == null)
				return;
			evOnCollect?.Invoke(this);
			Destroy(gameObject);
		}
	}
}