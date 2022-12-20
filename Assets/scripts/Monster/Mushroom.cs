using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public GameObject traceTarget;
    Animator anim;
    Rigidbody2D rigid;

    public bool isTracing;
    public float movePower = 0;
    int movementFlag=0; // 0=Idle, 1=left, 2:right
    SpriteRenderer spriteRenderer;
    public float curTime;
    public float coolTime=2;
    public GameObject playerhp;

    void Start()
    {
        anim=GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        StartCoroutine("ChangeMovement");
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move();
        Attack();
    }

    public GameObject playertransform;

    void Move()
    {
        Vector3 moveVelocity=Vector3.zero;

        if(isTracing) //플레이어가 감지되고 있을 때
        {
            Vector3 playerPos=traceTarget.transform.position; //플레이어의 위치

            if(playerPos.x<transform.position.x) //플레이어가 왼쪽에 있을 때
            {
                moveVelocity=Vector3.left;
                transform.localScale=new Vector3(4,4,1);
            }
            else if(playerPos.x>transform.position.x) //플레이어가 오른쪽에 잇을 때
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-4,4,1);
            }
        }
        else //플레이어가 감지되고 있지 않을 때
        {
            if(movementFlag==1)
            { 
            
            Vector2 leftVec=new Vector2(rigid.position.x + 1f, rigid.position.y);
            Debug.DrawRay(leftVec, Vector3.left, new Color(0,1,0));
            RaycastHit2D rayHit=Physics2D.Raycast(leftVec, Vector3.down, 1, LayerMask.GetMask("Ground")); // 왼쪽에 땅이 있는지
            RaycastHit2D rayfrontHit=Physics2D.Raycast(leftVec, Vector3.left, 0.1f, LayerMask.GetMask("Ground")); // 왼쪽에 벽이 있는가

            if(rayHit.collider == null || rayfrontHit.collider != null){ //왼쪽에 땅이 없거나 벽이 있으면 오른쪽으로
                moveVelocity=Vector3.right;
                transform.localScale=new Vector3(-4,4,1);
                movementFlag=2;
                }

            else{
                moveVelocity=Vector3.left;
                transform.localScale=new Vector3(4,4,1);
            }
                
            }
        else if(movementFlag==2)
            {

            Vector2 rightVec=new Vector2(rigid.position.x + 1f, rigid.position.y);
            Debug.DrawRay(rightVec, Vector3.right, new Color(0,1,0));
            RaycastHit2D rayHit=Physics2D.Raycast(rightVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
            RaycastHit2D rayfrontHit=Physics2D.Raycast(rightVec, Vector3.right, 0.1f, LayerMask.GetMask("Ground"));

            if(rayHit.collider == null || rayfrontHit.collider!=null) //오른쪽에 땅이 없으면 왼쪽으로
            {
                moveVelocity=Vector3.left;
                transform.localScale=new Vector3(4,4,1);
                movementFlag=1;
            }     
            else
            {
                transform.localScale=new Vector3(-4,4,1);
                moveVelocity=Vector3.right;
            }
            
            }
        }

        transform.position += moveVelocity*movePower*Time.deltaTime;
    }

    public IEnumerator ChangeMovement() //ai코루틴
    {
        movementFlag=0;

        if(movementFlag==0)
            anim.SetBool("IsMoving", false);
        else
            anim.SetBool("IsMoving", true);
            
        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }

    void Attack()
    {
        Vector2 leftVec=new Vector2(rigid.position.x + -0.1f, rigid.position.y);
        Vector2 rightVec=new Vector2(rigid.position.x + 0.1f, rigid.position.y);
        
        float vec=playertransform.transform.position.x - transform.position.x;
        if(vec>0)
            transform.localScale=new Vector3(-4,4,1);
        else if(vec<0)
            transform.localScale=new Vector3(4,4,1);

        if(curTime<=0)
        {
            RaycastHit2D leftattackHit=Physics2D.Raycast(leftVec, Vector3.left, 0.7f, LayerMask.GetMask("Player"));
            if(leftattackHit.collider != null)
            {
                anim.SetTrigger("Attack");
                if(leftattackHit.collider!=null)
                    movePower=0;
                    playerhp.GetComponent<PlayerHP>().takedamage(20);
                curTime=coolTime;

            }
            //오른쪽 공격 인식
            RaycastHit2D rightattackHit=Physics2D.Raycast(rightVec, Vector3.right, 0.7f, LayerMask.GetMask("Player"));
            if(rightattackHit.collider != null) // 플레이어가 있으면 뒤집기 크기
            {
                anim.SetTrigger("Attack");
                if(rightattackHit.collider!=null)
                    movePower=0;
                    playerhp.GetComponent<PlayerHP>().takedamage(20f);
                curTime=coolTime;

            }
         }
        else
        {
            curTime-=Time.deltaTime;
        }
    }
}
