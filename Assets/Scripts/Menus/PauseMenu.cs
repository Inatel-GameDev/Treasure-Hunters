using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerController player;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (player.isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        player.isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        player.isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Fase 1");
    }
}
