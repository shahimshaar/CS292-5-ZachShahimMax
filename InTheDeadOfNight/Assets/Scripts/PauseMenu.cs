using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public bool GameIsPaused = false;
    [SerializeField] public GameObject pauseMenuUI;

    //public string StartMenu;


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

        public void ReturnToStartMenu()
        {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
            
        }

        public void QuitGame()
        {
        Debug.Log("Quitting game...");
            Application.Quit();
        } 
}
