using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic : MonoBehaviour
{
    public GameObject ya;
    public GameObject wa;
    public GameObject fal;
    public GameObject em;
    public GameObject pl;

    public float curTime;
    public float coolTime=5f;

    void Start()
    {
        StartCoroutine("Think");
    }
    void Update()
    {
        if(curTime<=0) //쿨타임이 없으면
        {  
            int ran=Random.Range(1, 5);
            curTime=coolTime;
        }        
        else
        {
            curTime-=Time.deltaTime;
        }
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(7);
        int ranAction = Random.Range(0, 5);
        switch (ranAction)
        {
            case 0:
                ya.GetComponent<Yaxis>().BeforeAttack();
                break;
            case 1:
                wa.GetComponent<Warning>().BeforeAttack();
                break;
            case 2:
                fal.GetComponent<Falling>().BeforeAttack();
                break;
            case 3:
                em.GetComponent<Emit>().shot();
                break;
            case 4:
                pl.GetComponent<PlayerChase>().BeforeAttack();
                break;            
        }
        StartCoroutine("Think");
    }


}
