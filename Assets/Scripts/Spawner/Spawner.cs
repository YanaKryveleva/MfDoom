using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Obstacle _obstacle;
        [SerializeField] private CerealBox _cerealBox;
        [SerializeField] private float TimeCounter;
        [SerializeField] private float TimeCounter2;

        private SpawnPointHigh PointHighest;

      
        
        private float RandomPointForCereal;
        private float CurrentTime;
        private float CurrentTime2;


        private void Awake()
        {
            PointHighest = GetComponentInChildren<SpawnPointHigh>();
        }

        private void Start()
        {
            CurrentTime = TimeCounter;
            CurrentTime2 = TimeCounter2;
        }

        private void Update()
        {
            TimeCounter -= Time.deltaTime;
            TimeCounter2 -= Time.deltaTime;
            if (TimeCounter <= 0 )
            {
                InstantiateObstacle();
                TimeCounter = CurrentTime;
            }

            if (TimeCounter2 <= 0)
            {
                InstantiateCereals();
                TimeCounter2 = CurrentTime2;
            }
        }
        

        private void InstantiateObstacle()
        {
           Instantiate(_obstacle.gameObject, transform);
        }
        
        private void InstantiateCereals()
        {

            Instantiate(_cerealBox.gameObject, PointForCereal(), Quaternion.identity, transform);
        }

        private Vector2 PointForCereal()
        {
            RandomPointForCereal = Random.Range(transform.position.y + 1, PointHighest.transform.localPosition.y);
            return new Vector2(transform.position.x, RandomPointForCereal);
        }
    }
}
