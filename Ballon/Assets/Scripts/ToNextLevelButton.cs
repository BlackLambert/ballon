using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Balloon
{
    public class ToNextLevelButton : MimiBehaviour
    {
        [SerializeField]
        private Button m_button;
        [SerializeField]
        private LevelWonScreen m_screen;

        protected virtual void Start()
		{
            m_button.onClick.AddListener(onClick);
        }

		private void onClick()
		{
            SceneManager.LoadScene(m_screen.strNextLevelName, LoadSceneMode.Single);
		}
	}
}