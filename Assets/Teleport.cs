using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class Teleport : MonoBehaviour {
	private GameObject player;
	public GameObject nextTeleportPad; // Needs to be set by a designer as the next teleport pad that the character will port to

	// Use this for initialization
	void Start () {
		//We check for the player tag instead of its name since tags are easily changed 
		//and so that we don't have to change an objects name or enter a script to change
		//the name of a string. The tags can be changed from the Unity GUI.
		player = GameObject.FindWithTag ("Player"); 
	}
	
	// Gets called whenever a collision happens
	void OnCollisionEnter2D(Collision2D coll) 
	{
		//If the collision that's happening is infact the player 
		if (coll.collider.tag.Equals (player.tag)) {
			//As long as the teleport pad has been set this should work
			//if not, the script does nothing and skips this block of code
			if (nextTeleportPad != null) {
				//Get the x and y position of the landing zone and add 1 
				//to move the character off of the pad as they teleport to it
				float xPos = nextTeleportPad.transform.position.x + 1;
				float yPos = nextTeleportPad.transform.position.y + 1;

				//set the position of the player to the position of the landing 
				//object
				player.transform.position = new Vector3(xPos,yPos,0);
			}
		}
	}
}
