using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;



/*
 * Every question needs to implement a generate quesion and checkAnswer
 */
    public class Question
    {

		//type of sprite to be loaded with the question 
		public string texture;

		//list of all possible anwsers set 
		public List<string> anwsers;

		//index of the correct anwser (set in generate anwsers function) 
        public int correctAnwser;
       
		//string that represents the question 
        public string question;

		//set to true once an question is answered corretly
        public Boolean correct;
		
		public System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());

		
        public Question()
        {

        }

		//retrun the tecture
		public string getTexture(){
			return texture;
		}

		//return question string 
        public string getQuestionString()
        {
            return question;
        }

		//returns the value of the correct answer 
		public string getCorrectAnwserValue(){
			return anwsers [correctAnwser];
		}

		//returns all of the answer - spelled the wrong - dont want to refactor :( 
        public List<string> getAnwsers()
        {
            return anwsers;
        }

		
        public void setQuestionString(string question)
        {
            this.question = question;
        }

        public virtual string checkAnwser(int p)
        {
            string s = "f";
            return s;
        }

		public List<string> generateAnwsers(int anwser)
		{
			
			string possibleAnwser;
			anwsers = new List<string>();
			//generate 4 random numbers between 10 that are not the anwser or in the list of anwsers
			anwsers.Add (anwser.ToString());
			
			while ( anwsers.Count < 4)
			{
				possibleAnwser = rnd.Next(1, 11).ToString();
				if (!anwsers.Contains(possibleAnwser))
					anwsers.Add(possibleAnwser);
			}
			
			//get a random place to set the correct anwser
			correctAnwser = rnd.Next(0, 4);
			anwsers [0] = anwsers [correctAnwser];
			//place the correct anwser in that place 
			anwsers[correctAnwser] = anwser.ToString() ;
			
			return anwsers;
		}

    }

