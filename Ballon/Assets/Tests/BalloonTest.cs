using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Balloon.Test
{
    public class BalloonTest
    {

		private Balloon m_balloon;

        [Test]
        public void maxSpeed_ReturnsExpectedValue()
        {
            givenADefaultSetup();
            thenMaxSpeedReturnsExpectedValue();
        }

		private void givenADefaultSetup()
		{
			GameObject balloonPrefab = Resources.Load("TestBalloon") as GameObject;
			m_balloon = GameObject.Instantiate(balloonPrefab).GetComponent<Balloon>();
		}

		private void thenMaxSpeedReturnsExpectedValue()
		{
			float fExpected = 3.2f;
			float fActual = m_balloon.fMaxSpeed;
			Assert.AreEqual(fExpected, fActual);
		}
	}
}