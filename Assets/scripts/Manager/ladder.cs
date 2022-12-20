using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    public Collider2D groundCollider;
    public GameObject player;
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), groundCollider, true);
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                player.GetComponent<AnimatorPlayer>().AnimTrigger("Climbing");
            }
                
            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), groundCollider, false);
        }
    }
}
