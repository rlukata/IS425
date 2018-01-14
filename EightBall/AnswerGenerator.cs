using System;
using System.Collections.Generic;
using System.Text;

/**
 * NOT USED
 * MOVED CODE TO Windo1.xaml.cs
 */

namespace EightBall
{
    class AnswerGenerator
    {
        public string GetRandomAnswer(string question)
        {
            var answers = new
            {
                first = "Ask Again later",
                second = "Can Not Predict Now",
                third = "Without a Doubt",
                fourth = "Is Decidely So",
                fifth = "Concentrate and Ask Again",
                sixth = "My Sources Say No",
            };
            
            Random rnd = new Random();
            return answers.first;
        }

        public string GetRandomNerdyAnswer(string question)
        {
            var answersNerdy = new
            {
                first = "Try rebooting again",
                second = "Call support and try again",
                third = "Definately",
                fourth = "I think the answer is yes",
                fifth = "Debug and Ask Again",
                sixth = "My Source code says no"
            };

            Random rnd = new Random();
            return answersNerdy.fourth;
        }

        public string GetRandomValleyAnswer(string question)
        {
            var answersValley = new
            {
                first = "IDK, ask me later",
                second = "No, IDK, stop asking",
                third = "YAAAAS QUEEN",
                fourth = "Yessss",
                fifth = "I'm not listening, what?",
                sixth = "My BFF said NO"
            };

            Random rnd = new Random();
            return answersValley.sixth;
        }
    }
}
