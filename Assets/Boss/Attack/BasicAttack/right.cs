using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right : MonoBehaviour
{

    public GameObject boss;
    public Transform player;
    public bool move;

    public GameObject p;
    Transform AT;
    public float x;
    public float y;

    void Start()
    {
        move= true;
        AT=boss.transform;
    }

    void Update()
    {

        transform.position = new Vector3 (AT.position.x-x,AT.position.y-y,transform.position.z);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
         if(collision.tag == "Player")
        {
            boss.GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            move = false;
        }        
 
    }

    void OnTriggerExit2D(Collider2D collision)
    {   
        if(collision.tag == "Player")
        {
            move = true;
        }        
    }
}
