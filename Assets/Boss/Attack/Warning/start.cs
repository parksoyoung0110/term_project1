using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    void Update()
    {
        Invoke("Destroy", 1.5f);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
