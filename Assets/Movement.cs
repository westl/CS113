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
	private float tSoundEnd = 0.0f;
	private Animator animator;
	private EventPopUp[] popupScripts; // all referenced popup scripts in the game
	private GameObject player;

	// Use this for initialization
	void Awake(){
		body = GetComponent<Rigidbody2D> ();
		isGrounded = false;
		groundObjects  = new ArrayList();
		stopers = new ArrayList ();
		stopers.Add ("Stair");
		groundObjects.Add ("Floor");
		groundObjects.Add ("Stair");
		groundObjects.Add ("Box");
		animator = this.GetComponent<Animator>();
		popupScripts = FindObjectsOfType(typeof(EventPopUp)) as EventPopUp[];
		source = GetComponent<AudioSource> ();
		player = gameObject;
		//Check to see if there is a source attached, if not do nothing 
		if(source != null)
				source.Play ();

	}


	
	//make sure u replace "floor" with your gameobject name on which player is standing
	public void OnCollisionEnter2D(Collision2D coll) 
	{
		//This function checks all the objects our main character collides with 
		if (groundObjects.Contains (coll.gameObject.name)) {
			isGrounded = true;
			animator.SetBool("Jumping",false);
		} 
		if (stopers.Contains (coll.gameObject.name)) {
				stop = true;
		}
		//The star grants invulnerability
		if (coll.collider.tag == "Star") {
			//Character has collided with the star
			Destroy(coll.collider.gameObject);//Destroys the star from the scene
			foreach(EventPopUp script in popupScripts){
				script.invulTrue(); //Sets every event pop up script to know the player is invulnerable
			}
				
			Invoke("turnOffInvul",10);
		}
	}

	public void turnOffInvul(){
		foreach(EventPopUp script in popupScripts){
			script.invulFalse(); //Sets every event pop up script to know the player is no longer invulnerable
		}
	}

	//	//consider when character is jumping .. it will exit collision.
	public void OnCollisionExit2D(Collision2D coll){
		if(groundObjects.Contains(coll.gameObject.name))
		{
				isGrounded = false;
				animator.SetBool("Running",false);
				animator.SetBool("Jumping",true);
				
		}
		if (stopers.Contains(coll.gameObject.name)) {
			stop = false;
		}
	}


	// Update is called once per frame
	//this is essentially a while loop
	void Update () {
		//while we can still move, if a window pops up we no longer check for movement until its gone

		if (!pauseMovement) {
			if (Input.GetKey (KeyCode.A) && !(stop)) {

				//play sound 
				//body.velocity = new Vector2(-speed,body.velocity.y);
				//
				animator.SetBool ("Idle", false);
				animator.SetBool ("Running", true);
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.Space)) {

				if (isGrounded) {
					animator.SetBool ("Running", false);
					animator.SetBool ("Idle", false);
					animator.SetBool ("Jumping", true);
					if (Time.time > tSoundEnd) { // if previous clip has finished playing...
						source.PlayOneShot (jumpSound); // play a new one...
						tSoundEnd = Time.time + jumpSound.length; // and calculate time for next
					}
					body.velocity = new Vector2 (body.velocity.x, jumpHeight);
					//transform.position += Vector3.up * 100 * Time.deltaTime;
				}
			}

			if (Input.GetKey (KeyCode.D) && !(stop)) {
				animator.SetBool ("Idle", false);
				animator.SetBool ("Running", true);
				//body.velocity =  new Vector2(speed,body.velocity.y - 2);
				//body.velocity = new Vector2(speed,1);
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else{

				animator.SetBool ("Running", false);
				animator.SetBool ("Idle", true);
			}
		}
		else {
			animator.SetBool ("Running", false);
			animator.SetBool ("Idle", true);
		}
	}

	//When this function gets called we no longer listen for movement until it is called again. 
	static public void ToggleMovement(){
		pauseMovement = !pauseMovement;
	}

}
