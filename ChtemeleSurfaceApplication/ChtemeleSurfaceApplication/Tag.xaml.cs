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
        private static Game_classes.Game gameClass;
        private static Game_classes.Player players;
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
                //On valid() de la carte

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

            int test3 = CarteAssoc.AssocTagCarte[(int)VisualizedTag.Value].tag;

            /* int hexa
             * Besoin clavier
             * 101 65
             * 105 69
             * 106 6A
             * 111 6F
             * 119 77
             * 121 79
             * 215 D7
             * 219 DB
             * 221 DD
             * 229 E5
             * 230 E6
             * */
            if (test3 == 101 || test3 == 105 || test3 == 106 || test3 == 111
                || test3 == 119 || test3 == 121 || test3 == 215 || test3 == 219 ||
                test3 == 221 || test3 == 229 || test3 == 230)
            {
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                Retirer_carte.Text = "clavier";
                // SurfaceTextBox.IsEnabledProperty;
            }
            /*
            * Besoin image
            * 217 D9
            * 
            * */
            if (test3 == 217)
            {
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                Retirer_carte.Text = "image";
                // SurfaceScrollViewer.ActualHeightProperty = 50;
            }
            /*
            * action
            * 87 57
            * 89 59
            * 91 5B
            * 81 51
            * 94 5E
            * 95 5F
            * */
            if (test3 == 87 || test3 == 89 || test3 == 91 ||
                test3 == 81 || test3 == 94 || test3 == 95)
            {
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                Retirer_carte.Text = "Choisir joueur pour action";
                // affiche la doc au centre car première position dans XAML
                doc1.Visibility = System.Windows.Visibility.Visible;
                validate.Visibility = System.Windows.Visibility.Hidden;

                // ne pas affichier les positions/joueurs inactives
                /*if (players.joueurS == null)
                    PS.Visibility = System.Windows.Visibility.Hidden;
                if (players.joueurE == null)
                    PE.Visibility = System.Windows.Visibility.Hidden;
                /*if (players.joueurO == null)
                    PO.Visibility = System.Windows.Visibility.Hidden;
                if (players.joueurN == null)
                    PN.Visibility = System.Windows.Visibility.Hidden;
                */

                // desangage le joueur actif
                switch (gameClass.getCurPlayer().position())
                {
                    case 1:
                        {
                            PN.Visibility = System.Windows.Visibility.Hidden;
                        } break;
                    case 2:
                        {
                            PE.Visibility = System.Windows.Visibility.Hidden;
                        } break;
                    case 3:
                        {
                            PS.Visibility = System.Windows.Visibility.Hidden;
                        } break;
                    case 4:
                        {
                            PO.Visibility = System.Windows.Visibility.Hidden;
                        } break;
                }

                // réception de la valeur retourné par le clic
                int playerChoosen;



                // lancera donc l'effet "test3" sur playerChoosen en modifiant ses variables
                switch (test3)
                {
                    case 87:
                        {

                        } break;
                    case 89:
                        {

                        } break;
                    case 91:
                        {

                        } break;
                    case 81:
                        {

                        } break;
                    case 94:
                        {

                        } break;
                    case 95:
                        {

                        } break;
                }
            }


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

        private void attackPlayer(object sender, RoutedEventArgs e)
        {

        }
    }
}
