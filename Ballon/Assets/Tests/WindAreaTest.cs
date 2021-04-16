using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Balloon.Test
{
    public class WindAreaTest
    {
        private WindArea m_windArea;
        private WindTarget m_windTarget;

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator forceIsAddedToTargetObject()
        {
            givenADefaultSetup();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            thenForceIsAddedToTestRigidbody();
        }

        [UnityTest]
        public IEnumerator forceIsAppliedInExpectedDirection()
        {
            givenADefaultSetup();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            thenForceIsAppliedInExpectedDirection();
        }

        [UnityTest]
        public IEnumerator windTargertMaxSpeedNotExceeded()
		{
            givenADefaultSetup();
            yield return new WaitForSeconds(0.5f);
            thenTheWindTargetsMaxSpeedIsNotExceeded();
        }

        [UnityTest]
        public IEnumerator normalizedForceDirectionIsNormalized()
        {
            givenADefaultSetup();
            yield return 0;
            thenTheForceDirectionIsNormalized();
        }

		private void givenADefaultSetup()
		{
            GameObject prefab = Resources.Load("TestWindArea") as GameObject;
            m_windArea = GameObject.Instantiate(prefab).GetComponent<WindArea>();
            m_windTarget = m_windArea.GetComponentInChildren<WindTarget>();
        }

        private void thenForceIsAddedToTestRigidbody()
        {
            float fAppliedForce = m_windTarget.rigid.velocity.magnitude;
            Assert.True(fAppliedForce > 0);
        }

        private void thenForceIsAppliedInExpectedDirection()
        {
            Vector3 v3ExpectedDirection = m_windArea.v3NormalizedForceDirection.normalized;
            Vector3 v3ActuelDirection = m_windTarget.rigid.velocity.normalized;
            Assert.AreEqual(v3ExpectedDirection, v3ActuelDirection);
        }

        private void thenTheWindTargetsMaxSpeedIsNotExceeded()
        {
            float fMaxSpeed = m_windTarget.fMaxSpeed;
            float fActualSpeed = m_windTarget.rigid.velocity.magnitude;
            Assert.True(fActualSpeed <= fMaxSpeed, $"{fActualSpeed} is larger than {fMaxSpeed}");
        }

        private void thenTheForceDirectionIsNormalized()
        {
            float fExpected = 1;
            float fActual = m_windArea.v3NormalizedForceDirection.magnitude;
            Assert.AreEqual(fExpected, fActual);
        }
    }
}