using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : MonoBehaviour
{
    public float movePower = 1f;
    int movementFlag=0; // 0=Idle, 1=left, 2:right

    Vector3 movement;
    Animator animator;
    Rigidbody2D rigid;
    public GameObject playerhp;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        animator=gameObject.GetComponentInChildren<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        boxCollider2D=GetComponent<BoxCollider2D>();
        StartCoroutine("ChangeMovement");
    }
    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        Vector3 moveVelocity= Vector3.zero;

        if(movementFlag==1)
        {
            
            Vector2 leftVec=new Vector2(rigid.position.x + -1f, rigid.position.y);
            Debug.DrawRay(leftVec, Vector3.down, new Color(0,1,0));
            RaycastHit2D rayHit=Physics2D.Raycast(leftVec, Vector3.down, 1, LayerMask.GetMask("Ground")); // 왼쪽에 땅이 있는지
            RaycastHit2D rayfrontHit=Physics2D.Raycast(leftVec, Vector3.left, 1, LayerMask.GetMask("Ground")); // 왼쪽에 벽이 있는가

            if(rayHit.collider == null || rayfrontHit.collider != null){ //왼쪽에 땅이 없거나 벽이 있으면 오른쪽으로
                moveVelocity=Vector3.right;
                transform.localScale=new Vector3(-5,5,1);
                movementFlag=2;
                }

            else{
                moveVelocity=Vector3.left;
                transform.localScale=new Vector3(5,5,1);
            }
                
        }
        else if(movementFlag==2)
        {

            Vector2 rightVec=new Vector2(rigid.position.x + 1f, rigid.position.y);
            Debug.DrawRay(rightVec, Vector3.down, new Color(0,1,0));
            RaycastHit2D rayHit=Physics2D.Raycast(rightVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
            RaycastHit2D rayfrontHit=Physics2D.Raycast(rightVec, Vector3.right, 1, LayerMask.GetMask("Ground"));

            if(rayHit.collider == null || rayfrontHit.collider!=null) //오른쪽에 땅이 없으면 왼쪽으로
            {
                moveVelocity=Vector3.left;
                transform.localScale=new Vector3(5,5,1);
                movementFlag=1;
            }     
            else
            {
                transform.localScale=new Vector3(-5,5,1);
                moveVelocity=Vector3.right;
            }
            
        }

        transform.position += moveVelocity*movePower*Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("20데미지받음!");
            playerhp.GetComponent<PlayerHP>().takedamage(20);
        }
    }

    
    IEnumerator ChangeMovement()
    {
        movementFlag=Random.Range(0,3);

        if(movementFlag==0)
            animator.SetTrigger("Idle");
        else
            animator.SetTrigger("IsMoving");
            
        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }
}
