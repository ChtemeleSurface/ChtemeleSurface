﻿using System.Windows;
using Microsoft.Surface.Presentation.Controls;

using ChtemeleSurfaceApplication.Carte_classes.Addons;
using ChtemeleSurfaceApplication.Carte_classes.Attaques;
using ChtemeleSurfaceApplication.Carte_classes; 

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour Tag.xaml
    /// </summary>
    public partial class Tag : TagVisualization
    {
        // Constantes, enumérations         ======================================================================================================

        // Variables membres                ======================================================================================================

        private bool played;
        public static int multiCardOnScreen = 0;
        private static Carte curCard;
        private static CarteAssoc carteAssoc;

        // Constructeurs                    ======================================================================================================

        public Tag()
        {
            InitializeComponent();
        }

        // Fonctionnalités                  ======================================================================================================

        private void valider(object sender, RoutedEventArgs e)
        {
            if (played == false)
            {
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                ElemMenu.Visibility = System.Windows.Visibility.Hidden;
                Retirer_carte.Text = "Carte jouée, veuillez retirer cette carte.";
                played = true;
            }
            Game_classes.Game.getInstance.nextPlayer();
        }

        private void gotTag(object sender, RoutedEventArgs e)
        {
            played = false;
            multiCardOnScreen++;
            /*if (carteAssoc == null)
                carteAssoc = new CarteAssoc();*/
            if (multiCardOnScreen != 1)
            {
                ElemMenu.Visibility = System.Windows.Visibility.Hidden;
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                Retirer_carte.Text = "Plusieurs cartes sont détectées, veuillez retirer cette carte.";
            }
            else
                curCard = CarteAssoc.AssocTagCarte[(int)VisualizedTag.Value].getCarte();
        }

        private void lostTag(object sender, RoutedEventArgs e)
        {
            multiCardOnScreen--;
        }
    }
}
