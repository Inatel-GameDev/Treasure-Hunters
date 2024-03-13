using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public string scene;
    public GameObject optionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void BackToMenu()
    {
        optionsPanel.SetActive(false);
    }

}
