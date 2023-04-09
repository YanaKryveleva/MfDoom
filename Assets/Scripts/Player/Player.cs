using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float JumpForce = 1f;
    private float koefficient;
    private int health;
    private Rigidbody2D _rigidbody;
    private int countClick;
    private bool isCanJump = true;
   // public int cerealBox = 0;

    public float CurrentScore
    {
       get => _currentScore;
        set //устанавливаем сеттер, то есть это тозначение которое будет передаваться в другие классы
        {
            _currentScore = value;
            ScoreCounting?.Invoke(value); //осздаем событие
            
        }
    }

    public int cerealBox
    {
        get => _cerealBoxesCount;
        set
        {
            _cerealBoxesCount = value;
            CerealsCount?.Invoke(value);
        }

    }
    public int FinishScore;
    private float _currentScore;

    public Action<float> ScoreCounting;
    private int _cerealBoxesCount;
    
    public Action<int> CerealsCount;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    

    private void Update()
    {
       CurrentScore += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isCanJump)
        {
           
            switch (countClick)
            {
                case 0: koefficient = 1.25f;
                    break;
                case 1: koefficient = 0.5f;
                    break;
                case 2: koefficient = 0.25f;
                    break;
            } 
            
            
            Debug.Log("I'm here");
            _rigidbody.AddForce(Vector2.up * JumpForce * koefficient, ForceMode2D.Impulse); //ForceMode2D.Force - параметр
            countClick++;
            ClickCounter();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<MyFloor>())
        {
            isCanJump = true;
            countClick = 0;
        }


        if (col.gameObject.GetComponent<NoseObstacle>())
        {
            health--;
            if (health == 0)
            {
                Dead().Forget();
                
            }
            
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out CerealBox cereal))
        {
            cerealBox++;
            cereal.gameObject.SetActive(false);
        }

    }

    private void OnEnable() //onenable срабатывает каждй раз при включении перса (те объекта на котором висит скрипт)
    {
        health = 1;
        CurrentScore = 0;
        cerealBox = 0;
    }

    private void ClickCounter()
    {
        if (countClick == 3)
        {
            isCanJump = false;
        }
    }

    private void DoomsRealState()
    {
        
    }

    private async UniTaskVoid Dead()
    {
        await UniTask.Delay(150);
        gameObject.SetActive(false);
        FinishScore = Mathf.RoundToInt(CurrentScore);
        GameManager.Instance.Death();
        Debug.Log("Game Over:((");
       // Time.timeScale = 0; //игра остнавливается
    }
}
