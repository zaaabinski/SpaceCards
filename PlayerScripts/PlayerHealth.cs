using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    bool gameOver = false;
    public CardsBuffs cardsBuffs;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if (cardsBuffs.Inv2==false)
        {
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        if(currentHealth<=0 && !gameOver)
        {
            gameOver = true;
            Time.timeScale = 0f;
        }
        if(gameOver)
        {
            LoadGameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDMG(10);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDMG(5);
        }
    }

    void TakeDMG(int DMG)
    {
        currentHealth -= DMG;
        healthBar.SetHealth(currentHealth);
    }
    public void LoadGameOver()
    {
        Time.timeScale = 1f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene("GameOver");
    }

}
