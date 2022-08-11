using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool open = false;
    public Animator animator;

    void Interact()
    {
        if(open)
        {
            open = false;
            animator.SetBool("Open", false);
        }
        else
        {
            open = true;
            animator.SetBool("Open", true);
        }
    }
}
