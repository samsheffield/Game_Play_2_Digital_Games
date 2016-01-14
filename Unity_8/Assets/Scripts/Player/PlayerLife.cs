using UnityEngine;
using System.Collections;

// Need to add this to use UI elements
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    // Health can go no higher than this number. Must match the visual elements
    public int maxHealth = 7;

    // Current amount of health, which changes as the game is played
    public int health = 3;

    // ***** keep track of starting health
    private int startHealth;

    // Variables to hold a references to UI elements used for health
    //private Text healthText;
    private Image healthBar;

    void Start()
    {
        // Find the health text and image by name in the Hierarchy here
        // Be sure to set these before use!

        // UNCOMMENT THIS FOR TEXT HEALTH
        // healthText = GameObject.Find("HealthText").GetComponent<Text>();

        // *****
        startHealth = health;
        health = PlayerPrefs.GetInt("PlayerLife");
        
        // *****
        if (health == 0 || health == maxHealth)
        {
            // Start with full health
            health = startHealth;
            PlayerPrefs.SetInt("PlayerLife", health);
        }

        healthBar = GameObject.Find("PlayerLife").GetComponent<Image>();

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

        // *****
        PlayerPrefs.SetInt("PlayerLife", health);

        // Limit minimum health to 0 and then die
        if (health <= 0)
        {
            health = 0;
        }

        // Update health UI
        UpdateHealthUI();
    }

    // Update health text and health image
    private void UpdateHealthUI()
    {
        // Set text to string + formatted health
        // UNCOMMENT THIS FOR TEXT HEALTH
        //healthText.text = "HEALTH: " + health.ToString("00");

        // Adjust the fillAmount property. The range is 0-1, so convert the result of health/maxHealth to a float
        healthBar.fillAmount = (float)health / maxHealth;
    }

    // This happens when there is no more health
    public void Die()
    {
        // Call EndGame method in GameControl and destroy this GameObject
        GameControl.Instance.EndGame();
        Destroy(gameObject);
    }
}
