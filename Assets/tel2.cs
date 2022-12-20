using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tel2 : MonoBehaviour
{
    public GameObject current;
    public GameObject next;
    public GameObject player;

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
            if(Input.GetKeyDown(KeyCode.F))
            {
                
                next.SetActive(true);
                player.transform.position = new Vector3(0,0,0);
                current.SetActive(false);
                

            }
    }
}
