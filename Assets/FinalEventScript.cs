using UnityEngine;
using System.Collections;

public class FinalEventScript : MonoBehaviour {
	private bool showFinalWindow = false;
	private Rect centerWindow = new Rect(0,0,800,500);
	private string completionScript;
	private Texture2D itemToDraw;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.collider.tag.Equals ("Player")) {
			showFinalWindow = true;
		}
	}

	void OnGUI() {
		if (showFinalWindow) {
			centerWindow = centerRectangle(centerWindow);
			GUI.Window(0, centerWindow, DoMyWindow, "Game Completed!" + "\n" + completionScript);
			GUI.skin.window.wordWrap = true;
			itemToDraw = (Texture2D)Resources.Load("MarissaPixels/conclusion");
			if(itemToDraw!=null){
				GUI.DrawTexture(new Rect(centerWindow.x,centerWindow.y, centerWindow.width, centerWindow.height), itemToDraw);
				print ("drawing");
			}
				
		
		}
	}

	void DoMyWindow(int windowID) {

	}

	//Not actually a quiz window, copied the code to center the rectangle.
	Rect centerRectangle(Rect quizWindow){
		quizWindow.x = ( Screen.width - quizWindow.width) / 2 ;
		quizWindow.y = ( Screen.height - quizWindow.height) / 2;
		return quizWindow;
	}

}
