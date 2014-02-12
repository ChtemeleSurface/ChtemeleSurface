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
        public static int tailleW = 200;
        public static int tailleH = 150;

        //Modèle
        private MdlCarteJoueur _mdl;


        public CartesJoueurs(MdlCarteJoueur mdl)
        {
            InitializeComponent();
            /*
            PseudoCarte.Text = Player.ListNomsJoueur[0];
             */

            _mdl = mdl;

            //cacher gride1 pour choix navigateur
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Hidden;
            ChoixNav.Visibility = System.Windows.Visibility.Visible;
            CarteJoueurGrid.IsEnabled = false;
            ChoixNav.IsEnabled = true;
        }


        public void ChoixNavigateur(object sender, RoutedEventArgs e)
        {
            //appel PopUp


            //nomJoueur.setNom(Liste[Boutonclique.valeur]);

            //une fois choisi, cacher gride2, afficher gride1
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void SurfaceButton_Click(object sender, RoutedEventArgs e)
        {
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.IsEnabled = true;
            ChoixNav.IsEnabled = false;
        }


        //  UPDATE
        public void update()
        {

        }

    }
}
