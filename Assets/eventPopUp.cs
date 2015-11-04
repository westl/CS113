using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class eventPopUp : MonoBehaviour {
	string characterName = "CharacterRobotBoy";

	
		
	void OnCollisionEnter2D(Collision2D coll) 
	{
		// If the Collider2D component is enabled on the object we collided with
		//then we create a quiz object to generate us a question then we will pass
		//the question and its possible answers to the quiz window to display

		if (coll.collider.name == characterName)
		{
			Movement.PauseMovement();
			//Create one quiz
			Quiz newQuiz = new Quiz(1);

			//Get the currentQuestion
			Question currentQuestion = newQuiz.getCurrentQuestion();

			//Get the list of possibleAnswers
			List<string> possibleAnswers = currentQuestion.getAnwsers();

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
