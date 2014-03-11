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

//using System.Drawing;

using Microsoft.Surface.Presentation.Controls;

using ChtemeleSurfaceApplication.Game_classes;
using ChtemeleSurfaceApplication.Modeles;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour CartesJoueurs.xaml
    /// </summary>
    public partial class CartesJoueurs : ScatterViewItem
    {
        // Constantes, enumérations         ======================================================================================================

        public static int tailleW = 300;
        public static int tailleH = 150;

        // Variables membres                ======================================================================================================

        private MdlCarteJoueur _mdl;
        public int position;
        private static int nbCarteJoueurActiv;

        private Timer timer_BrowserUpdate;
        private Timer timer_CrashBrowser;
        private Timer timer_Freeze;

        // Constructeurs                    ======================================================================================================

        public CartesJoueurs()
        {
            InitializeComponent();

            //cacher gride1 pour choix navigateur
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Hidden;
            ChoixNav.Visibility = System.Windows.Visibility.Visible;
            CarteJoueurGrid.IsEnabled = false;
            ChoixNav.IsEnabled = true;

            // Au départ, aucun modèle car aucun joueur.
            _mdl = null;
            position = 0;
            nbCarteJoueurActiv = 0;

            // image effect cacher au départ
            EffectBrowserUpdate.Visibility = System.Windows.Visibility.Hidden;
            EffectCrashBrowser.Visibility = System.Windows.Visibility.Hidden;
            EffectFreeze.Visibility = System.Windows.Visibility.Hidden;

            //pop up cachées
            PopUpEffectBrowserUpdate.Visibility = System.Windows.Visibility.Hidden;
            PopUpEffectCrashBrowser.Visibility = System.Windows.Visibility.Hidden;
            PopUpEffectFreeze.Visibility = System.Windows.Visibility.Hidden;

            // Timers popups
            timer_BrowserUpdate = new Timer();
            timer_BrowserUpdate.Interval = 3000;
            timer_BrowserUpdate.Tick += new EventHandler(OnTimedEvent_BrowserUpdate);
            timer_BrowserUpdate.Enabled = false;
            timer_CrashBrowser = new Timer();
            timer_CrashBrowser.Interval = 3000;
            timer_CrashBrowser.Tick += new EventHandler(OnTimedEvent_CrashBrowser);
            timer_CrashBrowser.Enabled = false;
            timer_Freeze = new Timer();
            timer_Freeze.Interval = 3000;
            timer_Freeze.Tick += new EventHandler(OnTimedEvent_Freeze);
            timer_Freeze.Enabled = false;

        }

        private void CartesJoueurs_Loaded(object sender, RoutedEventArgs e)
        {
            // Nothing pour le moment
        }

        // Fonctionnalités                  ======================================================================================================

        // Associe un nouveau joueur à la CarteJoueur
        public void ChoixNavigateur(int positionJoueur, int navClicked)
        {
            // Si le navigateur sélectionné a déjà été pris, on se barre direct.
            if (SurfaceWindow1.getInstance.getMdl.getBrowserPosition(navClicked) != Player.OUT)
            {
                return;
            }
            // On dit à Game que ce navigateur est désormais pris.
            Game.getInstance.LocationNav[navClicked] = positionJoueur;

            //On créée le nouveau joueur
            SurfaceWindow1.getInstance.getMdl.newPlayer(new Player(Player.browserNames[navClicked], positionJoueur));
            SurfaceWindow1.getInstance.getMdl.setBrowserPosition(navClicked, positionJoueur);

            switch (positionJoueur)
            {
                case Player.SUD:   _mdl = SurfaceWindow1.getInstance.getMdl.mCarteS; break;
                case Player.OUEST: _mdl = SurfaceWindow1.getInstance.getMdl.mCarteO; break;
                case Player.NORD:  _mdl = SurfaceWindow1.getInstance.getMdl.mCarteN; break;
                case Player.EST:   _mdl = SurfaceWindow1.getInstance.getMdl.mCarteE; break;
                default: _mdl = null; break;
            }

            foreach (KeyValuePair<int, CartesJoueurs> carte in SurfaceWindow1.tabCartes)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == navClicked)
                    {
                        switch (i)
                        {
                            case 0: carte.Value.BtnNav0.IsEnabled = false;
                                break;
                            case 1: carte.Value.BtnNav1.IsEnabled = false;
                                break;
                            case 2: carte.Value.BtnNav2.IsEnabled = false;
                                break;
                            case 3: carte.Value.BtnNav3.IsEnabled = false;
                                break;
                            case 4: carte.Value.BtnNav4.IsEnabled = false;
                                break;
                        }
                    }
                }

            }

            // On déactive le choix de navigateur et on active la carte Joueur
            ChoixNav.IsEnabled = false;
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.IsEnabled = true;
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;

            // Update final
            update();

        }

        // Evénements                  ======================================================================================================

        // Clic sur les boutons de choix de navigateur
        private void SurfaceButton_Click0(object sender, RoutedEventArgs e)
        {
            ChoixNavigateur(position, Player.FIREFOX);
            _mdl.setPlayerName(Player.browserNames[Player.FIREFOX]);
        }

        private void SurfaceButton_Click1(object sender, RoutedEventArgs e)
        {
            ChoixNavigateur(position, Player.CHROME);
            _mdl.setPlayerName(Player.browserNames[Player.CHROME]);
        }

        private void SurfaceButton_Click2(object sender, RoutedEventArgs e)
        {
            ChoixNavigateur(position, Player.IE);
            _mdl.setPlayerName(Player.browserNames[Player.IE]);
        }

        private void SurfaceButton_Click3(object sender, RoutedEventArgs e)
        {
            ChoixNavigateur(position, Player.SAFARI);
            _mdl.setPlayerName(Player.browserNames[Player.SAFARI]);
        }

        private void SurfaceButton_Click4(object sender, RoutedEventArgs e)
        {
            ChoixNavigateur(position, Player.OPERA);
            _mdl.setPlayerName(Player.browserNames[Player.OPERA]);
        }

        //Fonction click afin d'afficher la popup de description de chaque effect
        private void EffectBrowserUpdate_Click(object sender, RoutedEventArgs e)
        {
            PopUpEffectBrowserUpdate.Visibility = System.Windows.Visibility.Visible;
            timer_BrowserUpdate.Enabled = true;            
        }

        private void EffectCrashBrowser_Click(object sender, RoutedEventArgs e)
        {
            PopUpEffectCrashBrowser.Visibility = System.Windows.Visibility.Visible;
            timer_CrashBrowser.Enabled = true;
        }

        private void EffectFreeze_Click(object sender, RoutedEventArgs e)
        {
            PopUpEffectFreeze.Visibility = System.Windows.Visibility.Visible;
            timer_Freeze.Enabled = true;
        }

        // Timer popup

        private void OnTimedEvent_BrowserUpdate(object source, EventArgs e)
        {
            PopUpEffectBrowserUpdate.Visibility = System.Windows.Visibility.Hidden;
            timer_BrowserUpdate.Enabled = false;
        }

        private void OnTimedEvent_CrashBrowser(object source, EventArgs e)
        {
            PopUpEffectCrashBrowser.Visibility = System.Windows.Visibility.Hidden;
            timer_CrashBrowser.Enabled = false;
        }

        private void OnTimedEvent_Freeze(object source, EventArgs e)
        {
            PopUpEffectFreeze.Visibility = System.Windows.Visibility.Hidden;
            timer_Freeze.Enabled = false;
        }


        // Update                         ======================================================================================================

        public void update()
        {
            //affiche pseudo du joueur
            PseudoCarte.Text = _mdl.getPlayerName();
            //affiche points du joueur
            Points.Text = _mdl.getPlayerScore().ToString();
            nbCarteJoueurActiv++;

            if (nbCarteJoueurActiv == Game.getInstance.getNbPlayer())
            {
                SurfaceWindow1.getInstance.getMdl.initGame();
                SurfaceWindow1.getInstance.layoutGameStarted();
            }
            //affiche dernière combinaison de balises posée
            Combinaison.Text = _mdl.getComboCode().ToString();

            //affichage des effects
            if (_mdl.hasBrowserUpdate())
            {
                EffectBrowserUpdate.Visibility = System.Windows.Visibility.Visible;
                EffectBrowserUpdate.IsEnabled = true;
            }
            else
            {
                EffectBrowserUpdate.Visibility = System.Windows.Visibility.Hidden;
                EffectBrowserUpdate.IsEnabled = false;
            }

            if (_mdl.hasCrashBrowser())
            {
                EffectCrashBrowser.Visibility = System.Windows.Visibility.Visible;
                EffectCrashBrowser.IsEnabled = true;
            }
            else
            {
                EffectCrashBrowser.Visibility = System.Windows.Visibility.Hidden;
                EffectCrashBrowser.IsEnabled = false;
            }

            if (_mdl.hasFreeze())
            {
                EffectFreeze.Visibility = System.Windows.Visibility.Visible;
                EffectFreeze.IsEnabled = true;
            }
            else
            {
                EffectFreeze.Visibility = System.Windows.Visibility.Hidden;
                EffectFreeze.IsEnabled = false;
            }
        }

        

    }
}
