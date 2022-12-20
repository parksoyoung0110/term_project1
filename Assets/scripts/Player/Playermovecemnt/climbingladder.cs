using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbingladder : MonoBehaviour
{
    public bool isLadder;

    void OnTriggerEnter2D(Collider2D collision) //사다리 인식 시 true반환
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder=true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) // 사다리 인식 끝난 후 false 반환
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder=false;
        }
    }

    Rigidbody2D rigid;

    void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
    }

    public float speed = 5f;

    void FixedUpdate()
    {
        if(isLadder)
        {
            float ver = Input.GetAxis("Vertical");
            rigid.gravityScale=0;
            rigid.velocity = new Vector2(rigid.velocity.x, ver*speed);
        }
        else
        {
            rigid.gravityScale=1f;
        }
    }
}

