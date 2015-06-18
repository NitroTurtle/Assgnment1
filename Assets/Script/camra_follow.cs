using UnityEngine;
using System.Collections;

public class camra_follow : MonoBehaviour {
	public GameObject target;
	public GameObject end;
	//public Transform leftBoundary;
	//public Transform rightBoundary;
	float leftBoundary;
	float rightBoundary;
	//float topBoundary;
	//float bottomBoundary;
	// Use this for initialization
	void Start () {
		leftBoundary = transform.position.x;
		rightBoundary = end.transform.position.x;
		//topBoundary = transform.position.y;
		//bottomBoundary = end.transform.position.y;
		if (target) 
		{
			Debug.Log ("Target mot linked in Inspector");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			if(target.transform.position.x > leftBoundary && target.transform.position.x < rightBoundary )
			   //&& target.transform.position.y > leftBoundary && target.transform.position.y < bottomBoundary )
				transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
		}
		//if (target) {
		//	if(target.transform.position.y > bottomBoundary && target.transform.position.y < topBoundary )
		//		transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
		//}
	}
}
