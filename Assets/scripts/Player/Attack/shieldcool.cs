using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldcool : MonoBehaviour
{
    public Image img_Skill;
    public GameObject shield;
    public GameObject full;

    void FixedUpdate()
    {
        if(shield.GetComponent<shield>().on)
        {
            full.SetActive(false);
            if(shield.GetComponent<shield>().curTime<=0) //쿨타임이 없으면
            {  
                if(Input.GetKeyDown(KeyCode.LeftControl)) 
                {   

                    StartCoroutine(CoolTime(shield.GetComponent<shield>().coolTime));
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
