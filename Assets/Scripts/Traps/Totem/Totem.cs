using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Trap
{
    private void Start()
    {
        anim = GetComponent<TrapsAnimations>();
        animation_idle = "Head1_idle1";
        animation_attacking = "Head1_attack1";
        animation_hit = "Head1_hit1";
        animation_dead = "Head1_destroyed";
    }
}
