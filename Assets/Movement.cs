using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	public float speed = 2f;
	public float jumpHeight;
	static private bool pauseMovement = false;
	private Rigidbody2D body;
	private bool isGrounded;
	public ArrayList groundObjects;
	public ArrayList stopers;
	bool stop = false ;
	//audio stuff
	private AudioSource source;
	public AudioClip jumpSound;





	// Use this for initialization
	void Awake(){
		body = GetComponent<Rigidbody2D> ();
		isGrounded = false;
		groundObjects  = new ArrayList();
		stopers = new ArrayList ();
		stopers.Add ("Stair");
		groundObjects.Add ("Floor");
		groundObjects.Add ("Stair");
		source = GetComponent<AudioSource> ();
		source.Play ();


	}


	
	//make sure u replace "floor" with your gameobject name.on which player is standing
	public void OnCollisionEnter2D(Collision2D coll) 
	{

		if (groundObjects.Contains (coll.gameObject.name)) {
			isGrounded = true;
		} 
		if (stopers.Contains (coll.gameObject.name)) {
				stop = true;
		}

	}


	
	//	//consider when character is jumping .. it will exit collision.
	public void OnCollisionExit2D(Collision2D coll){
		if(groundObjects.Contains(coll.gameObject.name))
		{
				isGrounded = false;
		}
		if (stopers.Contains(coll.gameObject.name)) {
			stop = false;
		}
	}


	// Update is called once per frame
	//this is essentially a while loop
	void Update () {
		//while we can still move, if a window pops up we no longer check for movement until its gone

		if(!pauseMovement) {
			if(Input.GetKey(KeyCode.A) && !(stop)){

				//play sound 
				//body.velocity = new Vector2(-speed,body.velocity.y);
				//
				
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
			 if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)){

				if(isGrounded){
					source.PlayOneShot(jumpSound);
					body.velocity = new Vector2(body.velocity.x, jumpHeight);
					//transform.position += Vector3.up * 100 * Time.deltaTime;
				}
			}

			 if(Input.GetKey(KeyCode.D)  && !(stop)){

				//body.velocity =  new Vector2(speed,body.velocity.y - 2);
				//body.velocity = new Vector2(speed,1);
				transform.position += Vector3.right * speed * Time.deltaTime;
			}
		}
	}

	//When this function gets called we no longer listen for movement until it is called again. 
	static public void ToggleMovement(){
		pauseMovement = !pauseMovement;
	}

}
