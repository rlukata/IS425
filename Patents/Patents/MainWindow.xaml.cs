using System.Windows;

namespace Patents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Patent1_Click(object sender, RoutedEventArgs e)
        {
            var patent1 =
            new
            {
                Title = "Bifocals",
                YearOfPublication = "1784",
                Author = "Benjamin Franklin",
                Invention = "Bifocals are eyeglasses with two distinct optical " +
                "powers. Bifocals are commonly prescribed to people with " +
                "presbyopia who also require a correction for myopia, hyperopia, " +
                "and/or astigmatism. Benjamin Franklin is generally credited with " +
                "the invention of bifocals. Historians have produced some evidence " +
                "to suggest that others may have come before him in the invention; " +
                "however, a correspondence between George Whatley and John Fenno, " +
                "editor of The Gazette of the United States, suggested that Franklin" +
                " had indeed invented bifocals, and perhaps 50 years earlier than" +
                " had been originally thought."
            };

            Author.Text = patent1.Author;
            Invention.Text = patent1.Title;
            Year.Text = patent1.YearOfPublication;
            Description.Text = patent1.Invention;
        }

        private void Patent2_Click(object sender, RoutedEventArgs e)
        {
            var patent2 =
            new
            {
                Title = "Phonograph",
                YearOfPublication = "1877",
                Author = "Thomas Edison",
                Invention = "Edison's phonograph was the first to be able to " +
                "reproduce the recorded sound. His phonograph originally recorded" +
                " sound onto a tinfoil sheet wrapped around a rotating cylinder. A" +
                " stylus responding to sound vibrations produced an up and down or" +
                " hill-and-dale groove in the foil. Alexander Graham Bell's Volta" +
                " Laboratory made several improvements in the 1880s and introduced " +
                "the graphophone, including the use of wax-coated cardboard " +
                "cylinders and a cutting stylus that moved from side to side in a" +
                " zig zag groove around the record."
            };

            Author.Text = patent2.Author;
            Invention.Text = patent2.Title;
            Year.Text = patent2.YearOfPublication;
            Description.Text = patent2.Invention;
        }

        private void Patent3_Click(object sender, RoutedEventArgs e)
        {
            var patent3 =
            new
            {
                Title = "Incandescent light bulb",
                YearOfPublication = "1802",
                Author = "Humphry Davy",
                Invention = "In 1802, Humphry Davy used what he described as " +
                "a battery of immense size consisting of 2000 cells housed in" +
                " the basement of the Royal Institution of Great Britain, to " +
                "create an incandescent light by passing the current through " +
                "a thin strip of platinum chosen because the metal had an extremely" +
                " high melting point. It was not bright enough nor did it last long" +
                " enough to be practical, but it was the precedent behind the " +
                "efforts of scores of experimenters over the next 75 years"
            };

            Author.Text = patent3.Author;
            Invention.Text = patent3.Title;
            Year.Text = patent3.YearOfPublication;
            Description.Text = patent3.Invention;
        }
    }
}
