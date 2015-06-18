using UnityEngine;
using System.Collections;

public class Character_collider : MonoBehaviour {

	Rigidbody2D rb; //no need done through code
	public bool IsGrounded;
	public float jumpForce; // how much force to add to character

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		if (!rb)
			Debug.Log("No Rigidbody2D Attached");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (IsGrounded) {
				
				
				Debug.Log ("Jump");
				rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
				IsGrounded = false;
			
			}
		}

	}
	void OnCollisionEnter2D (Collision2D c)
	{
		//Debug.Log ("Collision Enter");
		IsGrounded = true;
		
	}
	void OnCollisionExit2D (Collision2D c)
	{
		//Debug.Log ("Collision Exit");
	}
	void OnCollisionStay2D (Collision2D c)
	{
	
		//Debug.Log ("Collision Stay");
		Debug.Log ("Collided with " + c.gameObject.tag);
		if (c.gameObject.tag == "Collectable") 
		{
			Destroy(c.gameObject);
			//Destroy(c.gameObect,1);  timer
	}
		//if (c.gameObject.tag == "deathzone") {
		//	Destroy ("Player");
		//}
	}
}