using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void PlayAnimation(string newAnim)
    {
        playerAnimator.Play(newAnim);
    }

    public void PlayJumpAnimation(float normalizedTime)
    {
        playerAnimator.Play("jump", 0, normalizedTime);
    }

}
