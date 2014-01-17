using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Surface.Presentation.Controls;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour RenduHTML.xaml
    /// </summary>
    public partial class RenduHTML : ScatterViewItem
    {
        // Variable contenant l'URL ou URI du fichier
        private string fileURL;

        // Constructeur
        public RenduHTML()
        {
            InitializeComponent();
            fileURL = System.IO.Path.GetFullPath("./Resources/Savegame/game_0.html");

            WebRenderer();
        }

        
        // GET & SET
        public string getFileUrl()
        {
            return fileURL;
        }
        public void setFileUrl(string fileUrl)
        {
            fileURL = fileUrl;
        }

        // Initialise la source de la page à afficher
        private void WebRenderer()
        {
            WB1.Navigate(new Uri(getFileUrl()));
        }
    }
}
