using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	public float speed;
	public float jumpHeight;
	static private bool pauseMovement = false;
	private Rigidbody2D body;
	private bool isGrounded;
	public ArrayList groundObjects;
	bool facingRight = true;
	Animator anim;






	// Use this for initialization
	void Awake(){
		body = GetComponent<Rigidbody2D> ();
		isGrounded = false;
		groundObjects  = new ArrayList();
		groundObjects.Add ("Floor");
		anim = GetComponent<Animator> ();

	}


	
	//make sure u replace "floor" with your gameobject name.on which player is standing
	public void OnCollisionEnter2D(Collision2D coll) 
	{

		if(groundObjects.Contains(coll.gameObject.name))
		{
			isGrounded = true;
		}
	}


	
	//	//consider when character is jumping .. it will exit collision.
	public void OnCollisionExit2D(Collision2D coll){
		if(groundObjects.Contains(coll.gameObject.name))
		{
				isGrounded = false;
		}
	}


	// Update is called once per frame
	//this is essentially a while loop
	void Update () {
		//while we can still move, if a window pops up we no longer check for movement until its gone

		if(!pauseMovement) {
			float move = Input.GetAxis("Horizontal");
			anim.SetFloat("Speed", Mathf.Abs(move));
			if(Input.GetKey(KeyCode.A)){
				body.velocity = new Vector2(-speed,body.velocity.y);
			}
			if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)){
				if(isGrounded){
					body.velocity = new Vector2(body.velocity.x, jumpHeight);
				}
			}

			if(Input.GetKey(KeyCode.D)){
				body.velocity =  new Vector2(speed,body.velocity.y);
			}
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();
		}
	}

	//When this function gets called we no longer listen for movement until it is called again. 
	static public void PauseMovement(){
		pauseMovement = !pauseMovement;
		print (pauseMovement);
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
