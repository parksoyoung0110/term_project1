using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxcollider : MonoBehaviour
{
    public GameObject boss;
    Transform AT;
    void Start()
    {
        AT=boss.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (AT.position.x,AT.position.y,transform.position.z);

    }
}
