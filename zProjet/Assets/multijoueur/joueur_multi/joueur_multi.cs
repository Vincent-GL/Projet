using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class joueur_multi : MonoBehaviourPunCallbacks
{
    public Text NomJoueur;
    public float speed;
    public float jumphigh;
    public Rigidbody2D rb;
    private bool IsGrounded = false;
    public static GameObject LocalPlayerInstance;
    void Awake()
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
    }
}
