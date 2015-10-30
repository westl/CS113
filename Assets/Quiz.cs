using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _113Quiz
{
    public class Quiz
    {
        private int currentQuestion;
        private int numberOfQuestions;
        public List<Question> questions;

        public Quiz(int numberOfQuestions)
        {
            currentQuestion = 0;
            this.numberOfQuestions = numberOfQuestions;
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

            for (int i = 0; i < number; i++)
            {
                questions.Add(new BasicCountingQuestion());
            }

            return questions;
        }

    }

}
