using UnityEngine;
using System.Collections;

public class Killer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Cactus"){
			Destroy(other.gameObject);
		}
	}
}
