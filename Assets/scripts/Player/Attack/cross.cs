using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross : MonoBehaviour
{
    public float crosscurTime;
    public float crosscoolTime=0.5f;
    public GameObject cro;
    public Transform cropos;
    public Animator anim;
    BoxCollider2D col;
    static public  GameObject ob;
    public GameObject mon;
    Rigidbody2D rigid;
    public GameObject mana;
    public GameObject ManaBar;
    public bool on;
    public AudioSource ad;
    public AudioClip skill;

    void Awake()
    {
        col=GetComponent<BoxCollider2D>();
        rigid=GetComponent<Rigidbody2D>();
        AT=player.transform;
    }
    public GameObject player;


    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Monster")
        {
            ob=collision.gameObject;
            mon=collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        ob = null;
    }

    void Update()
    {
        transform.position = new Vector3 (AT.position.x,AT.position.y,transform.position.z);
        if(on)
        {
            if(mana.GetComponent<PlayerMana>().currentMana>25)
            {
                if(crosscurTime<=0) //쿨타임이 없으면
            {
                if(ob!=null)
                {
                    if(Input.GetKeyDown(KeyCode.X)) //X키로 공격하기 
                    {   
                        ad.PlayOneShot(skill);
                        mana.GetComponent<PlayerMana>().currentMana=mana.GetComponent<PlayerMana>().currentMana - 25f;
                        ManaBar.GetComponent<ManaBar>().SetMana(mana.GetComponent<PlayerMana>().currentMana,mana.GetComponent<PlayerMana>().MaxMana);
                        anim.SetTrigger("AttackX"); 
                        Instantiate(cro, cropos.position, transform.rotation); //cross발사
                        crosscurTime=crosscoolTime;
                    } 
                }
            }
            else
            {
                crosscurTime-=Time.deltaTime;
            }
            }
            
            
        }
        
    }

        Transform AT;
}
