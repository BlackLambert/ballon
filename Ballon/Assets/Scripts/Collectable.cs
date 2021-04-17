using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class Collectable : MonoBehaviour
    {
		public event Action<Collectable> evOnCollect;

		private void OnTriggerEnter(Collider _colOther)
		{
			checkCollect(_colOther);
		}

		private void checkCollect(Collider _colOther)
		{
			if (_colOther.GetComponentInChildren<Balloon>() == null)
				return;
			evOnCollect?.Invoke(this);
			Destroy(gameObject);
		}
	}
}