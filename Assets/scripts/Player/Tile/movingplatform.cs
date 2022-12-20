using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;

    void Start()
    {
        transform.position= startPos.position;
        desPos=endPos;
    }
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
        
        if(Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if(desPos == endPos)
            desPos=startPos;
            else
            desPos=endPos;
        }
    }

//발판위에서는 플레이어가 플랫폼의 부모가 되어 함께 이동하게 함
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
