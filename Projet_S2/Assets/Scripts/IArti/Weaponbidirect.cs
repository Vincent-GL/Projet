using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponbidirect : MonoBehaviour
{
    public Transform firepoint;//le point d'où partent les projectiles
    public GameObject projectile;//les projectiles
    public float nextfire = 0f;
    public float fireRate = 0.5f;
    void Update()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;
            Instantiate(projectile, firepoint.position, firepoint.rotation);
        }
    }
}
