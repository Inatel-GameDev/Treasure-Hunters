using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Tilemaps;

public class EnemyController : MonoBehaviour
{
    public EnemyAnimationController enemyAnimationController;

    public float velocidade;
    public bool noChao = true;
    public bool atacando;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool turnRight = true;

    void Start()
    {
        enemyAnimationController = GetComponent<EnemyAnimationController>();

        if (enemyAnimationController == null)
        {
            Debug.LogError("EnemyAnimationController não encontrado em " + gameObject.name);
        }
    }

    void Update()
    {
        EnemyMoviment();
    }

    void SpriteFlip()
    {
        turnRight = !turnRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    //MOVIMENTO BASEADO EM PLATAFORMAS UTILIZANDO O GROUNDCHECK PARA FAZER A MOVIENTAÇÃO
    void EnemyMoviment()
    {
        if (!atacando)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);

            noChao = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);

            if (!noChao)
            {
                velocidade *= -1;
                SpriteFlip();
            }

            // Verifica se há uma instância válida de EnemyAnimationController
            if (enemyAnimationController != null)
            {
                if (velocidade != 0)
                {
                    enemyAnimationController.PlayEnemyAnimation("FierceRun");
                }
                else
                {
                    enemyAnimationController.PlayEnemyAnimation("FierceIdle");
                }
            }
        }
    }

    public void Atacando()
    {
        atacando = true;
    }

    public void FinalizaAtaque()
    {
        atacando = false;
    }

}
