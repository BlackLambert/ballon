using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class Balloon : MimiBehaviour, WindTarget
    {
        [SerializeField]
        private float m_fMaxSpeed = 1;
        public float fMaxSpeed => m_fMaxSpeed;

		[SerializeField]
        private Rigidbody m_rigid;
        public Rigidbody rigid => m_rigid;

        [SerializeField]
        private List<GameObject> m_liDamageObjects = new List<GameObject>();
        private int m_damage = 0;

        [SerializeField]
        private GameObject m_transRopeBase;

        [SerializeField]
        private Joint m_jointRopeEnd;

        protected virtual void Start()
		{
            m_transRopeBase.gameObject.SetActive(false);
            foreach (GameObject goDamageObject in m_liDamageObjects)
                goDamageObject.SetActive(false);
        }

		public void hookTo(Rigidbody _rigid)
		{
            m_jointRopeEnd.connectedBody = _rigid;
            m_transRopeBase.gameObject.SetActive(true);
        }

        public void unhookFrom(Rigidbody _rigid)
		{
            m_jointRopeEnd.connectedBody = null;
            m_transRopeBase.gameObject.SetActive(false);
        }

		public void applyDamage()
		{
            if (m_damage >= m_liDamageObjects.Count)
                return;
            m_liDamageObjects[m_damage].SetActive(true);
            m_damage++;
        }

        public void kill()
		{
            m_rigid.constraints = new RigidbodyConstraints();
            m_rigid.useGravity = true;
        }
    }
}