using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    // Delay while showing text
    public float delay = 2f;

    // Display some text to signal start and end of game
    private Text displayText;
    // Text to display
    public string readyText = "Ready";
    public string gameOverText = "Game Over";

    // Signal when the game is over
    public bool gameOver;

    // *** Creating a static variable to hold a GameControl object. Static allows this to be found by all other scripts with GameControl.Instance
    public static GameControl Instance = null;

    // Awake is called before Start
    void Awake()
    {
        // *** Set up instance
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            // Run Start() again!
            GameControl.Instance.Start();
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Reset variable changed last time game was played
        gameOver = false;

         // This gameobject must be named DisplayText
        displayText = GameObject.Find("DisplayText").GetComponent<Text>();

        // Start text coroutine for Get Ready
        StartCoroutine(ShowReadyText());
    }

    // Method used when the game is over. Set to public so that it can be called from outside this script
    public void EndGame()
    {
        // Display some text using a coroutine. Boolean used to only trigger StartCoroutine once
        if (gameOver == false)
        {
            gameOver = true;

            // *** Start game over coroutine
            StartCoroutine(ShowGameOverText());
        }

    }

    // Turn off Get Ready text after a delay
    IEnumerator ShowReadyText()
    {
        // Turn on text component, if it is disabled
        displayText.text = readyText;
        displayText.enabled = true;

        yield return new WaitForSeconds(delay);

        // After waiting, turn off text component
        displayText.enabled = false;
    }

    // Show gameover text, then change scenes
    IEnumerator ShowGameOverText()
    {
        // Change Text and enable it
        displayText.text = gameOverText;
        displayText.enabled = true;

        yield return new WaitForSeconds(delay);

        // Real end starts here
        ChangeScene();
    }

    // Save score and change scene
    private void ChangeScene()
    {
        // PlayerPrefs can be used to share data between scenes and is even persistent between play sessions
        // SetInt() will save an int to the key (first argument in quotes). The second argument is the int to save.

        // *** Set to instance
       // PlayerPrefs.SetInt("score", ScoreKeeper.Instance.score);

        // Need "End" scene in build settings
        Application.LoadLevel("End");
    }
}
