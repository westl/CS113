using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class QuitGame : MonoBehaviour
{
    private GameObject player;
    
    // Use this for initialization
    void Start()
    {
        //We check for the player tag instead of its name since tags are easily changed 
        //and so that we don't have to change an objects name or enter a script to change
        //the name of a string. The tags can be changed from the Unity GUI.
        player = GameObject.FindWithTag("Player");
    }

    // Gets called whenever a collision happens
    void OnCollisionEnter2D(Collision2D coll)
    {
        //If the collision that's happening is infact the player 
        if (coll.collider.tag.Equals(player.tag))
        {
            Application.Quit();
            }
        }
}

