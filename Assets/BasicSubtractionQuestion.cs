using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;




				
public class BasicSubtractionQuestion : Question {

	private int numberOfLollipopsNeeded;

	
	public BasicSubtractionQuestion()
	{

		//set the type of question to generate pictures 
		base.texture = "Lollipops";
		//make the question 
		generateQuestion();

		//set question to false 
		correct = false;
	}
	
	
	private void generateQuestion()
	{
		//number of lollipops the robot needs
		numberOfLollipopsNeeded = base.rnd.Next(0,10);

		//create the question string 
		base.question = string.Format(@"A sad robot needs {0} lollipops to cheer up. There are 10 lollipops total. If the sad robot takes {0} lollipops away, how many lollipops will be left over?", numberOfLollipopsNeeded);

		
		//set the list one answers
		base.anwsers = base.generateAnwsers(10 - numberOfLollipopsNeeded);
		
	}

	
	//takes the index of the correct anwser from 0-3 and tells you if the anwser is correct 
	public override string checkAnwser(int anwserIndex)
	{
		//response to the user if the anwser is correct or incorrect 
		string response;
		
		if (anwserIndex == base.correctAnwser)
		{
			base.correct = true;
			response = string.Format("{1} lollipops? You’re right! 10 minus {0} equals {1}! Now I can eat my lollipops!”", numberOfLollipopsNeeded, anwsers[anwserIndex]);

		}
		else
		{
			base.correct = false;
			response = string.Format(@"Sorry that is not the correct anwser..If you start with 10 lollipops and take {0} away, how many are left?"
			, numberOfLollipopsNeeded);

		}
		
		return response;
		
	}
}
