using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head2 : Trap
{
    private void Start()
    {
        anim = GetComponent<TrapsAnimations>();
        animation_idle = "Head2_Idle1";
        animation_attacking = "Head2_Attack1";
        animation_hit = "Head2_Hit1";
        animation_dead = "Head2_Destroyed";
    }
}
