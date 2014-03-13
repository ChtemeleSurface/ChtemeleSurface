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
using Microsoft.Surface.Presentation.Generic;
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
            SurfaceWindow1.getInstance.indicatorCurrentPlayer(IndicatorMessages.YOUR_TURN);

            Sounder.playCurrentPlayerSound();
        }

        private void OnTimedEvent_IndicatorDissappear(object source, EventArgs e)
        {
            ScatterIndicator.Visibility = System.Windows.Visibility.Collapsed;
            ScatterIndicator.IsEnabled = false;
            timerIndicator.Stop();
        }

        // Fonctionnalités                  ======================================================================================================

        public void showIndicator(string text)
        {
            Indicator.Text = text;
            ScatterIndicator.Visibility = System.Windows.Visibility.Visible;
            ScatterIndicator.IsEnabled = true;
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
                ButtonNextPlayer.Visibility = System.Windows.Visibility.Collapsed;
                Background = new SolidColorBrush(Colors.RosyBrown);
            }
            CarteJoueur.update();
        }
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Contient les différentes chaines de texte qui peuvent être affichées dans l'indicateur
    /// </summary>
    public static class IndicatorMessages
    {
        public const string YOUR_TURN                               = "C'est à vous de jouer !";

        public const string BROWSER_UPDATE_TOOLTIP                  = "Browser Update : Au prochain tour vous piochez 2 cartes de plus.";
        public const string CRASH_BROWSER_TOOLTIP                   = "Crash Browser : Au prochain tour vous piocherez 4 cartes de moins.";
        public const string FREEZE_TOOLTIP                          = "Freeze : Vous passerez votre prochain tour.";
    }
}
