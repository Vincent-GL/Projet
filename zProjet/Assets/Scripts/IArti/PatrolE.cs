using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public Transform[] chemin;
    private int destination;
    private Transform positionpro;
    int longueur;
    // Start is called before the first frame update
    void Start()
    {
        positionpro = chemin[destination];
        longueur = chemin.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = positionpro.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, positionpro.position)<0.2f)
        {
            destination = (destination + 1) % longueur;
            positionpro = chemin[destination];
        }
    }
}
