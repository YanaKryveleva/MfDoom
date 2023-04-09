using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FailPanel : MonoBehaviour
{
    private Button restartButton;
    private TextMeshProUGUI _finishScore;
    private Player _player;
    private TextMeshProUGUI _highScore;
   // private GameManager _gameManager;
    private void Awake()
    {
        restartButton = GetComponentInChildren<Button>();
        _finishScore = GetComponentInChildren<CurrentScore>().GetComponent<TextMeshProUGUI>();
        _highScore = GetComponentInChildren<HighScore>().GetComponent<TextMeshProUGUI>();
        _player = FindObjectOfType<Player>(true);
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnEnable()
    {
        _finishScore.text = _player.FinishScore.ToString();
        _highScore.text = GameManager.Instance.HighScore.ToString(); //синглтон
    }

    public void RestartGame()
    {
        GameManager.Instance.Restart();
    }

    private void OnDestroy()
    {
        restartButton.onClick.RemoveListener(RestartGame);
    }
}
