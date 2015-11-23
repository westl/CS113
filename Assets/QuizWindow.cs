using UnityEngine;
using System.Collections;

public class QuizWindow : MonoBehaviour {

	//Movement object to pause movement

	//Quiz Window Script
	public bool showWindow = false; // set to true once collision happens, then we prepare a quiz window
	private Rect quizWindow;
	private Rect labelSection;
	private string displayMessage;
	private string answer1;
	private string answer2;
	private string answer3;
	private string answer4;
	private Texture2D itemToDraw;
	private Question quizQuestion;
	private string answerValue;
	private string questionType;
	private int counterForDrawing; //number of times to draw the texture
	private float texturexPosition ; //intial placement of the texture on the x-axis
	private float textureyPosition; //initial placement of the texture on the y-axis
	private string feedback; //actual feedback that is printed onto the screen
	private bool showFeedBack = false; //show feed back or not

	public void ShowWindow(){
		showWindow = true;
		//After showWindow is set to true OnGUI should initiate and create a window with the rectangle we 
		//declared above to be centered by the centerRectangle function. 
	}


	//this function returns the rectangle centered depending on screen size
	Rect centerRectangle(Rect quizWindow){
		quizWindow.x = ( Screen.width - quizWindow.width) / 2 ;
		quizWindow.y = ( Screen.height - quizWindow.height) / 2;
		return quizWindow;
	}

	public void CreateWindow(Question question){
		quizWindow = new Rect(0,0,500,500);
		labelSection = new Rect (0, 0, 500, 200);
	//We want to make sure the window has all the information it will contain before we display the window
	//otherwise sometimes the window will show up with its default values, while this is not a problem
	//it would be better to make sure these variables contain the information they need to show regardless.
		quizQuestion = question;
		this.displayMessage = question.getQuestionString();
		this.answer1 = question.getAnwsers()[0];
		this.answer2 = question.getAnwsers()[1];
		this.answer3 = question.getAnwsers()[2];
		this.answer4 = question.getAnwsers()[3];
		this.answerValue = question.getCorrectAnwserValue();
		this.questionType = question.getTexture ();
		counterForDrawing = IntParseFast (answerValue);

	}

	void OnGUI() {
		if (showWindow) {
			//The window is then made 
			GUI.Window(0, centerRectangle(quizWindow), DoMyWindow, "Quiz Time!" + "\n" + displayMessage);
			GUI.skin.window.wordWrap = true;

			//Depending if the type of question regards flowers, balls, etc we need to draw that image onto the quiz window.
			texturexPosition = quizWindow.width-100;
			textureyPosition = quizWindow.height/2;

			//Each question will have an identifier to inform us on which texture to draw
			if(questionType.Equals("Flower Question")){
				itemToDraw = (Texture2D)Resources.Load("Images/CratePinkGridSprite");
			}
			else if(questionType.Equals("Balls")){
				//do nothing for now.
			}

			//After we know which texture to draw we need to know how many times to draw it.
			//the counterForDrawing variable tells us how many times to draw this texture.
			for(int i = 0 ; i < counterForDrawing ; i++){
				//for now each row will have  5 textures before creating a new row. 
				if( (i%5)==0 ){
					texturexPosition = quizWindow.width-100;
					textureyPosition = textureyPosition + 30;
				}
				else{
					texturexPosition = texturexPosition + 100;
				}

				//draws the texture in its designated location as long as we have set the item
				if(itemToDraw!=null)
				GUI.DrawTexture(new Rect(texturexPosition,textureyPosition, 60, 60), itemToDraw, ScaleMode.ScaleToFit, true, 10.0F);
			} // END OF FOR LOOP

		

		}
		
	}
	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (quizWindow.xMin + 10, quizWindow.yMax - 40, 100, 30), answer1)){
			//Button A was pressed, this will be the number 0 when checking answers
			showFeedBack = true;
			feedback = quizQuestion.checkAnwser(0);
			if(quizQuestion.correct)
				Invoke("hideMyWindow",3);

		}
		if (GUI.Button (new Rect (quizWindow.xMin + 140, quizWindow.yMax - 40, 100, 30), answer2)) { 
			//Button B was pressed, this will be the number 1 when checking answers
			showFeedBack = true;
			feedback = quizQuestion.checkAnwser(1);
			if(quizQuestion.correct)
				Invoke("hideMyWindow",3);
		}
		if (GUI.Button (new Rect (quizWindow.xMax - 230, quizWindow.yMax - 40, 100, 30), answer3)) { 
			//Button C was pressed, this will be the number 2 when checking answers
			showFeedBack = true;
			feedback = quizQuestion.checkAnwser(2);
			if(quizQuestion.correct)
				Invoke("hideMyWindow",3);
		}
		if (GUI.Button(new Rect(quizWindow.xMax-110, quizWindow.yMax-40, 100, 30), answer4)) 
		{
			//Button D was pressed, this will be the number 3 when checking answers
			showFeedBack = true;
			feedback = quizQuestion.checkAnwser(3);
			if(quizQuestion.correct)
				Invoke("hideMyWindow",3);
		}
		//Code for after any possible answer is pressed
		if(showFeedBack){
			GUI.contentColor = Color.yellow;
			GUI.Label(new Rect(quizWindow.x+40,quizWindow.y+100,quizWindow.width,100),feedback);
		}
	}

	//When this function is called anywhere it will close the quiz window.
	//It's only called when the correct answer is chosen therefore we know the quiz
	//is complete.
	public void hideMyWindow(){
		showWindow = false;
		EventPopUp popup = gameObject.AddComponent<EventPopUp>();
		popup.destroyObject ();
	}

	//Destroy the feedback
	public void hideFeedback(){
		showFeedBack = false;
	}
	
	public static int IntParseFast(string value)
	{
		int result = 0;
		for (int i = 0; i < value.Length; i++)
		{
			char letter = value[i];
			result = 10 * result + (letter - 48);
		}
		return result;
	}

}
