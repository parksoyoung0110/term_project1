using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickattackcooltime : MonoBehaviour
{
    public Image img_Skill;
    public GameObject bolt;
    public GameObject full;

    void Update()
    {
        if(bolt.GetComponent<boltattack>().on)
        {
            full.SetActive(false);
            if(bolt.GetComponent<boltattack>().boltcurTime<=0) //쿨타임이 없으면
            {  
                if(Input.GetMouseButtonDown(0)) //x키로 공격하기 
                {   
                    StartCoroutine(CoolTime(bolt.GetComponent<boltattack>().boltcoolTime));
                }        
 
            }
        }
        
    }


    IEnumerator CoolTime(float cool)
    {
        while(cool > 0.1f)
        {   
            cool-=Time.deltaTime;
            img_Skill.fillAmount = (1.0f/ cool);
            yield return new WaitForFixedUpdate();
        }
    }
}
