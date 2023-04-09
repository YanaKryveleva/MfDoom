using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    
    private Button startButton;

    private void Awake()
    {
        startButton = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        GameManager.Instance.Game();
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartGame);
    }
}
