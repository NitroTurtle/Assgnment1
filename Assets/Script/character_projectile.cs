using UnityEngine;
using System.Collections;

public class character_projectile : MonoBehaviour {

	public GameObject projectile;
	public Transform projectileSpawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//projectile
		if ( Input.GetButtonDown ("Fire1")) {
			Debug.Log("Pew Pew");
			
			// Create the projectile and let it go
			//Instantiate(projectile,projectileSpawnPoint.position,projectileSpawnPoint.rotation);
			
			// Create the projectile and modify it
			GameObject pTemp = Instantiate(projectile,projectileSpawnPoint.position,projectileSpawnPoint.rotation) as GameObject;

	}
}
}