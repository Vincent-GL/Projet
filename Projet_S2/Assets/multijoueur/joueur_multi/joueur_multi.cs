﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon;
using UnityEngine.SceneManagement;
public class joueur_multi : MonoBehaviourPunCallbacks
{
    public float jumphigh = 7f;
   public  SpriteRenderer spr;
    public Text NomJoueur;
    public float speed=15f;
    //public float jumphigh;
     private bool IsGrounded = false;
    public Rigidbody2D rb;
    public GameObject Playercamera;
    public Animator anim;
    private void Awake()
    {
        if(photonView.IsMine)
        {
            NomJoueur.text = PhotonNetwork.NickName;
            Playercamera.SetActive(true);
        }
        else
        {
            NomJoueur.text = photonView.Owner.NickName;
            NomJoueur.color = Color.red;
        }
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            CheckInput();
            if (transform.position.y < -10f)
            {
                    PhotonNetwork.DestroyAll();
                   GameManager.instance.gamecamera.SetActive(true);
                GameManager.instance.gamecanvas.SetActive(true);

                //  GameManager.instance.LeaveRoom();
                //  PhotonNetwork.LeaveLobby();
                // SceneManager.LoadScene(0);
            }
        }

        
    }
    private void CheckInput()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * speed * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spr.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            spr.flipX = false;
        }

        if (Input.GetKeyDown("space") && IsGrounded)
        {
            jump();
        }
    }
    public void jump()
    {
        rb.velocity += new Vector2(0, jumphigh);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("sol"))
        {
            IsGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("sol"))
        {
            IsGrounded = false;
        }
    }
}
  
   // public static GameObject LocalPlayerInstance;
   /* void Awake()
    {
        NomJoueur.text = PhotonNetwork.NickName;
        if(photonView.IsMine)
        {
           LocalPlayerInstance = this.gameObject;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown("space") && IsGrounded)
        {
            jump();
        }
    }

    public void jump()
    {
        rb.velocity += new Vector2(0, jumphigh);
    }

    //Mouvement gauche/droite
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
        Vector2 rl = new Vector2(moveHorizontal, 0);
        rb.AddForce(rl);
        if(moveHorizontal<0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //Conditions de saut
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("sol"))
        {
            IsGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("sol"))
        {
            IsGrounded = false;
        }
    }*/
//}
