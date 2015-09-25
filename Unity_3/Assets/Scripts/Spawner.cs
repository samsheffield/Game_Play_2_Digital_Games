using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Set this variable to a prefab from your Project Assets folder
	public GameObject prefab;

	public float rate = 2f;
	public float delay = 2f;

	// Use this for initialization
	void Start () {

		// Use StartCoroutine with IEnumerator methods
		StartCoroutine( Spawn () );
	}
	
	// Spawn prefabs at a set rate
	IEnumerator Spawn(){

		// A delay before spawning
		yield return new WaitForSeconds(delay);

		// Endless loop
		while(true){

			// Create a clone of a GameObject prefab. Arguments: 1st, choose the prefab to clone. 2nd, set it's start position to the spawner's position. 3rd, set it's rotation to the spawner's rotation.
			Instantiate (prefab, transform.position, Quaternion.identity);

			// Wait before starting while() again
			yield return new WaitForSeconds(rate);
		}
	}
}
