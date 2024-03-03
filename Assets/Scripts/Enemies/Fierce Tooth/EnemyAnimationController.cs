using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator enemyAnimator;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void PlayEnemyAnimation(string newAnim)
    {
        enemyAnimator.Play(newAnim);
    }


}
