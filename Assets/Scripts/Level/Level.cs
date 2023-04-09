using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
   // private SpawnPointForMfDoom _pointMfDoom;
   // [SerializeField] private Player _player;
   // public Player Player => _player; //геттер (те в других классах Player будет получать значение _player из текущего класса Level)

    
    private void Awake()
    {
       // _pointMfDoom = GetComponentInChildren<SpawnPointForMfDoom>();
       
    }

    private void Start()
    {
        Debug.Log("Start from Level"); 
      //  Instantiate(_player.gameObject, _pointMfDoom.transform);
       

       
    }

    
}
