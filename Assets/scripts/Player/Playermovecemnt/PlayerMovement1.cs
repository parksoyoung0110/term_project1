using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    //바닥 체크를 위한 변수
    public Transform groundChkFront;
    public Transform groundChkBack;
    public bool isGround;

    //벽을 위한 변수
    public Transform wallChk;
    public float wallchkDistance;
    public LayerMask w_Layer;
    public bool isWall;
    public float slidingSpeed;
    public float wallJumpPower;
    public bool isWallJump;


    public float runSpeed;
    float isRight=1;

    public float input_x;


    public float chkDistance;
    public float jumpPower=1;
    public LayerMask g_Layer;

    public AudioSource ad;
    public AudioClip jump;

    void Start()
    {
        rigid=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    void Update()
    {
        input_x=Input.GetAxis("Horizontal");

        bool ground_front=Physics2D.Raycast(groundChkFront.position, Vector2.down, chkDistance, g_Layer);
        bool ground_back=Physics2D.Raycast(groundChkFront.position, Vector2.down, chkDistance, g_Layer);

        if(!isGround&&(ground_front || ground_back))
            rigid.velocity=new Vector2(rigid.velocity.x, 0);
        
        if(ground_front||ground_back)
            isGround=true;
        else
            isGround=false;

        anim.SetBool("isGround", isGround);

        

        isWall= Physics2D.Raycast(wallChk.position, Vector2.right * isRight, wallchkDistance, w_Layer);
        anim.SetBool("isSliding", isWall);

        if(Input.GetAxisRaw("Jump")!=0)
        {
            anim.SetTrigger("jump");
        }

        if((input_x>0 )||(input_x<0 ))
        {
            anim.SetBool("run", true);
        }

        else if(input_x==0)
        {   
            anim.SetBool("run", false);
        }


        if(!isWallJump)
            if((input_x>0 && isRight<0)||(input_x<0 && isRight>0))
            {
                FlipPlayer();
            }
    }

    void FixedUpdate()
    {
        if(!isWallJump)
        {
            rigid.velocity=(new Vector2((input_x)*runSpeed, rigid.velocity.y));
        }
        

        if(isGround == true)
        {
            if(Input.GetAxis("Jump")!=0)
            {
                rigid.velocity=Vector2.up * jumpPower;
                ad.PlayOneShot(jump);
            }
        }

        if(isWall)
        {
            isWallJump=false;
            rigid.velocity=new Vector2(rigid.velocity.x, rigid.velocity.y * slidingSpeed);

            if(Input.GetAxis("Jump")!=0)
            {
                isWallJump=true;
                Invoke("FreezeX", 0.3f);
                rigid.velocity=new Vector2(-isRight*wallJumpPower, 0.9f*wallJumpPower);
                ad.PlayOneShot(jump);
                FlipPlayer();
            }
        }

    }

    void FreezeX()
    {
        isWallJump=false;
    }

    void FlipPlayer() //좌우 반전
    {
        transform.eulerAngles=new Vector3(0, Mathf.Abs(transform.eulerAngles.y-180),0);
        isRight=isRight*-1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundChkFront.position, Vector2.down*chkDistance);
        Gizmos.DrawRay(groundChkBack.position, Vector2.down*chkDistance);

        Gizmos.color=Color.blue;
        Gizmos.DrawRay(wallChk.position, Vector2.right*isRight*wallchkDistance);
    }
}
