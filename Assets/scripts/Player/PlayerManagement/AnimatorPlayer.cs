using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim=GetComponent<Animator>();
    }

    public void AnimTrigger(string AnimName) 
    {
        anim.SetTrigger(AnimName);
    }
}
