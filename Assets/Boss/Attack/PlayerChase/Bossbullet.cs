using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossbullet : MonoBehaviour
{
    public float speed;
    Transform target;

    CircleCollider2D bulletnotice;
    SpriteRenderer sr;

    void Awake()
    {
        bulletnotice=GetComponent<CircleCollider2D>();
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//플레이어의 위치 찾기
        sr=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float vec=gameObject.transform.position.x - target.transform.position.x;
        if(vec>0)
            sr.flipX=true;
        else if(vec<0)
            sr.flipX=false;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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
