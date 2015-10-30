using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _113Quiz
{
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
}
