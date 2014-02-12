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

            if (Game.getInstance.LocationNav[NavClicke] != 0)
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

            ChoixNav.IsEnabled = false;
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.IsEnabled = true;
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            
        }

        private void SurfaceButton_Click0(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, FIREFOX);
            PseudoCarte.Text = Navigateurs[FIREFOX];

            //CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            //ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            //CarteJoueurGrid.IsEnabled = true;
        }


        //  UPDATE
        public void update()
        {

        }

        private void SurfaceButton_Click1(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, CHROME);
            PseudoCarte.Text = Navigateurs[CHROME];

           // CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            //ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            //CarteJoueurGrid.IsEnabled = true;
        }

        private void SurfaceButton_Click2(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, IE);
            PseudoCarte.Text = Navigateurs[IE];

            //CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
           // ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            //CarteJoueurGrid.IsEnabled = true;

        }

        private void SurfaceButton_Click3(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, SAFARI);
            PseudoCarte.Text = Navigateurs[SAFARI];

            //CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            //ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            //CarteJoueurGrid.IsEnabled = true;
        }

        private void SurfaceButton_Click4(object sender, RoutedEventArgs e)
        {

            ChoixNavigateur(position, OPERA);
            PseudoCarte.Text = Navigateurs[OPERA];

            //CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            //ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            //CarteJoueurGrid.IsEnabled = true;

        }
        

    }
}
