﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{

    public float firerate;

    public float dmg;

    public LayerMask notToHit;

    private float TimeToFire = 0;

    public Transform firepoint;

    public Transform bullettrailPrefab;
    
    public AudioClip SoundShoot;

    //public Joueurblesse player;


    private void Awake()
    {
        firepoint = transform.GetChild(0);
    }


    void Update()
    {
        if (firerate == 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
        else if (Input.GetMouseButton(0) && Time.time > TimeToFire)
        {
            TimeToFire = Time.time + 1 / firerate;
            Shoot();
            
        }
    }
    private void Shoot()
    {
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePosition = new Vector2(mousePositionWorld.x, mousePositionWorld.y);

        Vector2 Firepointposition = new Vector2(firepoint.position.x, firepoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(Firepointposition, mousePosition - Firepointposition, Mathf.Infinity, notToHit);

        Debug.DrawLine(Firepointposition, (mousePosition - Firepointposition) * 1000);

        Effect();

        GetComponent<AudioSource>().PlayOneShot(SoundShoot);

        /*if (hit.collider != null)
        {
            if (hit.collider.tag.Equals("Enemy"))
            {
                Fight enemy = hit.collider.gameObject.GetComponent<Fight>();
                player.Attaque(enemy);
            }
        }*/
    }

    private void Effect()
    {
        Instantiate(bullettrailPrefab, firepoint.position, firepoint.rotation);
    }
}
