using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Trap
{
    private void Start()
    {
        anim = GetComponent<TrapsAnimations>();
        animation_idle = "";
        animation_attacking = "";
        animation_hit = "";
        animation_dead = "";
    }
}
