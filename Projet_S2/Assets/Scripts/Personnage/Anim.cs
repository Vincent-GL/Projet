using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateAnim
{
    course,
    idle,
    grounded,
    jump
}

public class Anim : MonoBehaviour
{
    private Animator Animat;
    private mouv player;
    public StateAnim state;
    
    void Start()
    {
        Animat = GetComponent<Animator>();
        player= GetComponent<mouv>();
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        bool run = x == 1 || x == -1;
        if (run&&player.Grounded)
        {
            state = StateAnim.course;
            Debug.Log("cours");
            
        }
        else if (!run && player.Grounded)
        {
            state = StateAnim.idle;
            Debug.Log("rien");
            
        }
        if (!player.Grounded)
        {
            state = StateAnim.jump;
            Debug.Log("saute");
            
        }
        Animation();
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
