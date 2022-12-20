using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstHP2 : MonoBehaviour
{
    public int MaxHP;
    public int currentHP;
    Animator anim;
    Rigidbody2D rigid;
    public Transform targetpos;
    float dirc;
    public GameObject healthbar;

    void Awake()
    {
        anim=GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        currentHP=MaxHP;
        targetpos=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthbar.GetComponent<HealthBar>().SetHealth(currentHP,MaxHP);
    }
    public void takedamage(int damage)
    {    


        //anim.SetTrigger("TakeHit");
  
        currentHP=currentHP-damage;
        healthbar.GetComponent<HealthBar>().SetHealth(currentHP,MaxHP);
        Debug.Log(currentHP);
        if(currentHP<=0)
        {
            Debug.Log("사망");
            //anim.SetTrigger("Death");
            Invoke("Set", 2);
        }
        else
        {
            //anim.SetTrigger("TakeHit");
        }
    
    }

    void Set()
    {
        gameObject.SetActive(false);
    }
}
