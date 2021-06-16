using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggammo : MonoBehaviour
{
    private float speed = 10f;
    public Rigidbody2D rb;
    private int countdown;
    void Start()
    {
        if (Random.Range(0f, 2f) > 1f)
        {
           rb.velocity = -transform.up * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
            rb.SetRotation(30f);
        }
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
