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

        public Tag()
        {
            InitializeComponent();
            played = false;
        }

        private void valider(object sender, RoutedEventArgs e)
        {
            if (played == false)
            {
                CarteAssoc.AssocTagCarte[(int)VisualizedTag.Value]();
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                ElemMenu.Visibility = System.Windows.Visibility.Hidden;
                Retirer_carte.Text = "Carte jouée, veuillez retirer la carte.";
                played = true;
            }
        }
    }
}
