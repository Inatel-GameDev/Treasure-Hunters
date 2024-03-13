using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public PlayerController player;
    public PlayerAnimationController playerAnimationController;
    public UI_manager UI;

    //public float knockbackForce = 5f; // Força do knockback
    //public float knockbackDuration = 0.5f; // Duração do knockback

    private void Start()
    {
        player = GetComponent<PlayerController>();

        Physics2D.IgnoreLayerCollision(8, 7, false);
    }

    private void Update()
    {
        Fall();
    }


    public void TakeDamage(int dano)
    {
        Debug.Log("Player took damage: " + dano);
        player.life -= dano;
        UI.UpdateLifeBar();
        //ApplyKnockback();
        playerAnimationController.PlayAnimation("hit");

        if (player.life <= 0)
        {
            // Reproduzir a animação de morte usando o PlayerAnimationController
            playerAnimationController.PlayAnimation("deadHit");

            // Parar o movimento e desabilitar o controle do jogador
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Physics2D.IgnoreLayerCollision(8, 7);
            player.enabled = false;

            // recarregar cena após um segundo
            Invoke("LoadScene", 1f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Fase 1");
    }

    void Fall()
    {
        if(player.transform.position.y < -10)
        {
            Invoke("LoadScene", 1f);
        }
    }

    //private void ApplyKnockback()
    //{
    //    Obtém a direção do knockback com base na orientação do inimigo
    //   Vector2 knockbackDirection = (enemy.transform.position - player.transform.position).normalized; // player - inimigo

    //    Aplica a força do knockback

    //   player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5f), ForceMode2D.Impulse); //knockback para cima apenas 

    //    Aguarda a duração do knockback antes de parar o movimento
    //    StartCoroutine(StopKnockback());
    //}

    //private IEnumerator StopKnockback()
    //{
    //    yield return new WaitForSeconds(knockbackDuration);

    //    Para o movimento do inimigo após o knockback
    //    player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //}

}
