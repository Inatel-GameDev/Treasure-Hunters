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

    public Text coinText;

    void Start()
    {
        UpdateLifeBar();
    }

    // Chama essa função sempre que precisar atualizar a barra de vida
    public void UpdateLifeBar()
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

    // Função para atualizar a quantidade de moedas
    public void CoinsAmount(int c)
    {
        coinText.text = c.ToString();
    }
}
