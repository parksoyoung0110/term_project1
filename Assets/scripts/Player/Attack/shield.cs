using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    public float curTime;
    public float coolTime=0.5f;
    public GameObject skill;
    public bool on;
    public AudioSource ad;
    public AudioClip shields;
    public GameObject mana;
    public GameObject ManaBar;
    public GameObject player;

    void Update()
    {
        if(on)
        {
            if(curTime<=0) //쿨타임이 없으면
            {  
                if(Input.GetKeyDown(KeyCode.LeftControl)) //z키로 공격하기 
                {   
                    skill.SetActive(true);
                    ad.PlayOneShot(shields);
                    mana.GetComponent<PlayerMana>().currentMana=mana.GetComponent<PlayerMana>().currentMana - 10f;
                    ManaBar.GetComponent<ManaBar>().SetMana(mana.GetComponent<PlayerMana>().currentMana,mana.GetComponent<PlayerMana>().MaxMana);
                    player.GetComponent<PlayerHP>().Hit=false;
                    Invoke("Deactive", 1f);
                 
                    curTime=coolTime;               
                }        
            
            }
            else
            {
                curTime-=Time.deltaTime;
            }
        }

    }

    void Deactive()
    {
        skill.SetActive(false);
        player.GetComponent<PlayerHP>().Hit=true;
    }
}
