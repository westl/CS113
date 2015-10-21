using UnityEngine;
using System.Collections;

public class fixed_movement : MonoBehaviour {
	public float speed;
	public float jumpHeight;
	private Rigidbody2D body;
	// Use this for initialization
	void Awake(){
		body = GetComponent<Rigidbody2D> ();

	}
	// Update is called once per frame
	void Update () {
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
