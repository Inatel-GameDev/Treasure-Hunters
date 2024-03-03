using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyController enemy;
    public PlayerHealth playerHealth;
    public EnemyAnimationController enemyAnimation;
    public int damage = 1;
    public float cooldownTime = 2.0f;  // Tempo de cooldown em segundos
    private float lastDamageTime;  // Armazena o tempo da última aplicação de dano

    private void Start()
    {
        lastDamageTime = -cooldownTime;  // Configura o último tempo de dano para garantir que o dano possa ser aplicado imediatamente
    }

    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time - lastDamageTime >= cooldownTime && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rbPlayer = collision.GetComponent<Rigidbody2D>();
            Vector2 knockback = (gameObject.transform.position - collision.transform.position).normalized; //inimigo - player
            rbPlayer.velocity = -(knockback) * 5;
            enemyAnimation.PlayEnemyAnimation("FierceAttack");
            enemy.Atacando();

            // Certifique-se de que o objeto do jogador tem o componente PlayerHealth
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                lastDamageTime = Time.time;  // Atualiza o tempo da última aplicação de dano
            }

            // Aguarda o término da animação
            yield return new WaitForSeconds(0.4f);

            // Finaliza o ataque no inimigo
            enemy.FinalizaAtaque();
        }
    }
}