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

using Awesomium.Windows.Controls;

using Microsoft.Surface.Presentation.Controls;

using ChtemeleSurfaceApplication.Modeles;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour RenduHTML.xaml
    /// </summary>
    public partial class RenduHTML : ScatterViewItem
    {

        // Constantes, enumérations         ======================================================================================================

        // Variables membres                ======================================================================================================

        private MdlRenduHtml _mdl;

        // Constructeurs                    ======================================================================================================

        public RenduHTML()
        {
            InitializeComponent();
        }

        private void RenduHTML_Loaded(object sender, RoutedEventArgs e)
        {
            _mdl = SurfaceWindow1.getInstance.getMdl.mPageRendu;
            //update();
            //webControl.Source = new Uri(System.IO.Directory.GetCurrentDirectory() + "/currentHtml.html");
        }

        // Fonctionnalités                  ======================================================================================================

        // Evénements                       ======================================================================================================

        private void webControl_Loaded(object sender, RoutedEventArgs e)
        {
            //update();
            webControl.Source = new Uri(System.IO.Directory.GetCurrentDirectory() + "\\currentHtml.html");
        }

        // Update                           ======================================================================================================

        public void update()
        {
            //_mdl.renderPage();

            //Les trucs ci-dessous sont tous des essais infructueux. Chier.

            //webControl.Source = new Uri("file:\\\\\\" + System.IO.Directory.GetCurrentDirectory() + "\\currentHtml.html");
            //Console.Write("file:\\\\\\" + System.IO.Directory.GetCurrentDirectory() + "\\currentHtml.html");

            //webControl.Source = new Uri(System.IO.Directory.GetCurrentDirectory() + "\\currentHtml.html");
            //Console.Write(System.IO.Directory.GetCurrentDirectory() + "\\currentHtml.html");

            //webControl.DataContext = new Uri(System.IO.Directory.GetCurrentDirectory());
            //webControl.LoadHTML(_mdl.getCode());

            //webControl.DataContext = new Uri(System.IO.Directory.GetCurrentDirectory() + "/");
            //webControl.LoadHTML(_mdl.getCode());
            //webControl.Source = new Uri(System.IO.Directory.GetCurrentDirectory() + "\\currentHtml.html");
            webControl.Reload(false);
            //webControl.loadUrl("file:\\\\\\" + System.IO.Directory.GetCurrentDirectory() + "\\currentHtml.html")
        }

        private void SurfaceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SurfaceButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void SurfaceButton_Click_2(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
