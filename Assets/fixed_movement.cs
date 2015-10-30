using UnityEngine;
using System.Collections;

public class fixed_movement : MonoBehaviour {
	public float speed;
	public float jumpHeight;
	private bool pauseMovement = false;
	private Rigidbody2D body;
	// Use this for initialization
	void Awake(){
		body = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	//this is essentially a while loop
	void Update () {
		//while we can still move, if a window pops up we no longer check for movement until its gone
		if(!pauseMovement) {
			if(Input.GetKey(KeyCode.A)){
				body.velocity = new Vector2(-speed,body.velocity.y);
			}
			if(Input.GetKey(KeyCode.W)){
				body.velocity = new Vector2(body.velocity.x, jumpHeight);
			}
			if(Input.GetKey(KeyCode.Space)){
				body.velocity = new Vector2(body.velocity.x, jumpHeight);
			}
			if(Input.GetKey(KeyCode.D)){
				body.velocity =  new Vector2(speed,body.velocity.y);
			}
		}
	}

	//Quiz Window Script
	private bool showWindow = true; // set to true once collision happens, then we prepare a quiz window 
	private Rect quizWindow = new Rect(0,0,500,500);
	
	//this function returns the rectangle centered depending on screen size
	Rect centerRectangle(Rect quizWindow){
		quizWindow.x = ( Screen.width - quizWindow.width) / 2 ;
		quizWindow.y = (Screen.height - quizWindow.height) / 2;
		return quizWindow;
	}
	void OnGUI() {
		if (showWindow) {
			//remove comment below in production
			//pauseMovement = true;
			GUI.ModalWindow(0, centerRectangle(quizWindow), DoMyWindow, "Quiz Time!");
		}
			
	}
	void DoMyWindow(int windowID) {
		if (GUI.Button(new Rect(quizWindow.xMin+10, quizWindow.yMax-40, 100, 30), "A")) //bottom left
			print("Pressed A");	
		if (GUI.Button(new Rect(quizWindow.xMin+140, quizWindow.yMax-40, 100, 30), "B")) //bottom left
			print("Pressed B");	
		if (GUI.Button(new Rect(quizWindow.xMax-230, quizWindow.yMax-40, 100, 30), "C")) //bottom left
			print("Pressed C");	
		if (GUI.Button(new Rect(quizWindow.xMax-110, quizWindow.yMax-40, 100, 30), "D")) //bottom left
			print("Pressed D");	
	}

}
