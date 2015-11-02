using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	public float jumpHeight;
	static private bool pauseMovement = false;
	private Rigidbody2D body;

	// Use this for initialization
	void Awake(){
		body = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	//this is essentially a while loop
	void Update () {
		//while we can still move, if a window pops up we no longer check for movement until its gone
		if(!pauseMovement) {
			if(Input.GetKey(KeyCode.A)){
				body.velocity = new Vector2(-speed,body.velocity.y);
			}
			if(Input.GetKey(KeyCode.W)){
				body.velocity = new Vector2(body.velocity.x, jumpHeight);
			}
			if(Input.GetKey(KeyCode.Space)){
				body.velocity = new Vector2(body.velocity.x, jumpHeight);
			}
			if(Input.GetKey(KeyCode.D)){
				body.velocity =  new Vector2(speed,body.velocity.y);
			}
		}
	}

	//When this function gets called we no longer listen for movement until it is called again. 
	static public void PauseMovement(){
		pauseMovement = !pauseMovement;
	}

}
