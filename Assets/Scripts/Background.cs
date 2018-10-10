﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform neighbour;
    public void Move()
    {
        transform.Translate(Vector2.left * speed * Time.smoothDeltaTime);
    }

    public void SnapToNeighbour()
    {
        transform.position = new Vector2(neighbour.position.x, neighbour.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Reset")
            SnapToNeighbour();
    }
    
}
    