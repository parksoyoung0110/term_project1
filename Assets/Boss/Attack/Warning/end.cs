using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    BoxCollider2D box;
    public AudioClip attack;
    public AudioSource ad;

    void Start()
    {
        ad.PlayOneShot(attack);
        box=GetComponent<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player") 
        {
            collision.GetComponent<PlayerHP>().takedamage(20);
        }
    }

    void Update()
    {
        Invoke("Destroy", 1.5f);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
