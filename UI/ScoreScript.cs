using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public Text timerText;
    public float timeValue;
    public Text scoreText;
    public float score;
    float highscore;
    public PlayerHealth playerHealth;
    private void Start()
    {
        StartCoroutine(AddScore());
    }
    void Update()
    {
       timeValue += Time.deltaTime;

       DisplayTime(timeValue);
       DisplayScore(timeValue);
        if(playerHealth.currentHealth<=0)
        {
            GetHighScore("Highscore");
           if(highscore<=score)
            {
                SetCurrentScore("CurrentScore", score);
                SetHighScore("Highscore", score);
            }
           else
            {
                SetCurrentScore("CurrentScore", score);
            }
        }
    }
    void DisplayScore(float scoreToDisplay)
    {
        scoreText.text = score.ToString();
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator AddScore()
    {   
        yield return new WaitForSeconds(1);
        score += 10;
        StartCoroutine(AddScore());    
    }

    void SetCurrentScore(string scoreName, float value)
    {
        PlayerPrefs.SetFloat(scoreName, value);
    }
    void SetHighScore(string scoreName, float value)
    {
        PlayerPrefs.SetFloat(scoreName, value);
    }
    void GetHighScore(string hsName)
    {
        highscore = PlayerPrefs.GetFloat("Highscore");
    }


}
