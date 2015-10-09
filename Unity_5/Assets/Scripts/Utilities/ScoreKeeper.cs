using UnityEngine;
using System.Collections;

// Need this to use UI elements
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    // *** Declare static instance
    public static ScoreKeeper Instance = null;

    // Text which displays score.
    private Text scoreText;
    
    // Keep track of score. 
    public int score; 

    // *** Set up static instance of this class in Awake. 
    // This allows you to refer to this in on ther scripts as "ScoreKeeper.Instance".
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            // Run Start() again!
            ScoreKeeper.Instance.Start();
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Reset any variables which might have changed last time
        score = 0;

        // Find this GameObject and get the Text component
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Create a function to update the score and set the Text
    // "public" allows this function to be called from other scripts
    // This function expects one int argument
    public void SetScore(int value)
    {
        // Add to score
        score += value;

        // Set text to string + formatted score
        scoreText.text = "SCORE: " + score.ToString("0000");
    }
}
