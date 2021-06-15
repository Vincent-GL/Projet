using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolE : MonoBehaviour
{
    public float speed;
    public Transform[] chemin;
    private int destination;
    private Transform positionpro;
    int longueur;
    public Animator an;
    void Start()
    {
        an = GetComponent<Animator>();
        positionpro = chemin[destination];
        longueur = chemin.Length;
    }
    void Update()
    {
        Vector3 dir = positionpro.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, positionpro.position) < 0.2f)
        {
            destination = (destination + 1) % longueur;
            positionpro = chemin[destination];
            if(an!=null)
            {
                
                an.SetBool("turn", !(an.GetBool("turn")));
            }
        }
    }
}
