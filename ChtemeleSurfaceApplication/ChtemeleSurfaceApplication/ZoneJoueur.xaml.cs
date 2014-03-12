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
using System.Media;

using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour ZoneJoueur.xaml
    /// </summary>
    public partial class ZoneJoueur : ScatterViewItem
    {
        // Constantes, enumérations         ======================================================================================================



        // Variables membres                ======================================================================================================

        public bool active = false;

        // Constructeurs                    ======================================================================================================

        public ZoneJoueur()
        {
            InitializeComponent();
            ButtonNextPlayer.IsEnabled = false;
        }

        // Evénements                  ======================================================================================================

        private void ButtonNextPlayer_Click(object sender, RoutedEventArgs e)
        {
            SurfaceWindow1.getInstance.getMdl.nextSubStep();
            SurfaceWindow1.getInstance.updateRotation();
            SurfaceWindow1.getInstance.updateZonesJoueur();
            SurfaceWindow1.getInstance.updateStepIndicator();

            Sounder.playCurrentPlayerSound();
        }

        // Fonctionnalités                  ======================================================================================================



        // Update                           ======================================================================================================

        public void update()
        {
            if (active)
            {
                ButtonNextPlayer.IsEnabled = true;
                ButtonNextPlayer.Visibility = System.Windows.Visibility.Visible;
                Background = new SolidColorBrush(Colors.Ivory);
                CarteJoueur.update();

            }
            else
            {
                ButtonNextPlayer.IsEnabled = false;
                ButtonNextPlayer.Visibility = System.Windows.Visibility.Hidden;
                Background = new SolidColorBrush(Colors.RosyBrown);
            }
        }
    }
}
