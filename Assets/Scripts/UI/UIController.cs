using System;
using UnityEngine;

namespace UI
{
    public enum Panel
    {
        Start,
        Game,
        Fail
    }
    
    public class UIController : MonoBehaviour
    {

        private StartPanel _startPanel;
        private GamePanel _gamePanel;
        private FailPanel _failPanel;

        private void Awake()
        {
            _startPanel = GetComponentInChildren<StartPanel>(true);
            _gamePanel = GetComponentInChildren<GamePanel>(true);
            _failPanel = GetComponentInChildren<FailPanel>(true);
        }

        public void ChangePanel(Panel panel)
        {
            _startPanel.gameObject.SetActive(panel == Panel.Start);
            _gamePanel.gameObject.SetActive(panel == Panel.Game);
            _failPanel.gameObject.SetActive(panel == Panel.Fail);
        }
        
    }
}