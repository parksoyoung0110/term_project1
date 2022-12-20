using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAttack : MonoBehaviour
{
    BoxCollider2D boxcollider2d;
    public Animator anim;
    public float curTime;
    public float coolTime=5f;
    Rigidbody2D rigid;
    Transform AT;
    public GameObject target;
    public GameObject playerhp;


    void Start()
    {
        boxcollider2d=GetComponent<BoxCollider2D>();
        rigid=GetComponent<Rigidbody2D>();
        AT=target.transform;
    }

     void OnTriggerStay2D (Collider2D other) //플레이어가 감지되면
    {
        if(curTime<=0)
        {
           if(other.gameObject.tag=="Player")

                Debug.Log("공격");
                anim.SetTrigger("Attack");
                if(other.gameObject.tag=="Player")
                    playerhp.GetComponent<PlayerHP>().takedamage(20);
                curTime=coolTime;                     
        } 
        else
            curTime-=Time.deltaTime; 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        coolTime=5f;
    }
    void Update()
    {
        transform.position = new Vector3 (AT.position.x,AT.position.y,transform.position.z);
    }

}
