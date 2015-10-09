using UnityEngine;
using System.Collections;

// Need to add this to use UI elements
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Health can go no higher than this number
    public int maxHealth = 10;

    // Current amount of health, which changes as the game is played
    public int health;

    // Variables to hold a references to UI elements used for health
    public Text healthText;
    public Image healthBar;

    // Variable to hold reference to GameObject with GameControl component
    public GameControl gameControl;

    void Start()
    {
        // Start with full health
        health = maxHealth;

        // Set UI elements to full health
        UpdateHealthUI();
    }

    // Method for increasing health that is called from outside this script
    public void AddHealth(int amount)
    {
        // Add health
        health += amount;

        // Limit health to maximum
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        // Update health UI
        UpdateHealthUI();
    }

    // Method to lose health that is called from other scripts    
    public void LoseHealth(int amount)
    {
        // Lose health
        health -= amount;

        // Limit minimum health to 0 and then die
        if (health <= 0)
        {
            health = 0;
            Die();
        }

        // Update health UI
        UpdateHealthUI();
    }

    // Update health text and health image
    private void UpdateHealthUI()
    {
        // Set text to string + formatted health
        healthText.text = "HEALTH: " + health.ToString("00");

        // Adjust the fillAmount property. The range is 0-1, so convert the result of health/maxHealth to a float
        healthBar.fillAmount = (float)health / maxHealth;
    }

    // This happens when there is no more health
    public void Die()
    {
        // Call EndGame method in GameControl and destroy this GameObject
        gameControl.EndGame();
        Destroy(gameObject);
    }
}
