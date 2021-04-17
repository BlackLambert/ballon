using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class WindCreator : MonoBehaviour
    {
        [SerializeField]
        private InteractionPlaneRaycaster m_raycaster;
        [SerializeField]
        private WindArea m_windAreaPrefab;
		[SerializeField]
		private float m_fSecondsTillWindForceZero = 1f;

		private WindArea m_windAreaCurrent;
		private Vector3 m_v3DownPos = Vector3.zero;
		private float m_fPointerDownTime;

        protected virtual void Start()
		{
            m_raycaster.evOnPointerDown += onPointerDown;
            m_raycaster.evOnPointerUp += onPointerUp;
            m_raycaster.evOnPointerPressed += onPointerPressed;
        }

		protected virtual void OnDestroy()
		{
			m_raycaster.evOnPointerDown -= onPointerDown;
			m_raycaster.evOnPointerUp -= onPointerUp;
			m_raycaster.evOnPointerPressed -= onPointerPressed;
		}

		private void onPointerDown(Vector3 _v3RayHitPos)
		{
			createWindAreaAt(_v3RayHitPos);
			m_fPointerDownTime = Time.realtimeSinceStartup;
		}

		private void createWindAreaAt(Vector3 _v3RayHitPos)
		{
			m_windAreaCurrent = Instantiate(m_windAreaPrefab);
			Transform trans = m_windAreaCurrent.trans;
			m_v3DownPos = _v3RayHitPos;
			trans.localPosition = m_v3DownPos;
			trans.localScale = new Vector3(trans.localScale.x, trans.localScale.y, 0);
		}

		private void onPointerUp(Vector3 _v3RayHitPos)
		{
			if (m_windAreaCurrent == null)
				return;
			
			m_windAreaCurrent.activate();
			m_windAreaCurrent = null;
			m_v3DownPos = Vector3.zero;
		}

		private void onPointerPressed(Vector3 _v3RayHitPos)
		{
			if (m_windAreaCurrent == null)
				return;
			
			float fCreationTime = Time.realtimeSinceStartup - m_fPointerDownTime;
			m_windAreaCurrent.fForcePercentage = Mathf.Clamp01((m_fSecondsTillWindForceZero - fCreationTime) / m_fSecondsTillWindForceZero);
			Vector3 v3Distance = _v3RayHitPos - m_v3DownPos;
			m_windAreaCurrent.updateArea(m_v3DownPos, v3Distance);
		}
	}
}