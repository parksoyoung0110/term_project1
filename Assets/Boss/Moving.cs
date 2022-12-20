using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{    
    public Transform player;
    public Animator anim;
    public bool move;
    public float speed;

    void Strat()
    {
        anim=GetComponent<Animator>();
    }

    public Vector3 vec;
    void Update()
    {
        Vector3 vec = new Vector3(player.position.x, transform.position.y, transform.position.z);

        if(Mathf.Abs(transform.position.x-player.position.x) > 9)
            move= true;
        else
            move = false;

        if((transform.position.x-player.position.x)<0)
            transform.localScale=new Vector3(-8,9,1);
        else
            transform.localScale=new Vector3(8,9,1);

        if(move)
        {
            anim.SetTrigger("Walk");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }

    }
}
