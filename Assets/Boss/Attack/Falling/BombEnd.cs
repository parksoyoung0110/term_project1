using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnd : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    BoxCollider2D box;
    public AudioSource ad;
    public AudioClip attack;

    void Start()
    {
        ad.PlayOneShot(attack);
        anim=GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        box=GetComponent<BoxCollider2D>();
        on=false;
    }

    public bool on;
    void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            rigid.constraints=RigidbodyConstraints2D.FreezePositionX;
            rigid.constraints=RigidbodyConstraints2D.FreezePositionY;
            anim.SetTrigger("bomb");
            Invoke("Destroy", 1.07f);
            on=true;
        }
        if(on)
        {
            if(collision.gameObject.tag =="Player") 
            {
                collision.GetComponent<PlayerHP>().takedamage(20);
            }
        }

    }

}
