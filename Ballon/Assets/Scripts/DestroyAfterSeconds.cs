using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class DestroyAfterSeconds : MimiBehaviour
    {
        [SerializeField]
        private float m_fSecondsTillDestruction = 3f;

        private IEnumerator startDestruction()
		{
            yield return new WaitForSeconds(m_fSecondsTillDestruction);
            Destroy(gameObject);
		}

		internal void Activate()
		{
			StartCoroutine(startDestruction());
		}
	}
}