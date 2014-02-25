using System.Windows;
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
                inputBox.Visibility = System.Windows.Visibility.Hidden;
                Retirer_carte.Text = "Carte jouée, veuillez retirer cette carte.";
                played = true;
            }
            if (curCard.getTextEdit() == true)
                curCard.setText(inputBox.Text);
            curCard.onValid();
            Game_classes.Game.getInstance.nextPlayer();
        }

        private void gotTag(object sender, RoutedEventArgs e)
        {
            multiCardOnScreen++;
            //Bloque les tags si la parti n'est pas initialisé
            if (Game_classes.Game.getInstance.getGameStarted() == false)
                this.Visibility = System.Windows.Visibility.Collapsed;
            else
            {
                played = false;
                /*if (carteAssoc == null)
                    carteAssoc = new CarteAssoc();*/
                if (multiCardOnScreen != 1)
                {
                    ElemMenu.Visibility = System.Windows.Visibility.Hidden;
                    Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                    inputBox.Visibility = System.Windows.Visibility.Hidden;
                    Retirer_carte.Text = "Plusieurs cartes sont détectées, veuillez retirer cette carte.";
                }
                else
                {
                    curCard = CarteAssoc.AssocTagCarte[(int)VisualizedTag.Value].getCarte();
                    if (curCard.getTextEdit() == false)
                    {
                        inputBox.Visibility = System.Windows.Visibility.Hidden;
                    }
                }
            }
        }

        private void lostTag(object sender, RoutedEventArgs e)
        {
            multiCardOnScreen--;
        }
    }
}
