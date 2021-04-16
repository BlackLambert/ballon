using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Balloon
{
	public class InteractionPlaneRaycaster : MimiBehaviour
	{
		public event Action<Vector3> evOnPointerDown;
		public event Action<Vector3> evOnPointerUp;
		public event Action<Vector3> evOnPointerPressed;

		[SerializeField]
		private Camera m_cam;
		[SerializeField]
		private string m_strInteractionPlaneTag = "InteractionPlane";
		[SerializeField]
		private int m_iMouseButtonIndex = 0;

		protected virtual void Update()
		{
			castRayAtMousePos();
		}

		private void castRayAtMousePos()
		{
			Ray ray = m_cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll(ray);
			foreach (RaycastHit hit in hits)
			{
				if (hit.collider.gameObject.tag != m_strInteractionPlaneTag)
					continue;
				if(Input.GetMouseButtonDown(m_iMouseButtonIndex))
					evOnPointerDown.Invoke(hit.point);
				if (Input.GetMouseButtonUp(m_iMouseButtonIndex))
					evOnPointerUp.Invoke(hit.point);
				if (Input.GetMouseButton(m_iMouseButtonIndex))
					evOnPointerPressed.Invoke(hit.point);
			}
		}
	}
}