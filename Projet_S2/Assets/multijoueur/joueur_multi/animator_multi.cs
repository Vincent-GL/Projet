using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon;


public class animator_multi : MonoBehaviourPunCallbacks
{ 
    private Animator Animat;
    private mouv player;
    public StateAnim state;

    void Start()
    {
        Animat = GetComponent<Animator>();
        player = GetComponent<mouv>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            bool run = x == 1 || x == -1;
            if (run && player.Grounded)
            {
                state = StateAnim.course;


            }
            else if (!run && player.Grounded)
            {
                state = StateAnim.idle;


            }
            if (!player.Grounded)
            {
                state = StateAnim.jump;


            }
            Animation();
        }
    }
    private void Animation()
    {
        switch (state)
        {
            case StateAnim.idle:
                Animat.SetBool("idle", true);
                Animat.SetBool("course", false);
                Animat.SetBool("jump", false);
                break;
            case StateAnim.course:
                Animat.SetBool("course", true);
                Animat.SetBool("jump", false);
                Animat.SetBool("idle", false);
                break;
            case StateAnim.jump:
                Animat.SetBool("jump", true);
                Animat.SetBool("idle", false);
                Animat.SetBool("course", false);
                break;
        }
    }
}
