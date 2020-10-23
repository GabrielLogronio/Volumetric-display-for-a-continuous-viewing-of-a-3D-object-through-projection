using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantAnimationController : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Talking(bool toSet) 
    {
        anim.SetBool("Talking", toSet);
    }

    public void Waving() 
    {
        anim.SetTrigger("Waving");
    }

    public void Turn(bool right) 
    { 
        if(right) anim.SetTrigger("RightTurn");
        else anim.SetTrigger("LeftTurn");
    }

    public void OpenUI(bool toSet) 
    {
        anim.SetBool("UI", toSet);
    }

    public void Reset() 
    {
        anim.SetBool("Talking", false);
        anim.SetBool("UI", false);
    }

    public void Idle() 
    { 
        
    }

}
