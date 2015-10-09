using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Set this variable to a prefab from your Project Assets folder
	public GameObject prefab;

	// Spawner properties
	public float rate = 2f;

    // Set the delay using GameControl.Instance
	private float delay;

    // Delay offset to add to the main GameControl delay
    public float delayOffset = 2f;

    void Start () {
        // Do this before starting coroutine
        delay = GameControl.Instance.delay;

		// Use StartCoroutine with IEnumerator methods
		StartCoroutine( Spawn () );
	}
	
	// Spawn prefabs at a set rate
	IEnumerator Spawn(){

		// A delay before spawning
		yield return new WaitForSeconds(delay + delayOffset);

		// Endless spawning
		while(GameControl.Instance.gameOver == false){

            // Check if max number of enemies has been reached. If not, add one
            if(GameControl.Instance.currentEnemyCount < GameControl.Instance.maxEnemies)
            {
                // Create a clone of a GameObject prefab. Arguments: 1st, choose the prefab to clone. 2nd, set it's start position to the spawner's position. 3rd, set it's rotation to the spawner's rotation.
                Instantiate(prefab, transform.position, Quaternion.identity);

                // Update current enemy count in GameControl
                GameControl.Instance.currentEnemyCount++;
            }

            // Wait before starting while() again
            yield return new WaitForSeconds(rate);
		}
	}
}
