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
            webControl.Source = new Uri(System.IO.Directory.GetCurrentDirectory() + "\\currentHtml.html");
        }

        private void CssChangerChtemele_Click(object sender, RoutedEventArgs e)
        {
            _mdl.changeCSS("chtemele");
            SurfaceWindow1.getInstance.updateCodeView();
        }

        private void CssChangerDark_Click(object sender, RoutedEventArgs e)
        {
            _mdl.changeCSS("dark");
            SurfaceWindow1.getInstance.updateCodeView();
        }

        private void CssChangerLight_Click(object sender, RoutedEventArgs e)
        {
            _mdl.changeCSS("light");
            SurfaceWindow1.getInstance.updateCodeView();
        }

        // Update                           ======================================================================================================

        public void update()
        {
            webControl.Reload(false);
        }
    }
}
