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
		[SerializeField]
		private float m_fDistanceThreshold = 0.1f;

		private WindArea m_windAreaCurrent;
		private Vector3 m_v3DownPos = Vector3.zero;
		private float m_fPointerDownTime;

		private bool bIsCreating => m_windAreaCurrent != null;
		private bool bIsMouseDownPosZero => m_v3DownPos == Vector3.zero;

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
			initCreationFields(_v3RayHitPos);
		}

		private void onPointerPressed(Vector3 _v3RayHitPos)
		{
			Vector3 v3Distance = _v3RayHitPos - m_v3DownPos;
			if (!this.bIsCreating && !this.bIsMouseDownPosZero && bIsOverThreshold(v3Distance))
				createWindArea();
			if (!this.bIsCreating)
				return;
			updateWindAreaSize(v3Distance);
		}

		private void onPointerUp(Vector3 _v3RayHitPos)
		{
			if (!this.bIsCreating)
				return;

			m_windAreaCurrent.activate();
			m_windAreaCurrent = null;
			m_v3DownPos = Vector3.zero;
		}

		private void initCreationFields(Vector3 _v3RayHitPos)
		{
			m_v3DownPos = _v3RayHitPos;
			m_fPointerDownTime = Time.realtimeSinceStartup;
		}

		private void createWindArea()
		{
			m_windAreaCurrent = Instantiate(m_windAreaPrefab);
			Transform trans = m_windAreaCurrent.trans;
			trans.localPosition = m_v3DownPos;
			trans.localScale = new Vector3(trans.localScale.x, trans.localScale.y, 0);
		}

		private bool bIsOverThreshold(Vector3 _v3Distance)
		{
			return _v3Distance.magnitude >= m_fDistanceThreshold;
		}

			private void updateWindAreaSize(Vector3 _v3Distance)
		{
			float fCreationTime = Time.realtimeSinceStartup - m_fPointerDownTime;
			m_windAreaCurrent.fPreferedForcePercentage = Mathf.Clamp01((m_fSecondsTillWindForceZero - fCreationTime) / m_fSecondsTillWindForceZero);
			m_windAreaCurrent.updateAreaSize(m_v3DownPos, _v3Distance);
		}
	}
}