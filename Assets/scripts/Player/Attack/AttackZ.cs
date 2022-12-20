using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZ : MonoBehaviour
{

    SpriteRenderer sr;
    public GameObject mon;

    public Transform rightpos;
    public Transform leftpos;
    public Vector2 boxSize;

    public float curTime;
    public float coolTime=0.5f;

    public AudioSource ad;
    public AudioClip attack;
    
    void Awake()
    {
        sr=GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Attackz();
    }

    void Attackz()
    {
        if(curTime<=0) //쿨타임이 없으면
        {  
            if(Input.GetKeyDown(KeyCode.Z)) //z키로 공격하기 
            {
                gameObject.GetComponent<AnimatorPlayer>().AnimTrigger("Attack");
                ad.PlayOneShot(attack);
                if(!sr.flipX)
                {
                    Collider2D[] collider2Ds= Physics2D.OverlapBoxAll(rightpos.position, boxSize, 0);
                    foreach(Collider2D collider in collider2Ds)
                    {
                        if(collider.gameObject.tag=="Monster")
                        {
                            mon = collider.gameObject;
                            mon.GetComponent<MonsterHP>().takedamage(4f);
                        }
                        if(collider.gameObject.tag=="Boss")
                        {
                            mon = collider.gameObject;
                            mon.GetComponent<bossHP>().takedamage(4f);
                        }
                    }
                }
                else
                {
                    Collider2D[] collider2Ds= Physics2D.OverlapBoxAll(leftpos.position, boxSize, 0);
                    foreach(Collider2D collider in collider2Ds)
                    {
                        if(collider.gameObject.tag=="Monster")
                        {
                            mon = collider.gameObject;
                            mon.GetComponent<MonsterHP>().takedamage(4f);
                        }
                        if(collider.gameObject.tag=="Boss")
                        {
                            mon = collider.gameObject;
                            mon.GetComponent<bossHP>().takedamage(4f);
                        }
                    }
                }
                curTime=coolTime;
            }        
 
        }
        else
        {
            curTime-=Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(rightpos.position, boxSize);
        Gizmos.DrawWireCube(leftpos.position, boxSize);
    }
}
