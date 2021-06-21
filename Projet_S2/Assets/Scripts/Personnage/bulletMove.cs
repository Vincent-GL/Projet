using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public float speed = 10;
    
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        Destroy(gameObject, 1);
    }
}
