using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmove : MonoBehaviour
{
   
    
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;

        float rotz = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0f, 0f, rotz-25);

        float x = Input.GetAxisRaw("Horizontal");
        if (x == -1)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (x == 1)
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }

        if (GetComponent<SpriteRenderer>().flipY == false)
            transform.rotation = Quaternion.Euler(0f, 0f, rotz - 30);
        else if (GetComponent<SpriteRenderer>().flipY == true)
            transform.rotation = Quaternion.Euler(0f, 0f, rotz +30);

    }
}
