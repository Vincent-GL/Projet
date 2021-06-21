using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Joueurblesse : MonoBehaviour
{
    public Rigidbody2D rb;
    public int health = 5;
    public Vector3 spawnPoint;
    public int lives;
    public healthbar healthba;
    public GameObject gameover;
    public float dmg = 1;

    void Start()
    {
        healthba.SetMaxHealth(health);
        gameover.SetActive(false);
    }
    public void Hurt(bool right)// ajouter un int pour differencier le nombre de dégats infligés ?
    {
        health--;
        if (health <= 0)
        {
            IsDead();            
        }
        else
        {
            Isknocked(right);
            healthba.SetHealth(health);
        }
    }

    void IsDead()
    {
        this.transform.position = spawnPoint;
        health = 5;
        lives--;
        healthba.SetHealth(health);
        healthba.SetLives(lives);
        if (lives == 0)
        {
            Time.timeScale = 0; // pour game over
            gameover.SetActive(true);
        }
    }
    
    public void Replay() // game over
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Respawn"))
            IsDead();
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
        for(int i=0;i<3;i++)
        {
            rb.velocity = force;
        }
    }

    

    public void Attaque(Fight ennemy)
    {
        ennemy.GetDmg(dmg);
    }
}
