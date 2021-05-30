using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeritageAI : MonoBehaviour
{
    public int health;//le nombre de coups que prend l'ennemi
   // public int damagedealt;//le nombre de dommages infligé au joueur
   // public float speed;
    public GameObject deatheffect;

    public void Death()
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
