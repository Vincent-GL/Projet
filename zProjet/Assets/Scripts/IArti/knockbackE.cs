using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockbackE : MonoBehaviour
{
    Joueurblesse playerscript;
    GameObject somePlayer;
    BoxCollider2D BoxCPlayer;
    Rigidbody2D RBodyPlayer;
    BoxCollider2D enemyBC;
    Rigidbody2D enemyRB;
    int countdown;
    void Start()
    {
        countdown = 0;
        enemyRB = GetComponent<Rigidbody2D>();
        somePlayer = GameObject.FindGameObjectWithTag("Player");
        playerscript = somePlayer.GetComponent<Joueurblesse>();
        BoxCPlayer = somePlayer.GetComponent<BoxCollider2D>();
        enemyBC = GetComponent<BoxCollider2D>();
        RBodyPlayer = somePlayer.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
            if (enemyBC.IsTouching(BoxCPlayer) && countdown<=0)
            {
            countdown += 10;
            if (enemyRB.transform.position.x < somePlayer.transform.position.x)
                {
                    playerscript.Hurt(true);
                
                    
                }
                else
                {
                    playerscript.Hurt(false);
                }
            }
        if(countdown>0)
        {
            countdown--;
        }
    }
}
