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
    /// Logique d'interaction pour PageDoc.xaml
    /// </summary>
    public partial class PageDoc : ScatterViewItem
    {
        // contient l'URL de l'index de la documentation
        public string DocUrl;

        public PageDoc()
        {
            InitializeComponent();
            // Initialise l'adresse de la doc
            DocUrl = System.IO.Directory.GetCurrentDirectory();
            DocUrl = DocUrl + "/Resources/Documentation/index.html";
            //webControl.Source = new Uri(DocUrl);
            
        }
    }
}