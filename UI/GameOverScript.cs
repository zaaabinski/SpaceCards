using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    float score, highscore;
    int currentSceneIndex;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        GetHighScore();
        GetScore();
        scoreText.text = ("Twój wynik : " + score);
        highscoreText.text = ("Najlepszy wynik : " + highscore);
    }
    void Start()
    {
        
    }

    public void LoadMenu()
    {
            Time.timeScale = 1f;
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
            SceneManager.LoadScene("Menu");
    }
    public void LoadLevel1()
    {
        Time.timeScale = 1f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene("Level1");
    }
    public void Reset()
    {
        ResetHighscore("Highscore", 0);
        highscoreText.text = ("Najlepszy wynik : " + highscore);
    }
    void GetHighScore()
    {
        highscore = PlayerPrefs.GetFloat("Highscore");
    }
    void GetScore()
    {
        score = PlayerPrefs.GetFloat("CurrentScore");
    }
    void ResetHighscore(string scoreName, float value)
    {
        PlayerPrefs.SetFloat(scoreName, value);
        highscore = PlayerPrefs.GetFloat("Highscore");
    }
}
