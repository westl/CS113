using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


    class BasicCountingQuestion : Question
    {
      
        
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int correctAnwser;
			

            public BasicCountingQuestion()
            {
                generateQuestion();
				base.texture = "Pink Flower";

            }

		
            private void generateQuestion()
            {

                correctAnwser = rnd.Next(5, 11);
                base.question = string.Format(@"Angry robot will not let the player pass until you identify how many pink flowers there are. Input the number of flowers?");
                base.anwsers = generateAnwsers(correctAnwser);

            }


            public override string checkAnwser(int anwser)
            {
                string response;

                if (anwser == base.correctAnwser)
                {
                    base.correct = true;
                    response = string.Format("Thats right! there are {0} pink flowers", base.anwsers[base.correctAnwser]);
                }
                else
                {
                    if (int.Parse(base.anwsers[base.correctAnwser]) > int.Parse(base.anwsers[anwser]))
                    {
                        response = string.Format("I do see {0} pink flowers, there are more pink flowers than that!", base.anwsers[anwser]);
                    }
                    else
                    {
				response = string.Format("I don't see {0} pink flowers! there are more pink flowers than that!", base.anwsers[anwser]);
                    }

                }

                return response;

            }


        }
    

