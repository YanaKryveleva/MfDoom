using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBox : MonoBehaviour
{
    private float speed = 0.002f;
    private void Update()
    { 
        transform.Translate(Vector2.left * speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<DestroyerForCereals>())
        {
            gameObject.SetActive(false);
        }
    }
}
