using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    public PlayerController p;

    public int maxLife = 4;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    public Text coinText;  // Referência ao objeto Text que mostrará a quantidade de moedas

    void Update()
    {
        lifeBar();
    }

    void lifeBar()
    {
        for (int i = 0; i < coracao.Length; i++)
        {
            if (p.life > maxLife)
            {
                p.life = maxLife;
            }

            if (i < p.life)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vazio;
            }

            if (i < maxLife)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }

    public void CoinsAmaont(int c)
    {
        // Atualiza o texto com a quantidade de moedas
        coinText.text = c.ToString();
    }
}
