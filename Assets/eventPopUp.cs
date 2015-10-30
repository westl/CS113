using UnityEngine;
using System.Collections;

public class eventPopUp : MonoBehaviour {
	String characterName = "CharacterRobotBoy";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
		
	void OnCollisionEnter2D(Collision2D coll) 
	{
		// If the Collider2D component is enabled on the object we collided with

		if (coll.collider.name == characterName)
		{
			print(coll.collider.name); 
		}
	}


}
