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

        public static int tailleW = 200;
        public static int tailleH = 150;

        // Variables membres                ======================================================================================================

        private MdlCarteJoueur _mdl;
        public int position;
        private static int nbCarteJoueurActiv;

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
        }

        // Fonctionnalités                  ======================================================================================================

        // Associe un nouveau joueur à la CarteJoueur
        public void ChoixNavigateur(int positionJoueur, int NavClicke)
        {
            // Si le navigateur sélectionné a déjà été pris, on se barre direct.
            if (Game.getInstance.LocationNav[NavClicke] != 0)
            {
                return ;
            }
            // On dit à Game que ce navigateur est désormais pris.
            Game.getInstance.LocationNav[NavClicke] = positionJoueur;

            //On créée le nouveau joueur
            switch(positionJoueur)
            {
                case Player.NORD :
                    _mdl = new MdlCarteJoueur(new Player(Player.browserNames[NavClicke], positionJoueur));
                    Game.getInstance.joueurN = _mdl.getPlayer();
                    break;
                case Player.EST: 
                    _mdl = new MdlCarteJoueur(new Player(Player.browserNames[NavClicke], positionJoueur));
                    Game.getInstance.joueurE = _mdl.getPlayer();
                    break;
                case Player.SUD: 
                    _mdl = new MdlCarteJoueur(new Player(Player.browserNames[NavClicke], positionJoueur));
                    Game.getInstance.joueurS = _mdl.getPlayer();
                    break;
                case Player.OUEST: 
                    _mdl = new MdlCarteJoueur(new Player(Player.browserNames[NavClicke], positionJoueur));
                    Game.getInstance.joueurO = _mdl.getPlayer();
                    break;
            }

            foreach (KeyValuePair<int, CartesJoueurs> carte in SurfaceWindow1.tabCartes)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == NavClicke)
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

        // Update                         ======================================================================================================

        public void update()
        {
            PseudoCarte.Text = _mdl.getPlayerName();
            Points.Text = _mdl.getPlayerScore().ToString();
            nbCarteJoueurActiv++;

            if (nbCarteJoueurActiv == Game.getInstance.getNbPlayer())
            {
                Game.getInstance.hideCarteJoueur();
            }
        }
    }
}
