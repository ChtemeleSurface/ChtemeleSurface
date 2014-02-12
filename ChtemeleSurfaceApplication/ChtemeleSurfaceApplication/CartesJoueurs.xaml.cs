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

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour CartesJoueurs.xaml
    /// </summary>
    public partial class CartesJoueurs : ScatterViewItem
    {
        public static int tailleW = 200;
        public static int tailleH = 150;


        public const int FIREFOX = 0;
        public const int CHROME = 1;
        public const int IE = 2;
        public const int SAFARI = 3;
        public const int OPERA = 4;

        public int position;

        //association des tags avec les cartes
        public static Dictionary<int, string> Navigateurs = new Dictionary<int, string>
        {
            {FIREFOX, "Firefox"},
            {CHROME, "Chrome"},
            {IE, "Internet Explorer"},
            {SAFARI, "Safari"},
            {OPERA, "Opera"}
        };

        public CartesJoueurs()
        {
            InitializeComponent();
            /*
            PseudoCarte.Text = Player.ListNomsJoueur[0];
             */

            //cacher gride1 pour choix navigateur
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Hidden;
            ChoixNav.Visibility = System.Windows.Visibility.Visible;
            CarteJoueurGrid.IsEnabled = false;
            ChoixNav.IsEnabled = true;
        }


        public void ChoixNavigateur(int positionJoueur, int NavClicke)
        {
            //nomJoueur.setNom(Liste[Boutonclique.valeur]);

            if (Game.getInstance.LocationNav[NavClicke] == 0)
            {
                return ;
            }

            Game.getInstance.LocationNav[NavClicke] = positionJoueur;

            switch(positionJoueur)
            {
                case Player.NORD : Game.getInstance.setJoueurN(new Player(NavClicke, this));
                    break;
                case Player.EST: Game.getInstance.setJoueurE(new Player(NavClicke, this));
                    break;
                case Player.SUD: Game.getInstance.setJoueurS(new Player(NavClicke, this));
                    break;
                case Player.OUEST: Game.getInstance.setJoueurO(new Player(NavClicke, this));
                    break;
            }


            //une fois choisi, cacher gride2, afficher gride1
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void SurfaceButton_Click0(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, FIREFOX);


            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.IsEnabled = true;
            ChoixNav.IsEnabled = false;
        }


        //  UPDATE
        public void update()
        {

        }

        private void SurfaceButton_Click1(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, CHROME);

            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.IsEnabled = true;
            ChoixNav.IsEnabled = false;
        }

        private void SurfaceButton_Click2(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, IE);

            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.IsEnabled = true;
            ChoixNav.IsEnabled = false;

        }

        private void SurfaceButton_Click3(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, SAFARI);

            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.IsEnabled = true;
            ChoixNav.IsEnabled = false;
        }

        private void SurfaceButton_Click4(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, OPERA);

            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.IsEnabled = true;
            ChoixNav.IsEnabled = false;

        }
        

    }
}
