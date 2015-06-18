using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
	Rigidbody2D rb;
	//public AudioClip killClip;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);
		
		rb = GetComponent<Rigidbody2D> ();
		
		rb.velocity = new Vector2 (2.0f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Use if Enemy Collider is not a Trigger
	void OnCollisionEnter2D(Collision2D c)
	{
		// Check if its an enemy or thing to destroy
		if (c.gameObject.tag == "Enemy") {
			Destroy(c.gameObject);	// Destroy object Projectile collides with
			Destroy(gameObject);	// Destroy Projectile
			//SoundManager.instance.PlaySingle(killClip);
		}
	}
	
	// Use if Enemy Collider is a Trigger
	void OnTriggerEnter2D(Collider2D c)
	{
		// Check if its an enemy or thing to destroy
		if (c.gameObject.tag == "Enemy") {
			Destroy(c.gameObject);	// Destroy object Projectile collides with
			Destroy(gameObject);	// Destroy Projectile
			
		}
	}
}