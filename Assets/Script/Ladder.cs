using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	private character_movement player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<character_movement> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Player") {
			player.OnLadder = true;

			Debug.Log("clibing");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.name == "Player") {
			player.OnLadder = false;

		}
	}
}
