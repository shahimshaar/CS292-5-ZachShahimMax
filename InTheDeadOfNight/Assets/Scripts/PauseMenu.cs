using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
        public void Resume() {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            AudioListener.pause = false;
            GameIsPaused = false;
        }

        public void Pause() {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
            GameIsPaused = true;
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene("StartMenu");
            Time.timeScale = 1f;
        }

        public void QuitGame()
        {
            Application.Quit();
        } 
}
