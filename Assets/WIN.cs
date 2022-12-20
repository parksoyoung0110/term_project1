using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIN : MonoBehaviour
{
    public GameObject win;

    void Update()
    {
        if(gameObject.GetComponent<MonsterHP>().currentHP<=0)
            Invoke("youwin", 1.9f);
    }

    void youwin()
    {
        win.SetActive(true);
    }
}
