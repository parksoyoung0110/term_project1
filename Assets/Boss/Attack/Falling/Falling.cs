using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public GameObject playerpos;
    Vector3 whereToatk;

    public GameObject warning;
    public GameObject Atk1;

    public void BeforeAttack()
    {

            whereToatk=new Vector3(playerpos.transform.position.x,playerpos.transform.position.y,playerpos.transform.position.z) ;
            Instantiate(warning, whereToatk+ new Vector3(0,2f,0), transform.rotation);
            Invoke("Attack", 1.5f);
    }

    public void Attack()
    {
        Instantiate(Atk1, whereToatk +new Vector3(0,2f,0), transform.rotation);
    }
}
