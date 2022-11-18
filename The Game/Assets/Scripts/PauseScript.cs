using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject MenuPause;

    private bool pause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pause) Resume();
            else Pause();
        }
    }

   public void Pause()
    {
        pause = true;
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
        MenuPause.SetActive(true);
    }

    public void Resume()
    {
        pause = false;
        Time.timeScale = 1f;
        PauseButton.SetActive(true);
        MenuPause.SetActive(false);

    }
    
    public void Restart()
    {
        pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
