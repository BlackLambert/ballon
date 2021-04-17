using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Balloon
{
    public class CollectablesText : MimiBehaviour
    {
		private const string c_text = "{0} / {1}";

        [SerializeField]
        private TextMeshProUGUI m_textField;
        [SerializeField]
        private Level _level;

        protected virtual void Start()
		{
			_level.evOnCollectedCollectablesCountChanged += updateText;
			_level.evOnMaxCollectablesCountChanged += updateText;
			updateText();
		}

		protected virtual void OnDestroy()
		{
			_level.evOnCollectedCollectablesCountChanged -= updateText;
			_level.evOnMaxCollectablesCountChanged -= updateText;
		}

		private void updateText()
		{
			m_textField.text = string.Format(c_text, _level.iCollectedCollectablesCount, _level.iMaxCollectablesCount);
		}
	}
}