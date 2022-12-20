using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChase : MonoBehaviour
{
    public GameObject playerpos;
    Vector3 whereToatk;

    public AudioSource ad;
    public AudioClip attack;

    public GameObject bullet;

    public void BeforeAttack()
    {
            whereToatk=new Vector3(playerpos.transform.position.x,playerpos.transform.position.y,playerpos.transform.position.z);
            Instantiate(bullet, transform.position, transform.rotation);
            ad.PlayOneShot(attack);
    }
}
