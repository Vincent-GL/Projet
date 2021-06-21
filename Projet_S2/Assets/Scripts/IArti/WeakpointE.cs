using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakpointE : MonoBehaviour
{
    public GameObject ennemi; // cette variable est initialisé directement dans l'interface d'unity via l'onglet inspector 
    BoxCollider2D BDennemi;
    BoxCollider2D BDplayer;
    GameObject player;
    Rigidbody2D bodyplayer;
    public int health;
    private int countdown = 0;
    //  public GameObject deatheffect;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        BDennemi = GetComponent<BoxCollider2D>();
        BDplayer = player.GetComponent<BoxCollider2D>();
        bodyplayer = player.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {/*
        if (BDennemi.IsTouching(BDplayer))
        {
            bodyplayer.velocity += new Vector2(0, 2f);
            if (countdown <= 0)
            {
                countdown += 5;
                health--;
            }
            countdown += 5;
            health--; //ceci permet de produire un effet de rebond tout en blessant l'ennemi
            if (health <= 0)
            {
                //  Instantiate(deatheffect, transform.position, Quaternion.identity);
                GameObject.Destroy(ennemi);
            }
        }
        if (countdown > 0)
        {
            countdown--;
        }
        if (health <= 0)
        {
            //  Instantiate(deatheffect, transform.position, Quaternion.identity);
            GameObject.Destroy(ennemi);
        }*/

        if (BDennemi.IsTouching(BDplayer))
        {
            bodyplayer.velocity += new Vector2(0, 2f);
            GameObject.Destroy(ennemi);
        }
    }/*
    void OnTriggerEnter2D(Collider2D cible)
    {
        if(cible.tag== "Player")
        {
            bodyplayer.velocity += new Vector2(0, 2f);
            health -= 10;
        }
        if(cible.tag=="bullet")
        {
            health -= 5;
        }
        if(health<=0)
        {
            GameObject.Destroy(ennemi);
        }

    }*/
}
