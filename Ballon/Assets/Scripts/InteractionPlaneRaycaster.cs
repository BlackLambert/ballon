using System;
using UnityEngine;

namespace Balloon
{
	public class InteractionPlaneRaycaster : MimiBehaviour
	{
		private string c_strInteractionPlaneTag = "InteractionPlane";

		[SerializeField]
		private Camera m_cam;
		[SerializeField]
		private int m_iMouseButtonIndex = 0;

		public event Action<Vector3> evOnPointerDown;
		public event Action<Vector3> evOnPointerUp;
		public event Action<Vector3> evOnPointerPressed;

		protected virtual void Update()
		{
			castRayAtMousePos();
		}

		private void castRayAtMousePos()
		{
			Ray ray = m_cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll(ray);
			foreach (RaycastHit hit in hits)
				checkInteractionPlaneHit(hit);
		}

		private void checkInteractionPlaneHit(RaycastHit _hit)
		{
			if (!bIsInteractionPlane(_hit.collider.gameObject))
				return;
			Vector3 v3Point = _hit.point;
			if (Input.GetMouseButtonDown(m_iMouseButtonIndex))
				evOnPointerDown.Invoke(v3Point);
			if (Input.GetMouseButtonUp(m_iMouseButtonIndex))
				evOnPointerUp.Invoke(v3Point);
			if (Input.GetMouseButton(m_iMouseButtonIndex))
				evOnPointerPressed.Invoke(v3Point);
		}

		private bool bIsInteractionPlane(GameObject _goObject)
		{
			return _goObject.tag == c_strInteractionPlaneTag;
		}
	}
}