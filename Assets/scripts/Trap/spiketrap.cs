using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiketrap : MonoBehaviour
{
    BoxCollider2D boxcollider2D;
    void Start()
    {
       boxcollider2D=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().takedamage(10);
        }
    }
}
