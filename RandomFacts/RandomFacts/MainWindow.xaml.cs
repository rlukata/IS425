using System;
using System.IO;
using System.Windows;

namespace RandomFacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /**
         * Event that triggers the click event on the button randomFactButton1
         * This allows the program to load a random fact to begin with
         */
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.randomFactButton1_Click(sender, e);
        }

        /**
         * Read the randomFacts.txt file, which contains a list of random facts
         * The function stores the data in an array of strings
         * It also keeps sorting through the array if it finds an empty string
         */
        private void randomFactButton1_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = File.ReadAllLines(@"randomFacts.txt");
            Random rand = new Random();
            string myRandomFact = lines[rand.Next(lines.Length)];
            while (myRandomFact == "") myRandomFact = lines[rand.Next(lines.Length)];
            randomFactTextBlock.Text = myRandomFact;
        }
    }
}
