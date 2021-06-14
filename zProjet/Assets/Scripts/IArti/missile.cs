using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{

    private float speed = 10f;
    public Rigidbody2D rb;
    GameObject cible;
    Vector2 movedir;
    // Start is called before the first frame update
    void Start()
    {
        cible = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        movedir = (cible.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(movedir.x, movedir.y);
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
