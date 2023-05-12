using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //get scene for hiding UI
    string sceneName;
    
    public  bool gamePaused = false;
    public bool isChosing = false;
    public GameObject pauseMenuUI;
    public int currentSceneIndex;

    //buttons and texts
    public GameObject resumeButton;
    public GameObject optionsButton;
    public GameObject menuButton;
    public GameObject quitButton;
    public GameObject playerUI;
    public GameObject playerCroshair;


    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&(!isChosing))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        playerCroshair.SetActive(true);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        
        pauseMenuUI.SetActive(true);
        playerCroshair.SetActive(false);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Chosing()
    {
        isChosing = true;
    }
    public void Chosing2()
    {
        isChosing = false;
    }
}
