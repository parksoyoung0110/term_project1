using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emitbul : MonoBehaviour
{
    public float speed = 3f;
    CircleCollider2D circle;

    private void Start()
    {
        circle=GetComponent<CircleCollider2D>();
        //생성으로부터 2초 후 삭제
        Destroy(gameObject,10f);
    }

    private void Update()
    {
        //두번째 파라미터에 Space.World를 해줌으로써 Rotation에 의한 방향 오류를 수정함
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
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
