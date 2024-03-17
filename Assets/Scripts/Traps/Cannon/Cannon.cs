using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Trap
{
    private void Start()
    {
        anim = GetComponent<TrapsAnimations>();
        animation_idle = "CannonIdle";
        animation_attacking = "CannonFire";
        animation_hit = "CannonHit";
        animation_dead = "CannonDestroyed";
    }
}
