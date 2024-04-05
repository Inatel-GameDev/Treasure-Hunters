using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField]public string scene;
    public GameObject optionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic("Theme");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }

    public void OptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        //Editor da Unity
        UnityEditor.EditorApplication.isPlaying = false;
        
        //Jogo Compilado
        //Application.Quit();
        
        PlayerPrefs.DeleteKey("TotalMoedas"); // Limpa o total de moedas ao sair
    }

    public void BackToMenu()
    {
        optionsPanel.SetActive(false);
    }

}
