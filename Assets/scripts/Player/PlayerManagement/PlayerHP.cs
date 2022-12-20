using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject healthbar;
    public float MaxHP;
    public float currentHP;
    public bool Hit;
    Rigidbody2D rigid;
    Animator anim;
    public AudioSource ad;
    public AudioClip hit;
    SpriteRenderer spriteRenderer;
    

    void Start()
    {
        currentHP=MaxHP;
        healthbar.GetComponent<PlayerHPbar>().SetHealth(currentHP,MaxHP);
        Hit=true;
        rigid=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    public GameObject targetpos;
    float dirc;

    public void takedamage(float damage)
    {    
        if(Hit)
        {
            anim.SetTrigger("TakeHit");
            ad.PlayOneShot(hit);
  
            currentHP=currentHP-damage;
            healthbar.GetComponent<PlayerHPbar>().SetHealth(currentHP,MaxHP);
            Debug.Log(currentHP);
            if(currentHP<=0)
            {
                Time.timeScale=0;
            }
            else
            {
                Hit=false;
                spriteRenderer.color= new Color (1,1,1,0.4f);
                Invoke("Ondamaged", 2);
            }
        }   
    }

    void Ondamaged()
    {
        Hit=true;
        spriteRenderer.color= new Color (1,1,1,1);
    }

}
