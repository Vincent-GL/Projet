using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueurblesse : MonoBehaviour
{
    public Rigidbody2D rb;
    int health = 5;
    public void Hurt(bool right)// ajouter un int pour differencier le nombre de dégats infligés ?
    {
        health--;
        Isknocked(right);
        if(health<=0)
        {
            IsDead();
        }

    }

    private void IsDead()
    {
    }
    public void IsHealed(int amount)
    {
        health += amount;
        if(health>5)
        { health = 5; }
    }
    private void Isknocked(bool right)//si vrai le joueur est repoussé à droite sinon à gauche
    {
        Vector2 force;
        if (right)
        {
            force = new Vector2(4, 8);
        }
        else
        {
             force = new Vector2(-4, 8);
        }
        for(int i=0;i<4;i++)
        {
            rb.velocity = force;
        }
    }
}
