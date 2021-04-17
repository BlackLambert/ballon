using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Balloon
{
    public class CollectablesCollector : MonoBehaviour
    {
        [SerializeField]
        private Level m_level;
        [SerializeField]
        private CollectablesPanel m_collectabledPanel;
        [SerializeField]
        private float m_fPanelDisplayTime = 3f;

        private List<Collectable> m_liCollectables;
        
        protected virtual void Start()
		{
            m_liCollectables = GameObject.FindObjectsOfType<Collectable>().ToList();
            foreach(Collectable collectable in m_liCollectables)
                collectable.evOnCollect += onCollect;
            m_level.iMaxCollectablesCount = m_liCollectables.Count;
        }

        protected virtual void OnDestroy()
		{
            foreach (Collectable collectable in m_liCollectables)
                collectable.evOnCollect -= onCollect;
        }

		private void onCollect(Collectable _collectable)
		{
            _collectable.evOnCollect -= onCollect;
            m_level.iCollectedCollectablesCount++;
            StartCoroutine(m_collectabledPanel.showTimed(m_fPanelDisplayTime));
        }
	}
}