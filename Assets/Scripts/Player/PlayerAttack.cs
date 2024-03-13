using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Reconhecimento do ataque do personagem

    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Enemy"))
            {
                player.ApplyDamage(collision.GetComponent<Enemy>());
            }

            else if (collision.CompareTag("Trap"))
            {
                player.DestroyTrap(collision.GetComponent<Cannon>());

            }
        }
    }
}

