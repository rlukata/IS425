using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;

namespace EightBall
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void cmdAnswer_Click(object sender, RoutedEventArgs e)
        {           
            // Dramatic delay...
            this.Cursor = Cursors.Wait;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            //AnswerGenerator generator = new AnswerGenerator();
            txtAnswer.Text = GetRandomAnswer(txtQuestion.Text);
            this.Cursor = null;
        }

        private void cmdAnswerValley_Click(object sender, RoutedEventArgs e)
        {
            // Dramatic delay...
            this.Cursor = Cursors.Wait;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            //AnswerGenerator generator = new AnswerGenerator();
            txtAnswer.Text = GetRandomValleyAnswer(txtQuestion.Text);
            this.Cursor = null;
        }

        private void cmdAnswerNerdy_Click(object sender, RoutedEventArgs e)
        {
            // Dramatic delay...
            this.Cursor = Cursors.Wait;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));

            //AnswerGenerator generator = new AnswerGenerator();
            txtAnswer.Text = GetRandomNerdyAnswer(txtQuestion.Text);
            this.Cursor = null;
        }

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
            
            /*
             * In this secion I grabbed the input and saved it in a string
             * I then calculcated the MOD 6 of the hashcode originated from
             * that string, and returned an answer based on the remainder.
             * Which will always be between 0 and 5 (or 1 to 6).
             */

            string myString = txtQuestion.GetLineText(0);
            int mod = Math.Abs(myString.GetHashCode()) % 6;
            if (mod == 0) return answers.first;
            else if (mod == 1) return answers.second;
            else if (mod == 2) return answers.third;
            else if (mod == 3) return answers.fourth;
            else if (mod == 4) return answers.fifth;
            else if (mod == 5) return answers.sixth;
            else return myString.GetHashCode().ToString();
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

            string myString = txtQuestion.GetLineText(0);
            int mod = Math.Abs(myString.GetHashCode()) % 6;
            if (mod == 0) return answersNerdy.first;
            else if (mod == 1) return answersNerdy.second;
            else if (mod == 2) return answersNerdy.third;
            else if (mod == 3) return answersNerdy.fourth;
            else if (mod == 4) return answersNerdy.fifth;
            else if (mod == 5) return answersNerdy.sixth;
            else return myString.GetHashCode().ToString();
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

            string myString = txtQuestion.GetLineText(0);
            int mod = Math.Abs(myString.GetHashCode()) % 6;
            if (mod == 0) return answersValley.first;
            else if (mod == 1) return answersValley.second;
            else if (mod == 2) return answersValley.third;
            else if (mod == 3) return answersValley.fourth;
            else if (mod == 4) return answersValley.fifth;
            else if (mod == 5) return answersValley.sixth;
            else return myString.GetHashCode().ToString();
        }
    }
}