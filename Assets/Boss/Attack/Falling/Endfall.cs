using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endfall : MonoBehaviour
{
        CircleCollider2D circle;

        void Start()
    {
        circle=GetComponent<CircleCollider2D>();
    }

        void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player") 
        {
            collision.GetComponent<PlayerHP>().takedamage(20);
            Destroy(gameObject);
        }
    }



}
