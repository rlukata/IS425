using System.Windows;

namespace RandomFacts
{
    /// <summary>
    /// Interaction logic for Non_rect.xaml
    /// </summary>
    public partial class Non_rect : Window
    {
        public Non_rect()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}