using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolt : MonoBehaviour
{
    public float speed;
    BoxCollider2D coll;
    Animator anim;

    void Start()
    {
        coll=GetComponent<BoxCollider2D>();
        Invoke("DestoryBolt", 1);
        anim=GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
    }

    void DestoryBolt()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Monster")
        {
            collision.GetComponent<MonsterHP>().takedamage(8);
            Destroy(gameObject);
        }
    }
}
