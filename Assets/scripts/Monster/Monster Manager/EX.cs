using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX : MonoBehaviour
{

        public GameObject playerhp;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("20데미지받음!");
            playerhp.GetComponent<PlayerHP>().takedamage(20);
        }
    }
}
