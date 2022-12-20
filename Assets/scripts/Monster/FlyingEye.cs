using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public GameObject bullet;
    public float cooltime;
    private float currenttime;
    void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
        Invoke("Think", 1); // 시작하면서 5초간 생각하기 
        anim=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {

        //움직임
        rigid.velocity=new Vector2(nextMove*1.5f, rigid.velocity.y);

        //밑에 땅이 있는지 raycast로 체크해서 비어있으면 돌기
        Vector2 frontVec=new Vector2(rigid.position.x + nextMove*0.3f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));
        RaycastHit2D rayHit=Physics2D.Raycast(frontVec, Vector3.down, 3f, LayerMask.GetMask("Ground"));
        if(rayHit.collider == null)
            Turn();
        
        //앞에 땅이 있으면 돌아가기
        //왼쪽
        if(nextMove == -1)
        {
            Debug.DrawRay(frontVec, Vector3.left, new Color(0,1,0));
            RaycastHit2D rayleftHit=Physics2D.Raycast(frontVec, Vector3.left, 1, LayerMask.GetMask("Ground"));
            if(rayleftHit.collider != null)
                Turn();

        }
        else if(nextMove ==1) //오른쪽
        {
            Debug.DrawRay(frontVec, Vector3.right, new Color(0,1,0));
            RaycastHit2D rayrightHit=Physics2D.Raycast(frontVec, Vector3.right, 1, LayerMask.GetMask("Ground"));
            if(rayrightHit.collider != null)
                Turn();
        }

        //플레이어 인식
        Vector2 leftVec=new Vector2(rigid.position.x + -0.1f, rigid.position.y-2);
        Vector2 rightVec=new Vector2(rigid.position.x + 0.1f, rigid.position.y-2);
        Vector2 sumVec=leftVec+rightVec;
        RaycastHit2D left=Physics2D.Raycast(leftVec, Vector3.left, 2f, LayerMask.GetMask("Player"));
        RaycastHit2D right=Physics2D.Raycast(rightVec, Vector3.right, 2f, LayerMask.GetMask("Player"));
        if(left.collider || right.collider !=null) //플레이어가 있으면
        {
            if(currenttime<=0)
            {
                
                anim.SetTrigger("attack");   
                Debug.Log("bullet");     
                Instantiate(bullet, transform.position, transform.rotation); //flame발사
                currenttime=cooltime;
            }
           
        }
         currenttime-=Time.deltaTime;
    }

    void Turn() //오른쪽 왼쪽 뒤집기
    {
        nextMove=nextMove*(-1);
        spriteRenderer.flipX= nextMove ==1;

        CancelInvoke(); //뒤집고 생각하기
        Invoke("Think", 5);
    }

    void Think() //몬스터 주 Ai
    {
        //다음 동작을 -1(왼), 1(오), 0(정지) 중에 무작위 선택
        nextMove = Random.Range(-1,2);

        //생각하는 시간 랜덤으로!
        float nextThinkTime=Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);

        //Sprite run애매이션 파라미터를 trigger가 아니라 int로 설정!!)
        anim.SetInteger("Flight", nextMove);        

        //Flip Sprite
        if(nextMove!=0)
        {
            spriteRenderer.flipX = nextMove ==1;
        }
    }

}
