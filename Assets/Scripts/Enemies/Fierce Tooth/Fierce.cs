using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fierce : Enemy
{
    private void Start()
    {
        speedInitial = speed;
        animator = GetComponent<enemy_animation>();
        animation_idle = "FierceIdle";
        animation_running = "FierceRun";
        animation_attacking = "FierceAttack";
        animation_hit = "FierceHit";
        animation_dead = "FierceDeadHit";
    }
}
