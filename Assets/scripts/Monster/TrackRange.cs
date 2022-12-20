using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRange : MonoBehaviour
{
    Transform AT;
    public GameObject target;
    Rigidbody2D rigid;
    CircleCollider2D circle;
    public GameObject mush;
    public Animator anim;

    void Start()
    {
        rigid=GetComponent<Rigidbody2D>();
        AT=target.transform;
        circle=GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        transform.position = new Vector3 (AT.position.x,AT.position.y,transform.position.z);
    }

    void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            mush.GetComponent<Mushroom>().traceTarget= other.gameObject;
            mush.GetComponent<Mushroom>().StopCoroutine("ChangeMovement");
            mush.GetComponent<Mushroom>().isTracing = true;
            anim.SetBool("IsMoving", true);
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            mush.GetComponent<Mushroom>().isTracing = false;
            mush.GetComponent<Mushroom>().StartCoroutine("ChangeMovement");
        }
    }
}
