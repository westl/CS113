using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class Quiz
    {
        private int currentQuestion;
        private int numberOfQuestions;
        public List<Question> questions;
		//RANDOM number for the quiz generation 
		Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public Quiz(int numberOfQuestion)
        {
            currentQuestion = 0;
            numberOfQuestions = numberOfQuestion;
            questions = generateQuestions(numberOfQuestions);
        }
	     
        public Question getNextQuestion()
        {

            currentQuestion = currentQuestion + 1;
            return questions[currentQuestion -1 ];
        }

        public Question getCurrentQuestion()
        {
            return questions[currentQuestion];
        }
       

        public int getCurrentQuestionNumber()
        {
            return currentQuestion;
        }

        private List<Question> generateQuestions(int number)
        {

            List<Question> questions = new List<Question>();
			int quizNumber;
            for (int i = 0; i < number; i++)
            {
				//get a random number and accociate that number with a quiz 
				quizNumber = rnd.Next (0,2);

				//if the number is 0 then we want to make a subtraction question
				if(quizNumber == 0)
					questions.Add(new BasicSubtractionQuestion());
				else if (quizNumber == 1)
					questions.Add(new BasicCountingQuestion());

            }

            return questions;
        }

    }


