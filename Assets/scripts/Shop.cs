using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    public bool isOpen;
    public GameObject shop;
    public Button closeShop;
    public Button ClickAttack;
    public Button AttackX;
    public Button Shield;
    public AudioSource ad;
    public AudioClip buy;

    void Start()
    {
        boxCollider2D=GetComponent<BoxCollider2D>();
        closeShop.onClick.AddListener(DeActiveShop);
        ClickAttack.onClick.AddListener(ClickAttackOn);
        AttackX.onClick.AddListener(AttackXOn);
        Shield.onClick.AddListener(ShieldOn);
    }

    public GameObject bolt;
    public GameObject cross;
    public GameObject shield;

    void Update()
    {
        if( bolt.GetComponent<boltattack>().on)
            ClickAttack.interactable = false;
        if(cross.GetComponent<cross>().on )
            AttackX.interactable = false;
        if(shield.GetComponent<shield>().on)
            Shield.interactable = false;

    }

    void ClickAttackOn()
    {
        if(CoinAmount.coinAmount >= 15)
        {
            bolt.GetComponent<boltattack>().on = true;
            CoinAmount.coinAmount-=15;
            ad.PlayOneShot(buy);
            ClickAttack.interactable = false;
        }
        
    }

    void AttackXOn()
    {   
        if(CoinAmount.coinAmount >= 10)
        {
            cross.GetComponent<cross>().on = true;
            CoinAmount.coinAmount-=10;
            ad.PlayOneShot(buy);
            AttackX.interactable = false;
        }    
    }

    void ShieldOn()
    {
        if(CoinAmount.coinAmount >= 10)
        {
            shield.GetComponent<shield>().on = true;
            CoinAmount.coinAmount-=10;
            ad.PlayOneShot(buy);
            Shield.interactable = false;
        }
        
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            if(Input.GetKeyDown(KeyCode.F))
            {
                isOpen=true;
                ActiveShop(isOpen);
            }
                   
    }

    void ActiveShop(bool isOpen)
    {
        shop.SetActive(isOpen);
    }
    
    public void DeActiveShop()
    {
        isOpen=false;
        ActiveShop(false);
    }
}
