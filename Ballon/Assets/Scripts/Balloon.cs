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

        protected virtual void Start()
		{
            foreach (GameObject goDamageObject in m_liDamageObjects)
                goDamageObject.SetActive(false);
        }

        public void ApplyDamage()
		{
            if (m_damage >= m_liDamageObjects.Count)
                return;
            m_liDamageObjects[m_damage].SetActive(true);
            m_damage++;
        }

        public void Kill()
		{
            m_rigid.constraints = new RigidbodyConstraints();
            m_rigid.useGravity = true;
        }
    }
}