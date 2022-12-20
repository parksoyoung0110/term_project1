using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yaxisbullet : MonoBehaviour
{
    public float speed=1000;

    Vector3 where;

    CircleCollider2D bulletnotice;
    SpriteRenderer sr;
    public float vec;
    public  GameObject yaxis;

    void Awake()
    {
        bulletnotice=GetComponent<CircleCollider2D>();
        sr=GetComponent<SpriteRenderer>();
        where=GameObject.FindGameObjectWithTag("Yaxis").GetComponent<Yaxis>().whereToatk;
    }

    public Vector3 far;

    void Start()
    {
        Vector3 dir = where - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * Time.deltaTime * speed*5);
        float vec=gameObject.transform.position.x - where.x;
        if(vec>0)
        {
            sr.flipX=true;
        }
        else if(vec<0)
        {
            sr.flipX=false;
        }
            
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player") 
        {
            collision.GetComponent<PlayerHP>().takedamage(20);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag=="End")
             Destroy(gameObject);

        if(collision.gameObject.tag=="Ground")
             Destroy(gameObject);
    }
}
