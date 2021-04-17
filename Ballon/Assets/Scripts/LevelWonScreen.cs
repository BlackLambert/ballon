using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balloon
{
    public class LevelWonScreen : MimiBehaviour
    {
		public int iCollectabledFound { get; private set; }
		public int iMaxCollectables { get; private set; }
        public string strNextLevelName { get; private set; }

		public void init(int _iCollectablesFound, int _iMaxCollectables, string _strNextLevelName)
		{
            iCollectabledFound = _iCollectablesFound;
            iMaxCollectables = _iMaxCollectables;
            strNextLevelName = _strNextLevelName;
        }
    }
}