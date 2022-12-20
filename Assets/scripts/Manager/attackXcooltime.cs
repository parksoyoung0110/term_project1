using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackXcooltime : MonoBehaviour
{
    public Image img_Skill;
    public GameObject cross;
    public GameObject full;

    void Update()
    {
        if(cross.GetComponent<cross>().on)
        {
            full.SetActive(false);
            if(cross.GetComponent<cross>().crosscurTime<=0) //쿨타임이 없으면
            {  
                if(Input.GetKeyDown(KeyCode.X)) //x키로 공격하기 
                {   
                    StartCoroutine(CoolTime(cross.GetComponent<cross>().crosscoolTime));
                    Debug.Log("쿨타임시작");
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
