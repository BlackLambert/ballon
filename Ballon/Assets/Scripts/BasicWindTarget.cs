using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
	public class BasicWindTarget : MonoBehaviour, WindTarget
	{
		[SerializeField]
		private float m_fMaxSpeed = 1;
		public float fMaxSpeed => m_fMaxSpeed;
		[SerializeField]
		private Rigidbody m_rigid;
		public Rigidbody rigid => m_rigid;
	}
}