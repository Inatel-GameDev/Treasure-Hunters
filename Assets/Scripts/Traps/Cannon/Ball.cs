using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    public PlayerHealth player;

    private void Start()
    {
        // Acelera a bola para a esquerda
        rb.velocity = Vector2.left * speed;
        player = FindFirstObjectByType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
