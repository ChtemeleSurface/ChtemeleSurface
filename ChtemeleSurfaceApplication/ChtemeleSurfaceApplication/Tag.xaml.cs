using System.Windows;
using Microsoft.Surface.Presentation.Controls;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour Tag.xaml
    /// </summary>
    public partial class Tag : TagVisualization
    {
        private bool played;
        public static int multiCardOnScreen = 0;

        public Tag()
        {
            InitializeComponent();
            played = false;
            multiCardOnScreen++;
            if (multiCardOnScreen != 1)
            {
                ElemMenu.Visibility = System.Windows.Visibility.Hidden;
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                Retirer_carte.Text = "Plusieurs cartes sont détectées, veuillez retirer cette carte.";
            }
        }

        private void valider(object sender, RoutedEventArgs e)
        {
            if (played == false)
            {
                CarteAssoc.AssocTagCarte[(int)VisualizedTag.Value]();
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                ElemMenu.Visibility = System.Windows.Visibility.Hidden;
                Retirer_carte.Text = "Carte jouée, veuillez retirer cette carte.";
                played = true;
            }
        }

        public void destroy()
        {
            //A revoir -> Codage de gros porc
            multiCardOnScreen -= 2;
        }
    }
}
