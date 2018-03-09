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
        /**
         * Variable declaration
         */
        MyFunctions myFunction = new MyFunctions();
        String[] myContent;
        String myResult;

        //holder that contains error message info for try catch block across all classes
        public static String[] holder = { "something went wrong", "load another text file", "the file is empty" };

        public MainWindow()
        {
            InitializeComponent();

            //this makes the splash screen stay on for 2 seconds
            System.Threading.Thread.Sleep(2000);
        }

        /**
         * Event that triggers the click event on the button randomFactButton1
         * This allows the program to load a random fact to begin with
         * It's enable or disable, add/remove Loaded="Window_Loaded" to/from the Window 
         * element in XAML
         */
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                myContent = myFunction.SaveContentFromData(@"randomFacts.txt");
            }catch
            {
                myContent = holder;
            }

            this.MenuItemReset_Click(sender, e);
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            myContent = myFunction.OpenTxtFile();
            this.MenuItemClickMe_Click(sender, e);
        }

        private void MenuItemReset_Click(object sender, RoutedEventArgs e)
        {
            myResult = myFunction.LoadContentIntoFunction(myContent);
            randomFactTextBlock.Text = myResult;
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemClickMe_Click(object sender, RoutedEventArgs e)
        {
            myResult = myFunction.LoadContentIntoFunction(myContent);
            randomFactTextBlock.Text = myResult;
        }
    }


    /**
     * New partial class that creates several public functions for the
     * GUI to use and pass data around
     */
    public partial class MyFunctions
    {
        /**
         * The function stores the data in an array of strings
         * it returns the array of data to be used by the program
         */
        public string[] SaveContentFromData(string myData)
        {
           string[] lines = File.ReadAllLines(myData);
           return lines;
        }

        /**
         * This function also keeps sorting through the array if it finds an empty string
         * it returns the string to be used by the GUI
         */
        public string LoadContentIntoFunction(string[] myContent)
        {
            Random rand = new Random();
            string myDataContent = myContent[rand.Next(myContent.Length)];
            while (myDataContent == "") myDataContent = myContent[rand.Next(myContent.Length)];
            return myDataContent;
        }

        /**
         * Function that opens a specific type of file
         * it's designed to only find and look for .txt files
         */
        public string[] OpenTxtFile()
        {
            //Create string variable to return
            string[] myContent = MainWindow.holder;

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "TXT Files (*.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open and read from document
                myContent = SaveContentFromData(dlg.FileName);
            }

            // Detect wether a file is empty by reviewing the first 4 lines
            // Continue the program by adding a message
            try
            {
                if (myContent[0] == "" && myContent[1] == "" && myContent[2] == "" && myContent[3] == "")
                {
                    throw new IndexOutOfRangeException();
                }
            }catch
            {
                myContent = MainWindow.holder;
            }            
            return myContent;
        }
    }
}
