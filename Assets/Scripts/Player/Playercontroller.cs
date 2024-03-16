using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public PlayerAnimationController animationController;
    public UI_manager UI;

    [Header("Controll")]
    public bool inGround;
    public Transform groundDetected;
    public bool isMoving;
    public bool isAttacking = false;
    private bool canAttack = true; // Controla se o jogador pode atacar novamente
    private float attackCooldown = 0.6f; // Tempo de cooldown em segundos
    public bool isPaused = false;

    [Header("Player Parameters")]
    [SerializeField] public float speed;
    [SerializeField] public int life;
    [SerializeField] public int maxLife = 4;
    [SerializeField] public int coins;
    [SerializeField] public int damage;
    [SerializeField] public int jumpForce;
    [SerializeField] public int doubleJump = 1;
    [SerializeField] public bool turnRight;
    [SerializeField] public static float move;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<PlayerAnimationController>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        life = maxLife;
        UI.UpdateLifeBar();
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        if (isPaused) return;
        PlayerMovement();
    }

    private void Update()
    {
        if (isPaused) return;
        PlayerAttack();
        PlayerJump();
    }


    void PlayerMovement()
    {

        move = Input.GetAxis("Horizontal");
        isMoving = true;

        // Verifica se o jogador pode se mover
        if (!isAttacking && isMoving)
        {
            SpriteFlip(move);
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            if (inGround && !isAttacking)
            {
                if (move == 0)
                {
                    animationController.PlayAnimation("idle");
                }
                else
                {
                    animationController.PlayAnimation("run");
                }
            }
        }
        else
        {
            // Se está atacando, define a velocidade do jogador como zero
            rb.velocity = new Vector2(0, rb.velocity.y);
            isMoving = false;
        }
    }


    void SpriteFlip(float horizontal)
    {
        // Obtém a escala atual do jogador
        Vector3 playerScale = transform.localScale;

        if (horizontal > 0)
        {
            // Define a escala do jogador diretamente
            transform.localScale = new Vector3(Mathf.Abs(playerScale.x), playerScale.y, playerScale.z);
        }
        else if (horizontal < 0)
        {
            // Inverte a escala do jogador na direção horizontal
            transform.localScale = new Vector3(-Mathf.Abs(playerScale.x), playerScale.y, playerScale.z);
        }
    }


    void PlayerJump()
    {
        inGround = Physics2D.OverlapCircle(groundDetected.position, 0.2f, groundLayer);

        // pulo
        if (Input.GetButtonDown("Jump") && inGround)
        {
            rb.velocity = Vector2.up * jumpForce;
            doubleJump = 1; // Redefina o contador apenas quando estiver no chão.
            AudioManager.Instance.PlaySFX("Jump");
        }
        // pulo extra
        else if (Input.GetButtonDown("Jump") && !inGround && doubleJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            doubleJump--;
            AudioManager.Instance.PlaySFX("Jump");
        }

        if (rb.velocity.y > 0 && !inGround)
        {
            animationController.PlayJumpAnimation(0.4f);
        }
        else if (rb.velocity.y < 0 && !inGround)
        {
            animationController.PlayAnimation("fall");
        }
    }

    void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1") && inGround && canAttack)
        {
            isAttacking = true;
            animationController.PlayAnimation("attack2");
            AudioManager.Instance.PlaySFX("Attack1");

            StartCoroutine(AttackCooldown());
        }
    }

    public void ApplyDamage(Enemy en)
    {
        en.perdeVida(damage);
    }

    public void DestroyTrap(Cannon c)
    {
        c.PerdeVida(damage);
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        isAttacking = false;
    }

    public void OnAttackAnimationFinished()
    {
        isAttacking = false;
    }


    //funções para habilitar e desabilitar o movimento
    public void EnableMovement()
    {
        isMoving = true;
    }

    public void DisableMovement()
    {
        isMoving = false;
    }

    public void AddCoins()
    {
        coins++;
        UI.CoinsAmount(coins);
    }
}


