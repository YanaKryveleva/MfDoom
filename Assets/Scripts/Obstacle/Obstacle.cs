using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private DestroyerForBoxes _destroyerForBoxes;
    private float speed = 0.002f;
    private void Update()
    { 
        transform.Translate(Vector2.left * speed);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on collision enter of obstacle" + col.gameObject.name);
        if (col.gameObject.GetComponent<DestroyerForBoxes>())
        {
            gameObject.SetActive(false);
            
        }
    }
}
