﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakpointE : MonoBehaviour
{
    public GameObject ennemi;
    BoxCollider2D BDennemi;
    BoxCollider2D BDplayer;
    GameObject player;
    Rigidbody2D bodyplayer;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        BDennemi = GetComponent<BoxCollider2D>();
        BDplayer = player.GetComponent<BoxCollider2D>();
        bodyplayer = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (BDennemi.IsTouching(BDplayer))
        {
            bodyplayer.velocity += new Vector2(0, 30f);
            GameObject.Destroy(ennemi);
        }
    }
}