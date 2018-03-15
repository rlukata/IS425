using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

namespace RandomFacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        /**
         * Variable declaration
         */
        private MyFunctions myFunction = new MyFunctions();
        private List<string> myContent;
        
        // static variable that holds the path of edited files
        internal static string myTempFile;

        //holder that contains error message info for try catch block across all classes
        internal static List<string> holder =
            new List<string> { "something went wrong", "load another text file", "the file is empty" };
        
        //holder that contains reset message info
        internal static List<string> reset =
            new List<string> { "No file has been loaded", "Load another text file", "The file is empty" };

        public MainWindow()
        {
            InitializeComponent();
            //this makes the splash screen stay on for 2 seconds
            Thread.Sleep(2000);
        }

        /**
         * Event that triggers the click event on the button randomFactButton
         * This allows the program to load a random fact to begin with
         * It's enable or disable, add/remove Loaded="Window_Loaded" to/from the Window
         * element in XAML
         */

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myContent = reset;
        }

        /**
         * Events triggered by buttons
         */

        //open button
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            myContent = myFunction.OpenTxtFile();
            this.MenuItemClickMe_Click(sender, e);
        }

        //reset button
        private void MenuItemReset_Click(object sender, RoutedEventArgs e)
        {
            myContent.Clear();
            myContent = reset;
            randomFactTextBlock.Text = myFunction.LoadContentIntoFunction(myContent);
        }

        //exit button
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //click_me button
        private void MenuItemClickMe_Click(object sender, RoutedEventArgs e)
        {
            randomFactTextBlock.Text = myFunction.LoadContentIntoFunction(myContent);
        }

        //edit button
        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            myContent = myFunction.SaveAndEditContentIntoFile(myContent);
            this.MenuItemClickMe_Click(sender, e);
        }

        //open non-rectangular window
        private void MenuItemNonRec_Click(object sender, RoutedEventArgs e)
        {
            Non_rect non_Rect = new Non_rect();
            non_Rect.Show();
        }
    }

    /**
     * Partial class that creates several public functions for the
     * GUI to use and pass data around
     */

    partial class MyFunctions
    {
         /**
         * The function stores the data in an array of strings
         * it returns the array of data to be used by the program
         */

        internal List<string> SaveContentFromData(string myData)
        {
            List<string> lines = new List<string> { };
            lines.AddRange(File.ReadAllLines(myData));
            return lines;
        }
        
        /**
         * The function takes a list string of data, stores it in a new file, then it calls
         * the EditContentOfFile function to open Notepad and edit contents
         */

        internal List<string> SaveAndEditContentIntoFile(List<string> myData)
        {
            SaveTxtFile();
            File.WriteAllLines(MainWindow.myTempFile, myData);
            EditContentOfFile(MainWindow.myTempFile);
            return SaveContentFromData(MainWindow.myTempFile);
        }

        /**
         * Process that calls process class to start and close notepad on .txt files
         */

        private void EditContentOfFile(string myPath)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = myPath
                }
            };
            process.Start();
            process.WaitForExit();
        }

        /**
         * This function also keeps sorting through the array if it finds an empty string
         * it returns the string to be used by the GUI
         */

        internal string LoadContentIntoFunction(List<string> myContent)
        {
            Random rand = new Random();
            string myDataContent = myContent[rand.Next(myContent.Count)];
            while (myDataContent == "") myDataContent = myContent[rand.Next(myContent.Count)];
            return myDataContent;
        }

        /**
         * Function that opens a specific type of file
         * it's designed to only find and look for .txt files
         */

        internal List<string> OpenTxtFile()
        {
            //Create string variable to return
            List<string> myContent = MainWindow.holder;

            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                // Set filter for file extension and default file extension
                DefaultExt = ".txt",
                Filter = "TXT Files (*.txt)|*.txt"
            };

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open and read from document
                myContent = SaveContentFromData(dlg.FileName);
            }

            // Detect wether a file is empty by reviewing the first 4 lines
            // Continue the program by replacing content for message found
            // in variable holder
            try
            {
                if (myContent[0] == "" && myContent[1] == "" && myContent[2] == "" && myContent[3] == "")
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch
            {
                myContent = MainWindow.holder;
            }
            return myContent;
        }

        /**
         * Function that saves a specific type of file
         * it's designed to only save and show .txt files
         */

        internal void SaveTxtFile()
        {
            // Create SaveFileDialog
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                // Set filter for file extension and default file extension
                DefaultExt = ".txt",
                Filter = "TXT Files (*.txt)|*.txt"
            };

            // Display SaveFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open and read from document
                MainWindow.myTempFile = dlg.FileName;
            }
        }
    }
}