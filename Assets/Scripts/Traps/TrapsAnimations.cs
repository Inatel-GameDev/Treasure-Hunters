using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsAnimations : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation(string newAnim)
    {
        anim.Play(newAnim);
    }
}
