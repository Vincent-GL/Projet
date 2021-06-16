using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingE : MonoBehaviour
{
    float MinDistance;
    GameObject player;
    Rigidbody2D playerRB;
    Rigidbody2D enemyRB;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        while(Vector2.Distance(playerRB.position,enemyRB.position)<MinDistance)
        {
            Vector2 trajectoire = playerRB.position - enemyRB.position;
            enemyRB.position = trajectoire;
        }
    }
}
