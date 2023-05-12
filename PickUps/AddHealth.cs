using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;
    public int HowMuch;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("IsPlayer"))&&playerHealth.currentHealth<100)
        {
            Invoke("HP", 0.05f);
        }
    }
    void HP()
    {
        AddHP(HowMuch);
    }
    void AddHP(int heal)
    {
        playerHealth.currentHealth += heal;
        
        healthBar.SetHealth(playerHealth.currentHealth);
    }
 

}
