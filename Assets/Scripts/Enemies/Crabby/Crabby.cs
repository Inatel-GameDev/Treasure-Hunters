using UnityEngine;

public class Crabby : Enemy
{

    private void Start()
    {
        speedInitial = speed;
        animator = GetComponent<enemy_animation>();
        animation_idle = "crabby_idle";
        animation_running = "crabby_running";
        animation_attacking = "crabby_attack";
        animation_hit = "crabby_hit";
        animation_dead = "crabby_dead_hit";
    }
}
