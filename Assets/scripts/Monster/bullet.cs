using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    Transform target;

    CircleCollider2D bulletnotice;
    public GameObject playerhp;


    void Awake()
    {
        bulletnotice=GetComponent<CircleCollider2D>();
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//플레이어의 위치 찾기
    }
    void Start()
    {
        Invoke("Des", 3);
    }

    void Update()
    {
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

    void Des()
    {
        Destroy(gameObject);
    }
}
