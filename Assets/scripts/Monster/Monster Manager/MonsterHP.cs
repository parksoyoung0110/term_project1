using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    public float MaxHP;
    public float currentHP;
    Animator anim;
    Rigidbody2D rigid;
    public Transform targetpos;
    float dirc;
    public GameObject healthbar;
   public int speed;
    public AudioSource ad;
    public AudioClip coin;

    void Start()
    {
        anim=GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        currentHP=MaxHP;
        healthbar.GetComponent<HealthBar>().SetHealth(currentHP,MaxHP);
    }

    public void takedamage(float damage)
    {    
        anim.SetTrigger("TakeHit");
  
        currentHP=currentHP-damage;
        healthbar.GetComponent<HealthBar>().SetHealth(currentHP,MaxHP);
        Debug.Log(currentHP);
        if(currentHP<=0)
        {
            anim.SetBool("Death", true);
            rigid.velocity=new Vector2(0,0);
            Invoke("sound", 0.2f);
            Invoke("Set", 2);
        }
        else
        {
            dirc=transform.position.x - targetpos.position.x > 0? 1: -1;
            rigid.isKinematic=false;
            Vector2 knockback= new Vector2(dirc*0.5f,0);
            rigid.AddForce(knockback*speed,ForceMode2D.Impulse);
            StartCoroutine(KnockCo());
        }
    
    }

    IEnumerator KnockCo()
    {
        yield return new WaitForSeconds(0.2f);
        rigid.velocity=Vector2.zero;
        Invoke("Dynamic", 1f);
    }

    void Dynamic()
    {
        rigid.isKinematic=true;
        rigid.bodyType=RigidbodyType2D.Dynamic;
    }

    void Set()
    {
        CoinAmount.coinAmount +=3;
        Destroy(gameObject);
    }

    void sound()
    {
        ad.PlayOneShot(coin);
    }
}
