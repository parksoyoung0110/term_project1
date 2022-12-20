using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beartrap : MonoBehaviour
{
    CompositeCollider2D compositeCollider2D;
    Animator anim;
    void Start()
    {
       compositeCollider2D=GetComponent<CompositeCollider2D>();
       anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Closed");
        if(collision.gameObject.tag =="Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().takedamage(10);
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetTrigger("Idle");
    }
}
