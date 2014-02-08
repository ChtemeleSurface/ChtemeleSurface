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

        public CartesJoueurs()
        {
            InitializeComponent();
            /*
            PseudoCarte.Text = Player.ListNomsJoueur[0];
             */

            //cacher gride1 pour choix navigateur

        }


        public void ChoixNavigateur(object sender, RoutedEventArgs e)
        {
            //appel PopUp


            //nomJoueur.setNom(Liste[Boutonclique.valeur]);

            //une fois choisi, cacher gride2, afficher gride1
            ChoixNav.Visibility = System.Windows.Visibility.Hidden;
            CarteJoueurGrid.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
