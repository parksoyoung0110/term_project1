using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crobullet : MonoBehaviour
{

    public float speed;
    Transform target;
    BoxCollider2D coll;

    void Start()
    {
        Invoke("Destorycross", 1);
    }
    void Awake()
    {
        target=cross.ob.GetComponent<Transform>();//플레이어의 위치 찾기
        coll=GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Monster")
        {
            collision.GetComponent<MonsterHP>().takedamage(6);
            Destorycross();
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void Destorycross()
    {
        Destroy(gameObject);
    }
}
