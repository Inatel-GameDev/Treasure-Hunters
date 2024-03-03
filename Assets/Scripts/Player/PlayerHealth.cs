using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLife = 4;

    public PlayerController player;
    public PlayerAnimationController playerAnimationController;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    public float knockbackForce = 5f;
    public float knockbackDuration = 0.5f;
    private float knockbackTimer;

    private void Start()
    {
        player = GetComponent<PlayerController>();

        player.life = maxLife;
        knockbackTimer = 0f;
        Physics2D.IgnoreLayerCollision(8, 7, false);
    }

    void Update()
    {
        lifeBar();

        if (knockbackTimer > 0)
        {
            // O jogador está em estado de knockback, reduza o temporizador
            knockbackTimer -= Time.deltaTime;
        }
        else
        {
            // O jogador não está mais em estado de knockback
            player.EnableMovement();
        }

    }

    void lifeBar()
    {
        for (int i = 0; i < coracao.Length; i++)
        {
            if(player.life > maxLife)
            {
                player.life = maxLife;
            }

            if(i < player.life)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vazio;
            }

            if(i < maxLife)
            {
               coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled=false;
            }

        }

    }

    public void TakeDamage(int dano)
    {
        if (knockbackTimer <= 0)
        {
            player.life -= dano;
            playerAnimationController.PlayAnimation("hit");
            Knockback();

            if (player.life <= 0)
            {
                // Reproduzir a animação de morte usando o PlayerAnimationController
                playerAnimationController.PlayAnimation("deadHit");

                // Parar o movimento e desabilitar o controle do jogador
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Physics2D.IgnoreLayerCollision(8, 7);
                player.enabled = false;

                // Agendar a carga da cena após um segundo
                Invoke("LoadScene", 1f);
            }
        }
    }

    void Knockback()
    {
        // Determina a direção do knockback com base na direção atual do jogador
        int direction = (player.sprite.flipX) ? 1 : -1;

        // Aplica a força de knockback
        player.DisableMovement();

        // Configura o temporizador de knockback
        knockbackTimer = knockbackDuration;
    }

    void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
