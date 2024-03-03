using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private PlayerController playerController;
    public Text coinText;  // Referência ao objeto Text que mostrará a quantidade de moedas
    Animator animator;

    private void Start()
    {
        // Encontrar o objeto PlayerController na cena
        playerController = FindObjectOfType<PlayerController>();

        // Verificar se a referência foi obtida com sucesso
        if (playerController == null)
        {
            Debug.LogError("PlayerController não encontrado. Certifique-se de que existe um objeto PlayerController na cena.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.AddCoins();

            // Verificar se a referência ao PlayerController é nula
            if (playerController != null)
            {
                // Obtém a quantidade de moedas do PlayerController
                int coinCount = playerController.GetCoins();

                // Atualiza o texto com a quantidade de moedas
                coinText.text = coinCount.ToString();
            }
            else
            {
                Debug.LogError("Referência ao PlayerController é nula. Certifique-se de que foi corretamente atribuída no Editor Unity.");
            }

            Destroy(this.gameObject);
        }
    }
}
