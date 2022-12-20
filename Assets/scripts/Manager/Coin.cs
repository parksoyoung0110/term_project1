using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    public AudioSource ad;
    public AudioClip coin;

    void Start()
    {
        circleCollider2D=GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ad.PlayOneShot(coin);
            CoinAmount.coinAmount +=1;
            Invoke("Destroy", 0.2f);
        }

    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
