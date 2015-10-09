using UnityEngine;
using System.Collections;

// Need to add this to use UI elements
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Health can go no higher than this number
    public int maxHealth = 10;

    // Current amount of health, which changes as the game is played
    public int health;

    // Variable to hold a reference to UI Image used as health bar
    private Image healthBar;

    // Value in points
    public int points = 10;

    void Start()
    {
        // Start with full health
        health = maxHealth;

        // Find Image component attached to nested child GameObject 
        healthBar = GetComponentInChildren<Image>();

        // Fill health bar
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

        // Update health bar
        UpdateHealthUI();
    }

    // This happens when there is no more health
    public void Die()
    {
        // Add points to score
        ScoreKeeper.Instance.SetScore(points);

        // Decrease enemy count in GameControl
        GameControl.Instance.UpdateEnemyCount();

        Destroy(gameObject);
    }

    // Update health bar fill. Make sure the Image type is set to Filled.
    private void UpdateHealthUI()
    {
        // Check if healthbar component exists...
        if (healthBar != null)
        {
            // Adjust the fillAmount property. The range is 0-1, so convert the result of health/maxHealth to a float
            healthBar.fillAmount = (float)health / maxHealth;
        }
    }
}
