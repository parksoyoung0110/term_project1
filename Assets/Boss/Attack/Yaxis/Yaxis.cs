using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yaxis : MonoBehaviour
{

    public GameObject playerpos;
    public Vector3 whereToatk;

    public GameObject bullet;
    public AudioSource ad;
    public AudioClip attack;

    public void BeforeAttack()
    {
        whereToatk=new Vector3(playerpos.transform.position.x,playerpos.transform.position.y,playerpos.transform.position.z);
        Instantiate(bullet, transform.position, transform.rotation);
        ad.PlayOneShot(attack);
    }
}


