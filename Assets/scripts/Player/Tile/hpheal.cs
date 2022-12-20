using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpheal : MonoBehaviour
{
    public GameObject player;
    public GameObject bar;

    BoxCollider2D boxcollider2d;
    public AudioSource ad;
    public AudioClip heal;

    void Start()
    {
        boxcollider2d=GetComponent<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        if(player.GetComponent<PlayerHP>().currentHP <player.GetComponent<PlayerHP>().MaxHP)
            player.GetComponent<PlayerHP>().currentHP = player.GetComponent<PlayerHP>().currentHP + 0.3f;
            bar.GetComponent<PlayerHPbar>().SetHealth(player.GetComponent<PlayerHP>().currentHP, player.GetComponent<PlayerHP>().MaxHP);
        if(player.GetComponent<PlayerHP>().currentHP >= player.GetComponent<PlayerHP>().MaxHP)
            player.GetComponent<PlayerHP>().currentHP = player.GetComponent<PlayerHP>().MaxHP;
            bar.GetComponent<PlayerHPbar>().SetHealth(player.GetComponent<PlayerHP>().currentHP, player.GetComponent<PlayerHP>().MaxHP);;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            ad.PlayOneShot(heal);
    }
}
