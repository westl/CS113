using UnityEngine;
using System.Collections;

public class test_animation : MonoBehaviour {

	private Animator animator;


	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
        
		 
		if(Input.GetKey(KeyCode.A)){
			animator.SetBool("Idle",false);
			animator.SetBool ("Running", true);
		}
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)){
			animator.SetBool ("Running", false);
			animator.SetBool("Idle",false);
			animator.SetBool ("Jumping", true);
		}
		
		if (Input.GetKey (KeyCode.D)) {
			animator.SetBool("Idle",false);
			animator.SetBool ("Running", true);
		} 

		else {

			animator.SetBool ("Running", false);
			animator.SetBool ("Idle", true);
		}

			
	
	}
}
