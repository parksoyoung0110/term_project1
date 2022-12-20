using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public float MaxMana= 100f;
    public float currentMana= 100f;
    public GameObject ManaBar;

    void Awake()
    {
        currentMana=MaxMana;
        ManaBar.GetComponent<ManaBar>().SetMana(currentMana,MaxMana);
    }

    void Update()
    {
         if(currentMana < MaxMana)
            currentMana=currentMana + 0.05f;
            ManaBar.GetComponent<ManaBar>().SetMana(currentMana,MaxMana);
        if(currentMana>= MaxMana)
            currentMana = MaxMana;
            ManaBar.GetComponent<ManaBar>().SetMana(currentMana,MaxMana);
    }
    
}
