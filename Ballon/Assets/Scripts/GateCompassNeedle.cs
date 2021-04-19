using UnityEngine;

namespace Balloon
{
    public class GateCompassNeedle : MimiBehaviour
    {
        private Gate m_gate;
        private Balloon m_balloon;

        protected virtual void Start()
		{
            m_gate = FindObjectOfType<Gate>();
            if (m_gate == null)
                throw new MissingComponentException("There has to be a Gate component in the scene");

            m_balloon = FindObjectOfType<Balloon>();
            if (m_balloon == null)
                throw new MissingComponentException("There has to be a Balloon component in the scene");
        }

        protected virtual void Update()
		{
            rotateTowardsGate();
		}

		private void rotateTowardsGate()
		{
            Vector2 v2GateScreenPos = Camera.main.WorldToScreenPoint(m_gate.trans.position);
            Vector2 v2BalloonScreenPos = Camera.main.WorldToScreenPoint(m_balloon.trans.position);
            Vector2 v2DistanceVector = v2GateScreenPos - v2BalloonScreenPos;
            float fAngle = Vector2.Angle(Vector2.up, v2DistanceVector);
            fAngle *= v2BalloonScreenPos.x > v2GateScreenPos.x ? 1 : -1;
            m_transThis.rotation = Quaternion.Euler(0, 0, fAngle);
        }
	}
}