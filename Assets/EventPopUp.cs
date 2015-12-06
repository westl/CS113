using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EventPopUp : MonoBehaviour {
	string characterName = "CharacterRobotBoy";
	bool isPlayerInvulnerable = false;
	int QuizNumber = 0;
	private GameObject boss;

	void Awake(){
		boss = GameObject.FindGameObjectWithTag ("Boss");
	}
	public EventPopUp(){
	//empty constructor so all methods in this class are visible
	}
	public void destroyObject(){
		//If the quiz window returns to us that its complete we should destroy
		//either the collider or the actual object that this script is attached to
		//TODO : look for a way to fade the object before destorying it
		Destroy (gameObject);
		//movement is not enabled when the window is up , after the quiz window disappears we will
		//call this again to enable movement
		if(isPlayerInvulnerable == false)
			Movement.ToggleMovement(); // only want to toggle movement when the player is no invulnerable
	}
	public void invulTrue(){
		isPlayerInvulnerable = true;		
	}
	public void invulFalse(){
		isPlayerInvulnerable = false;	
	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		//If the player is invulnerable we immediately destroy the robot on contact.
		//If the player is not invulnerable then we present them with a quiz!
		if (isPlayerInvulnerable == true) {
			destroyObject();
		}
		else if (QuizNumber < 1  ) {
			QuizNumber++;
			//If the character collides and is not invulnerable
			if (coll.collider.name == characterName && (isPlayerInvulnerable == false) ) {
				Movement.ToggleMovement ();
				//Create one quiz
				Quiz newQuiz = new Quiz (1);

				//Get the currentQuestion
				Question currentQuestion = newQuiz.getCurrentQuestion ();

				//create a quiz window with the new data to display
				QuizWindow quizWindow = gameObject.AddComponent<QuizWindow> ();
				quizWindow.CreateWindow (currentQuestion);

				//show the window after all the data is assigned 
				quizWindow.ShowWindow ();

				//print("Current Question :" + currentQuestion.getQuestionString());
				//print("Get Answers : " + currentQuestion.getAnwsers());
				//print("Correct Answer : "+ currentQuestion.correctAnwser);
			}

		}
	}


}
