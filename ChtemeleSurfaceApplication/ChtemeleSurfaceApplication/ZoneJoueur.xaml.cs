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
            timerIndicator.Interval = 6000;
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

        public void showEffectsIndicator()
        {
            string msg = "";
            foreach (Effect effect in CarteJoueur.getMdl.getPlayer().effects())
            {
                if (effect is Effect_classes.BrowserUpdate)
                    msg += IndicatorMessages.BROWSER_UPDATE_EFFECT + '\n';
                else if (effect is Effect_classes.CrashBrowser)
                    msg += IndicatorMessages.CRASH_BROWSER_EFFECT + '\n';
                else if (effect is Effect_classes.Freeze)
                    msg += IndicatorMessages.FREEZE_EFFECT + '\n';
            }
            if (msg.Length != 0)
                SurfaceWindow1.getInstance.indicatorAt(msg, CarteJoueur.getMdl.getPlayer());
        }

        // Update                           ======================================================================================================

        public void update()
        {
            if (active)
            {
                ButtonNextPlayer.IsEnabled = true;
                ButtonNextPlayer.Visibility = System.Windows.Visibility.Visible;
                Background = new SolidColorBrush(Colors.Transparent);
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

        public const string BROWSER_UPDATE_EFFECT                   = "Browser Update : Piochez 2 cartes de plus.";
        public const string CAFE_EFFECT                             = "Piochez jusqu'à avoir 10 cartes en main.";
        public const string CODE_INSPECTOR_EFFECT                   = "Regardez les 4 cartes du dessus de la pioche, mettez-en 2 dans votre main et le reste sur la pioche dans l'ordre de votre choix.";
        public const string CTRL_F5_EFFECT                          = "Défaussez-vous de toutes vos cartes et repiochez-en autant.";

        public const string CRASH_BROWSER_EFFECT                    = "Crash Browser : Piochez 4 cartes de moins.";
        public const string ERROR303_EFFECT                         = "Échangez votre main avec celle de {0}";
        public const string ERROR403_EFFECT                         = "Regardez les cartes de {0} et défaussez-en jusqu'à 6.";
        public const string ERROR404_EFFECT                         = "Vous perdez {0} points.";
        public const string FREEZE_EFFECT                           = "Freeze : Vous passez votre tour.";
        public const string MAN_IN_THE_MIDDLE_EFFECT                = "Regardez les cartes de {0} et volez-lui en jusqu'à 2.";
    }
}
