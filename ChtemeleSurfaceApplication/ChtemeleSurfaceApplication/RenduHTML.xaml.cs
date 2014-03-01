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

            _mdl = new MdlRenduHtml();
        }

        // Fonctionnalités                  ======================================================================================================

        // Evénements                       ======================================================================================================

        private void webControl_Loaded(object sender, RoutedEventArgs e)
        {
            update();
        }

        // Update                           ======================================================================================================

        public void update()
        {
            //webControl.Source = new Uri();
            _mdl.renderPage();
            webControl.LoadHTML(_mdl.getCode());
            //webControl.Reload(false);
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
