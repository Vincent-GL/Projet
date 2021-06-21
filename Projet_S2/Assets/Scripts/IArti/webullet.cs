using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webullet : MonoBehaviour
{
    public int health = 2;
    public GameObject ennemi;
    void OnTriggerEnter2D(Collider2D cible)
    {
        //GameObject.Destroy(ennemi);
        
        if (cible.tag == "bullet")
        {
            health--; ;
        }
        if (health <= 0)
        {
            GameObject.Destroy(ennemi);
        }

    }
}
