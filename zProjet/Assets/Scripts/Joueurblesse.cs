using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueurblesse : MonoBehaviour
{
    public Rigidbody2D rb;
    public int health = 5;
    public Vector3 spawnPoint;
    public int lives;
    public void Hurt(bool right)// ajouter un int pour differencier le nombre de dégats infligés ?
    {
        health--;
        if (health <= 0)
        {
            IsDead();
            lives--;
            health = 5;
        }
        else
            Isknocked(right);
    }

    void IsDead()
    {
        this.transform.position = spawnPoint;
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
