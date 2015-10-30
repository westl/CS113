using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _113Quiz
{
    class BasicCountingQuestion : Question
    {
      
        
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int correctAnwser;
           

            public BasicCountingQuestion()
            {
                generateQuestion();

            }

            private void generateQuestion()
            {

                correctAnwser = rnd.Next(5, 11);
                base.question = string.Format(@"Angry robot will not let the player pss until you identify how many red flowers there are. Input the number of flowers?");
                base.anwsers = generateAnwsers(correctAnwser);

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


            public override string checkAnwser(int anwser)
            {
                string response;

                if (anwser == base.correctAnwser)
                {
                    base.correct = true;
                    response = string.Format("Thats right! there are {0} flowers, and two yellow!", base.anwsers[base.correctAnwser]);
                }
                else
                {
                    if (int.Parse(base.anwsers[base.correctAnwser]) > int.Parse(base.anwsers[anwser]))
                    {
                        response = string.Format("I do see {0} red flowers, but i also see more red flowers than that!", base.anwsers[anwser]);
                    }
                    else
                    {
                        response = string.Format("I don't see {0} red flowers! There are more than just red flowers there!", base.anwsers[anwser]);
                    }

                }

                return response;

            }


        }
    
}
