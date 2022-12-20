using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltattack : MonoBehaviour
{
    public bool on;
    public float boltcurTime;
    public float boltcoolTime=0.5f;
    public GameObject bolt;
    public Transform boltpos;
    public Animator anim;
    public GameObject mana;
    public GameObject ManaBar;
    public AudioSource ad;
    public AudioClip skill;
    void Update()
    {
        if(on)
        {
            if(mana.GetComponent<PlayerMana>().currentMana>30)
            {
               Vector2 len=Camera.main.ScreenToWorldPoint(Input.mousePosition+ new Vector3(0,0,1f))-transform.position;
            float z=Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,z);
            //마우스 방향으로
            if(boltcurTime<=0) //쿨타임이 없으면
            {  
                if(Input.GetMouseButtonDown(0)) //x키로 공격하기 
                {   
                    ad.PlayOneShot(skill);
                    mana.GetComponent<PlayerMana>().currentMana=mana.GetComponent<PlayerMana>().currentMana - 30f;
                    ManaBar.GetComponent<ManaBar>().SetMana(mana.GetComponent<PlayerMana>().currentMana,mana.GetComponent<PlayerMana>().MaxMana);
                    anim.SetTrigger("AttackX"); 
                    Instantiate(bolt, boltpos.position, transform.rotation); //bolt발사
                    boltcurTime=boltcoolTime;
                }        
 
            }
            else
            {
                boltcurTime-=Time.deltaTime;
            } 
            }
            
        }
        
    }
}
