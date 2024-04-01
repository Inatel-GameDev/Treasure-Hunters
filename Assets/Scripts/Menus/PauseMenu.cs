using UnityEngine.SceneManagement;
using UnityEngine;

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
        player = FindAnyObjectByType<PlayerController>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (player != null && player.isPaused) // Verifique se o player não é nulo antes de acessá-lo
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
        if (player != null) // Verifique se o player não é nulo antes de acessá-lo
        {
            player.isPaused = true;
        }
        Time.timeScale = 0f;
        pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        if (player != null) // Verifique se o player não é nulo antes de acessá-lo
        {
            player.isPaused = false;
        }
        Time.timeScale = 1f;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
