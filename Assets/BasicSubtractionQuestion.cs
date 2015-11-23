using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;




				
public class BasicSubtractionQuestion : Question {

	
	Random rnd = new Random(Guid.NewGuid().GetHashCode());
	private int numberOfLollipopsNeeded;

	
	public BasicSubtractionQuestion()
	{
		generateQuestion();
		base.texture = "lollipops";
		
	}
	
	
	private void generateQuestion()
	{
	
		//number of lollipops the robot needs
		numberOfLollipopsNeeded = rnd.Next(0,10);
		//create the question string 
		base.question = string.Format(@"A sad robot needs to {0} lollipops to cheer up. There are 10 lollipops total. If the sad robot takes {0} lollipops away, how many lollipops will be left over?", numberOfLollipopsNeeded);

		base.anwsers = generateAnwsers(10 - numberOfLollipopsNeeded);
		
	}
	
	private List<string> generateAnwsers(int anwser)
	{
		
		List<string> anwsers = new List<string>();
		anwsers.Add(anwser.ToString());
		//generate 3 random numbers between 10 that are not the anwser or in the list of anwsers
		string possibleAnwser;
		while (anwsers.Count < 4)
		{
			possibleAnwser = rnd.Next(1, 11).ToString();
			if (!anwsers.Contains(possibleAnwser))
				anwsers.Add(possibleAnwser);
		}
		
		base.correctAnwser = rnd.Next(0, 4);
		anwsers[0] = anwsers[base.correctAnwser];
		anwsers[base.correctAnwser] = anwser.ToString();
		
		return anwsers;
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
			
			response = string.Format(@"Sorry that is not the correct anwser..If you start with 10 lollipops and take {0} away, how many are left?"
			, numberOfLollipopsNeeded);

		}
		
		return response;
		
	}
}
