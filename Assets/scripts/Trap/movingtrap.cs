using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingtrap : MonoBehaviour
{
    CircleCollider2D circlecollider2D;
    public float rightMax = 2.0f; //좌로 이동가능한 (x)최대값

    public float leftMax = -2.0f; //우로 이동가능한 (x)최대값

    float currentPosition; //현재 위치(x) 저장

    public float direction = 3.0f; //이동속도+방향
    float current;

    void Start()
    {
       circlecollider2D=GetComponent<CircleCollider2D>();
       currentPosition = transform.position.x;
       current=currentPosition;
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().takedamage(10);
        }
    }
    void Update()

    {
        currentPosition += Time.deltaTime * direction;
        if (currentPosition >= current + rightMax) //현재 위치가 오른쪽으로 이동 가능한 값보다 크거나 같으면
        {
            direction *= -1; //방향 반전
            currentPosition = current + rightMax; //현재 위치 변경
        }
        else if (currentPosition <= current + leftMax) //현재 위치가 왼쪽으로 이동가능한 값보다 크거나 같으면
        {
            direction *= -1;
            currentPosition = current + leftMax;
        }
        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z); //위치를 계산된 위치로 이동
}








}
