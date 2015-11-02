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

	public void CreateWindow(string displayMessage, string answer1, string answer2, string answer3, string answer4){
	quizWindow = new Rect(0,0,500,500);
	//We want to make sure the window has all the information it will contain before we display the window
	//otherwise sometimes the window will show up with its default values, while this is not a problem
	//it would be better to make sure these variables contain the information they need to show regardless.
	this.displayMessage = displayMessage;
	this.answer1 = answer1;
	this.answer2 = answer2;
	this.answer3 = answer3;
	this.answer4 = answer4;
	}

	void OnGUI() {
		if (showWindow) {
			//This calls the function directly from the movement class thats attached to our character
			Movement.PauseMovement();
			//The window is then made 
			GUI.ModalWindow(0, centerRectangle(quizWindow), DoMyWindow, "Quiz Time!" + "\n" + displayMessage);
			//GUI.Label(new Rect (quizWindow.xMin + 10, quizWindow.yMin + 40, quizWindow.x, quizWindow.xMax),
			         //  displayMessage);
			//GUI.skin.label.wordWrap = true;
			GUI.skin.window.wordWrap = true;
		}
		
	}
	void DoMyWindow(int windowID) {


		if (GUI.Button (new Rect (quizWindow.xMin + 10, quizWindow.yMax - 40, 100, 30), answer1)){
			//Button A was pressed, this will be the number 0 when checking answers
			
		}
		if (GUI.Button (new Rect (quizWindow.xMin + 140, quizWindow.yMax - 40, 100, 30), answer2)) { 
			//Button B was pressed, this will be the number 1 when checking answers
		}
		if (GUI.Button (new Rect (quizWindow.xMax - 230, quizWindow.yMax - 40, 100, 30), answer3)) { 
			//Button C was pressed, this will be the number 2 when checking answers
		}
		if (GUI.Button(new Rect(quizWindow.xMax-110, quizWindow.yMax-40, 100, 30), answer4)) 
		{
			//Button D was pressed, this will be the number 3 when checking answers
			
		}
	}

}
