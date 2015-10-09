using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    // Set to the GameObject containing ScoreKeeper component. Use the Inspector to set.
    public ScoreKeeper scoreKeeper;

    // Set this number to the total number of enemies. We'll make this smarter in the future...
    public int totalEnemies = 2;

    // Method used when the game is over. Set to public so that it can be called from outside this script
    public void EndGame()
    {

        // PlayerPrefs can be used to share data between scenes and is even persistent between play sessions
        // SetInt() will save an int to the key (first argument in quotes). The second argument is the int to save.
        PlayerPrefs.SetInt("score", scoreKeeper.score);

        // Need "End" scene in build settings
        Application.LoadLevel("End");
    }

    // Quick & dirty method to keep track of remaining enemies, and end game when they are all dead. Called from other scripts.
    public void UpdateEnemyCount()
    {   
        // If there are enemies left...
        if(totalEnemies > 1)
        {
            // Subtract from the total number of enemies remaining
            totalEnemies--;
        }
        else
        {
            // End game when all enemies are defeated
            EndGame();
        }
    }
}
