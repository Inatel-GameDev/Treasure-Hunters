using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Reconhecimento do ataque do personagem

    public int danoDoAtaque = 1;
    public EnemyHealth enemyHealth;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o Collider atingiu um inimigo
        if (other.CompareTag("Enemy"))
        {
            // Causa dano ao inimigo (ajuste a quantidade de dano conforme necessário)
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(danoDoAtaque);
            }
        }
    }
}
