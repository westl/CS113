using UnityEngine;
using System.Collections;

public class QuizWindow : MonoBehaviour {

	//Movement object to pause movement

	//Quiz Window Script
	public bool showWindow = false; // set to true once collision happens, then we prepare a quiz window 
	private Rect quizWindow;
	private string displayMessage;
	private string answer1;
	private string answer2;
	private string answer3;
	private string answer4;
	private Texture aTexture;
	private Question quizQuestion;

	public void ShowWindow(){
		showWindow = true;
		//After showWindow is set to true OnGUI should initiate and create a window with the rectangle we 
		//declared above to be centered by the centerRectangle function. 
	}


	//this function returns the rectangle centered depending on screen size
	Rect centerRectangle(Rect quizWindow){
		quizWindow.x = ( Screen.width - quizWindow.width) / 2 ;
		quizWindow.y = (Screen.height - quizWindow.height) / 2;
		return quizWindow;
	}

	public void CreateWindow(Question question){
	quizWindow = new Rect(0,0,500,500);
	//We want to make sure the window has all the information it will contain before we display the window
	//otherwise sometimes the window will show up with its default values, while this is not a problem
	//it would be better to make sure these variables contain the information they need to show regardless.
		quizQuestion = question;
		this.displayMessage = question.getQuestionString();
		this.answer1 = question.getAnwsers()[0];
		this.answer2 = question.getAnwsers()[1];
		this.answer3 = question.getAnwsers()[2];
		this.answer4 = question.getAnwsers()[3];
	}

	void OnGUI() {
		if (showWindow) {
			//The window is then made 
			GUI.ModalWindow(0, centerRectangle(quizWindow), DoMyWindow, "Quiz Time!" + "\n" + displayMessage);
			GUI.skin.window.wordWrap = true;
			//TODO look up how to draw textures into the window, so we can generate textures depending on the question
			GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
		}
		
	}
	void DoMyWindow(int windowID) {

		if (GUI.Button (new Rect (quizWindow.xMin + 10, quizWindow.yMax - 40, 100, 30), answer1)){
			//Button A was pressed, this will be the number 0 when checking answers
			print(quizQuestion.checkAnwser(0));
			
		}
		if (GUI.Button (new Rect (quizWindow.xMin + 140, quizWindow.yMax - 40, 100, 30), answer2)) { 
			//Button B was pressed, this will be the number 1 when checking answers
			print(quizQuestion.checkAnwser(1));
		}
		if (GUI.Button (new Rect (quizWindow.xMax - 230, quizWindow.yMax - 40, 100, 30), answer3)) { 
			//Button C was pressed, this will be the number 2 when checking answers
			print(quizQuestion.checkAnwser(2));
		}
		if (GUI.Button(new Rect(quizWindow.xMax-110, quizWindow.yMax-40, 100, 30), answer4)) 
		{
			//Button D was pressed, this will be the number 3 when checking answers
			print(quizQuestion.checkAnwser(3));
			
		}
	}

}
