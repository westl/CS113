using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


public	class BasicAdditionQuestion : Question
	{
		
		Random rnd = new Random(Guid.NewGuid().GetHashCode());
		int biggerNumber;
		int smallerNumber;
		
		public BasicAdditionQuestion()
		{
			generateQuestion();
			base.texture = "Bricks";
		}
		
		private void generateQuestion()
		{
			
			biggerNumber = rnd.Next(5,11);
			smallerNumber = rnd.Next(1, biggerNumber);
			base.question = string.Format(@"A sad robot needs to fill the gap in the path in order to cross and meet his robot friends. But he doesn't know how many bricks he needs to put down. There are {0} bricks total, but only {1} are in place. How many bricks does he need?", biggerNumber, smallerNumber);
			
			int anwser = biggerNumber - smallerNumber;
			base.anwsers = generateAnwsers(anwser);
			
		}
		
		
		
		public override string checkAnwser(int anwser)
		{
			string response;
			
			if (anwser == base.correctAnwser)
			{
				base.correct = true;
				response = string.Format("{0} bricks? Let's try it... you're right! It WAS {0} bricks!", base.anwsers[base.correctAnwser]);
			}
			else{
				if (int.Parse(base.anwsers[base.correctAnwser]) > int.Parse(base.anwsers[anwser]))
				{
					base.correct = false;
					response = string.Format("I think i need more than {0} brick.... there needs to be {1} total",base.anwsers[anwser],biggerNumber,smallerNumber, smallerNumber + int.Parse(base.anwsers[anwser]));
				}
				else
				{
					base.correct = false;
					response = string.Format("I think i need less than {0} brick.... there needs to be {1} total", base.anwsers[anwser], biggerNumber, smallerNumber, smallerNumber + int.Parse(base.anwsers[anwser]));
					
				}
				
			}
			
			return response;
			
		}
		
		

}
