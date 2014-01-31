using System.Windows;
using Microsoft.Surface.Presentation.Controls;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour Tag.xaml
    /// </summary>
    public partial class Tag : TagVisualization
    {
        public Tag()
        {
            InitializeComponent();
        }

        private void valider(object sender, RoutedEventArgs e)
        {
            CarteAssoc.AssocTagCarte[(int)VisualizedTag.Value]();
        }
    }
}
