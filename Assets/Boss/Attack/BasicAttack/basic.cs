using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic : MonoBehaviour
{

    public GameObject boss;
    public Transform player;
    public bool move;
    public float speed;
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


        // flip
        if((boss.transform.position.x-player.position.x)<0)
        {
            boss.transform.localScale=new Vector3(-8,9,1);
        }
        else{
            boss.transform.localScale=new Vector3(8,9,1);
            
            }
        // 몬스터 움직임
        if(move)
        {
            boss.GetComponent<Animator>().SetTrigger("Walk");
            boss.transform.position = Vector3.MoveTowards(boss.transform.position, new Vector3(player.position.x, boss.transform.position.y, boss.transform.position.z), speed * Time.deltaTime);
        }
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
