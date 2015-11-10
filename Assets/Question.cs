﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class Question
    {
        
        public int correctAnwser;
        public List<string> anwsers;
        public string question;
        public Boolean correct;

        public Question()
        {
            this.question = "";
            correct = false;
        }


        public string getQuestionString()
        {
            return question;
        }

		public string getCorrectAnwserValue(){
			return anwsers [correctAnwser];
		}

		
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

    }

