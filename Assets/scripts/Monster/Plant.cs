using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float curTime;
    public float coolTime=2;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public GameObject playerhp;
    public GameObject playertransform;

    void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {

        Vector2 leftVec=new Vector2(rigid.position.x + -0.1f, rigid.position.y);
        Vector2 rightVec=new Vector2(rigid.position.x + 0.1f, rigid.position.y);
        
        float vec=playertransform.transform.position.x - transform.position.x;
        if(vec>0)
            spriteRenderer.flipX=true;
        else if(vec<0)
            spriteRenderer.flipX=false;

        if(curTime<=0)
        {
            RaycastHit2D leftattackHit=Physics2D.Raycast(leftVec, Vector3.left, 0.7f, LayerMask.GetMask("Player"));
            if(leftattackHit.collider != null)
            {
                MyAnimSetTrigger("attack");
                if(leftattackHit.collider!=null)
                    playerhp.GetComponent<PlayerHP>().takedamage(20);
                curTime=coolTime;

            }
            //오른쪽 공격 인식
            RaycastHit2D rightattackHit=Physics2D.Raycast(rightVec, Vector3.right, 0.7f, LayerMask.GetMask("Player"));
            if(rightattackHit.collider != null) // 플레이어가 있으면 뒤집기 크기
            {
                MyAnimSetTrigger("attack");
                if(rightattackHit.collider!=null)
                    playerhp.GetComponent<PlayerHP>().takedamage(20f);
                curTime=coolTime;

            }

        }
        else
        {
            curTime-=Time.deltaTime;
        }

    }

    void MyAnimSetTrigger(string AnimName) 
    {
        if(!IsPlayingAnim(AnimName)) //애니재생중이 아니라면
        {
            anim.SetTrigger(AnimName); //애니메이션 트리거 실행
        }
    }

    bool IsPlayingAnim(string AnimName) //애니메이션이 재생 중인지 판단
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName(AnimName))//애니메잉션이 시작 중이라면
        {
            return true; //true 리턴
        }
        return false; //재생 중이 아니라면 false리턴
    }

}
