using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    private TextMeshProUGUI _score;
    private TextMeshProUGUI _countCerealBoxes;
    private Player _player;
    

    private void Awake()
    {
       _score = GetComponentInChildren<Score>().GetComponent<TextMeshProUGUI>();
      // _player = FindObjectOfType<Player>();
       _countCerealBoxes = GetComponentInChildren<CountCerealBoxes>().GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        Debug.Log("Start from GamePanel");
        _player.ScoreCounting += ScoreCount;
        _player.CerealsCount += CountingCerealBoxxxs;
        
    }

    private void ScoreCount(float obj)
    {
        _score.text = (Mathf.RoundToInt(obj)).ToString(); //на геймпанель передает постоянно обновляющееся значение счета которое обновляется в классе Player в Update
    }
    
    private void CountingCerealBoxxxs(int obj)
    {
        _countCerealBoxes.text = obj.ToString();
    }
    

    private void OnDestroy()
    {
        _player.ScoreCounting -= ScoreCount;
        _player.CerealsCount -= CountingCerealBoxxxs;
    }
}
