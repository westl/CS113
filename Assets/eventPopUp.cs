using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EventPopUp : MonoBehaviour {
	string characterName = "CharacterRobotBoy";


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
		Movement.ToggleMovement();
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		// If the Collider2D component is enabled on the object we collided with
		//then we create a quiz object to generate us a question then we will pass
		//the question and its possible answers to the quiz window to display

		if (coll.collider.name == characterName)
		{
			Movement.ToggleMovement();
			//Create one quiz
			Quiz newQuiz = new Quiz(1);

			//Get the currentQuestion
			Question currentQuestion = newQuiz.getCurrentQuestion();

			//create a quiz window with the new data to display
			QuizWindow quizWindow = gameObject.AddComponent<QuizWindow>();
			quizWindow.CreateWindow(currentQuestion);

			//show the window after all the data is assigned 
			quizWindow.ShowWindow();

			//print("Current Question :" + currentQuestion.getQuestionString());
			//print("Get Answers : " + currentQuestion.getAnwsers());
			//print("Correct Answer : "+ currentQuestion.correctAnwser);
		}
	}


}
