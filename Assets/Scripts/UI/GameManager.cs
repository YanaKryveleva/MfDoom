using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //синглтон геймменеджера => в других классах не надо будет создавать ссылки на геймменеджера а мы сможем обратиться к нему просто так

    private UIController _uiController;
    
    [SerializeField] private Level _level;
    

   [SerializeField] private Player _player;

    private SpawnPointForMfDoom _pointMfDoom;
    
    private const string SAVE_KEY = "high_score";
    private const string Cereals_SAVE_KEY = "SummaryCereals";
 
    public int HighScore;
    public int SummaryCerealsCount;

    private void Awake()
    {
        if (Instance == null) //инстантиэйт синглотона (инстиантиэйт геймменеджера)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject); //(если существует геймобджект геймменеджера мы его дестроим)
        }
        _uiController = FindObjectOfType<UIController>();

        
    }

    private void Start()
    {
        _uiController.ChangePanel(Panel.Start); //
        LoadData();
    }
    
   

    public void Game()
    {

        _level = Instantiate(_level.gameObject).GetComponent<Level>();
        _pointMfDoom = FindObjectOfType<SpawnPointForMfDoom>();
        _player = Instantiate(_player.gameObject, _pointMfDoom.transform).GetComponent<Player>();
        _uiController.ChangePanel(Panel.Game);

      
       

    }

    public void Death()
    {
        if (_player.FinishScore > HighScore)
        {
            HighScore = _player.FinishScore;
        }
        _uiController.ChangePanel(Panel.Fail);

        _level.gameObject.SetActive(false);
        
        ClearScene();
        
    }

    public void Restart()
    {
        _level.gameObject.SetActive(true);
        _player.gameObject.SetActive(true);
        _uiController.ChangePanel(Panel.Game);
        
    }

    private void ClearScene()
    {
        var obstacles = FindObjectsOfType<Obstacle>(true);//true - найти то что выключано на сцене
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        var cerealBoxes = FindObjectsOfType<CerealBox>(true);
        foreach (var cerealBox in cerealBoxes) // cerealBox - просто название переменной (объекта) которые лежат в массиве-коллекции cerealBoxes
        {
         Destroy(cerealBox.gameObject);   
        }
    }

    private void SaveData()
    {
        SummaryCerealsCount += _player.cerealBox;
        PlayerPrefs.SetInt(SAVE_KEY, HighScore);
        PlayerPrefs.SetInt(Cereals_SAVE_KEY, SummaryCerealsCount);
      
    }

    private void LoadData()
    {
         HighScore = PlayerPrefs.GetInt(SAVE_KEY, 0);
         SummaryCerealsCount += PlayerPrefs.GetInt(Cereals_SAVE_KEY, 0);
         Debug.Log(HighScore);
         Debug.Log(SummaryCerealsCount);
    }

    /*
     private void LoadCereals()
     {
     CerealsAllCount = 
     }
     */
    
    
    private void OnDestroy()
    {
        SaveData();
    }

    // Update is called once per frame
   
}
