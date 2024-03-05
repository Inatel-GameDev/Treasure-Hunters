using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Enemy
{
    private void Start()
    {
        speedInitial = speed;
        animator = GetComponent<enemy_animation>();
        animation_idle = "PinkStarIdle";
        animation_running = "PinkStarRun";
        animation_attacking = "PinkStarAttack";
        animation_hit = "PinkStarHit";
        animation_dead = "PinkStarDeadHit";
    }
}
