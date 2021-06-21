using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tircastle : MonoBehaviour
{
    private float speed = 4f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity =- transform.right * speed*(Random.Range(0f,7f));
    }

    void OnTriggerEnter2D(Collider2D cible)
    {
        Joueurblesse joueur = cible.GetComponent<Joueurblesse>();
        if (joueur != null)//la cible touchée est le joueur
        {
            joueur.Hurt(true);
        }
        Destroy(gameObject);
    }
}
