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
using System.Windows.Forms;

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

        private Timer timerIndicator;

        // Constructeurs                    ======================================================================================================

        public ZoneJoueur()
        {
            InitializeComponent();
            ButtonNextPlayer.IsEnabled = false;

            timerIndicator = new Timer();
            timerIndicator.Interval = 3000;
            timerIndicator.Tick += new EventHandler(OnTimedEvent_IndicatorDissappear);
        }

        // Evénements                  ======================================================================================================

        private void ButtonNextPlayer_Click(object sender, RoutedEventArgs e)
        {
            SurfaceWindow1.getInstance.getMdl.nextSubStep();
            SurfaceWindow1.getInstance.updateRotation();
            SurfaceWindow1.getInstance.updateZonesJoueur();
            SurfaceWindow1.getInstance.updateStepIndicator();
            SurfaceWindow1.getInstance.indicatorCurrentPlayer("A vous de jouer !");

            Sounder.playCurrentPlayerSound();
        }

        private void OnTimedEvent_IndicatorDissappear(object source, EventArgs e)
        {
            Indicator.Visibility = System.Windows.Visibility.Hidden;
            timerIndicator.Stop();
        }

        // Fonctionnalités                  ======================================================================================================

        public void showIndicator(string text)
        {
            Indicator.Text = text;
            Indicator.Visibility = System.Windows.Visibility.Visible;
            timerIndicator.Stop();
            timerIndicator.Start();
        }

        // Update                           ======================================================================================================

        public void update()
        {
            if (active)
            {
                ButtonNextPlayer.IsEnabled = true;
                ButtonNextPlayer.Visibility = System.Windows.Visibility.Visible;
                Background = new SolidColorBrush(Colors.Ivory);
            }
            else
            {
                ButtonNextPlayer.IsEnabled = false;
                ButtonNextPlayer.Visibility = System.Windows.Visibility.Hidden;
                Background = new SolidColorBrush(Colors.RosyBrown);
            }
            CarteJoueur.update();
        }
    }
}
