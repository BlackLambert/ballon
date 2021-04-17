using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class HookActivator : MimiBehaviour
    {
        [SerializeField]
        private Camera m_cam;
		[SerializeField]
		private int m_iMouseButtonIndex = 0;

		protected virtual void Update()
		{
			if (Input.GetMouseButtonDown(m_iMouseButtonIndex))
				raycastForHook();
		}

		private void raycastForHook()
		{
			Ray ray = m_cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll(ray);
			foreach (RaycastHit hit in hits)
				tryActivateHook(hit);
		}

		private void tryActivateHook(RaycastHit _hit)
		{
			Hook hook = _hit.collider.GetComponent<Hook>();
			if (hook != null)
				hook.activate();
		}
	}
}