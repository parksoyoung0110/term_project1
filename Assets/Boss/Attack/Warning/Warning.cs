using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    public GameObject warning;
    public GameObject Atk1;


    public void BeforeAttack()
    {
        Instantiate(warning, transform.position, transform.rotation);
        Invoke("Attack", 1.5f);
    }

    public Vector3 vec;
    public void Attack()
    {
        Instantiate(Atk1, transform.position + vec, transform.rotation);
    }
}

