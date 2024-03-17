using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaShell : Trap
{
    private void Start()
    {
        anim = GetComponent<TrapsAnimations>();
        animation_idle = "SeashellIdle";
        animation_attacking = "SeashellFire";
        animation_hit = "SeashellHit";
        animation_dead = "SeashellDestroyed";
    }
}
