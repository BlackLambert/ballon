using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class CollectableImagesDisplayer : MimiBehaviour
    {
        [SerializeField]
        private LevelWonScreen m_screen;
        [SerializeField]
        private CollectableImage m_goCollectableImagePrefab;
        [SerializeField]
        private float m_fStartDelay = 1f;
        [SerializeField]
        private float m_fInbetweenDelay = 0.5f;
        [SerializeField]
        private Transform m_transHook;

        private List<CollectableImage> m_liCollectableImages = new List<CollectableImage>();

        protected virtual void Start()
		{
            createImages();
            StartCoroutine(startFill());
		}

		private void createImages()
		{
            for (int i = 0; i < m_screen.iMaxCollectables; i++)
                createImage();
		}

		private void createImage()
		{
            CollectableImage image = Instantiate(m_goCollectableImagePrefab);
            m_liCollectableImages.Add(image);
            image.trans.SetParent(m_transHook, false);
        }

        private IEnumerator startFill()
		{
            yield return new WaitForSeconds(m_fStartDelay);
            for (int i = 0; i < m_screen.iCollectabledFound; i++)
			{
                m_liCollectableImages[i].SetFilled();
                yield return new WaitForSeconds(m_fInbetweenDelay);
            }
		}
	}
}