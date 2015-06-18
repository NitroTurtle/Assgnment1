using UnityEngine;
using System.Collections;

public class character_movement : MonoBehaviour {
	Rigidbody2D rb; //no need done through code
	public Rigidbody rb2;
	public Animator anim;

	public bool facingRight;
	public bool OnLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	//public float jumpForce;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		if (!rb)
			Debug.Log("No Rigidbody2D Attached");
		if (!rb2)
			Debug.Log("No Rigidbody2D Attached. Drag Object into Inspector");

		gravityStore = rb.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow)) {
			Debug.Log ("Duck");
		}
		//if (Input.GetKeyDown (KeyCode.UpArrow)) {
		//			Debug.Log ("Jump");
		//			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		//}

		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Attack");
			anim.SetTrigger("Shoot");
		}
		if (!anim) {
			Debug.Log ("No animator");
		}
		
		//check if left or right key is pressed
		float move = Input.GetAxis ("Horizontal");
		
		//move character left or right based on keyPress
		rb.velocity = new Vector2 (move, rb.velocity.y);
		
		//tell animator to move
		anim.SetFloat ("Move", Mathf.Abs (move));

		
		//check if character shuld look left or right
		if (move < 0 && facingRight) {
			//character is facing right and should be changed to left
			flip ();
		} else if (move > 0 && !facingRight) {//could also be writen as  if((move < 0 || move >0)){flip();}
			flip ();
		
		}

		if (OnLadder) {
			rb.gravityScale =0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
			rb.velocity = new Vector2 (rb.velocity.x, climbVelocity);
			anim.SetBool("Ladder",true);
		}

		if (!OnLadder) {
			rb.gravityScale = gravityStore;
			anim.SetBool("Ladder",false);
		}





}
	void flip()
	{	//toggles variable
		facingRight = !facingRight;
		//make a copy of old scale
		Vector3 scaleFactor = transform.localScale;
		
		//flip the scale
		scaleFactor.x *= -1;
		
		//update the scale to filpped va	lue
		transform.localScale = scaleFactor;
	}

}


