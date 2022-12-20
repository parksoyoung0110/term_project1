using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHP : MonoBehaviour
{
    public float MaxHP;
    public float currentHP;
    public GameObject anim;
    Rigidbody2D rigid;
    //public GameObject healthbar;



    void Start()
    {
        rigid=GetComponent<Rigidbody2D>();
        currentHP=MaxHP;
       //healthbar.GetComponent<HealthBar>().SetHealth(currentHP,MaxHP);
    }

    public void takedamage(float damage)
    {    

        anim.GetComponent<Animator>().SetTrigger("TakeHit");
  
        currentHP=currentHP-damage;
        //healthbar.GetComponent<HealthBar>().SetHealth(currentHP,MaxHP);
        Debug.Log(currentHP);
        if(currentHP<=0)
        {
            anim.GetComponent<Animator>().SetBool("Death", true);
        }    
    }


}
