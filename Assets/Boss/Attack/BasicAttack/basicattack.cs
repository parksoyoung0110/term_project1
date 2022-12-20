using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicattack : MonoBehaviour
{
    BoxCollider2D box;

    void Start()
    {
        box=GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            collision.GetComponent<PlayerHP>().takedamage(5);
    }
}
