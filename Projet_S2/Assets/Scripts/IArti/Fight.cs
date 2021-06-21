using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public float PV = 6;
    public bool Alive { get { return PV > 0; } }

    public void GetDmg(float dmg)
    {
        PV -= dmg;

        if (!Alive)
        {
            Destroy(gameObject);
        }
        Debug.Log("aie");
    }   

    
}
