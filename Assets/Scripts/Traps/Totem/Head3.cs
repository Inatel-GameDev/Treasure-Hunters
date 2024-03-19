using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head3 : Trap
{
    private void Start()
    {
        anim = GetComponent<TrapsAnimations>();
        animation_idle = "Head3_Idle1";
        animation_attacking = "Head3_Attack1";
        animation_hit = "Head3_Hit1";
        animation_dead = "Head3_Destroyed";
    }
}
