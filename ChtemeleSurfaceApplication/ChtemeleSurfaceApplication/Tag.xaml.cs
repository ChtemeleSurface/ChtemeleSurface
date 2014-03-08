﻿using System.Windows;
using Microsoft.Surface.Presentation.Controls;
using System.Collections.Generic;

using ChtemeleSurfaceApplication.Carte_classes.Addons;
using ChtemeleSurfaceApplication.Carte_classes.Attaques;
using ChtemeleSurfaceApplication.Carte_classes;
using ChtemeleSurfaceApplication.Modeles;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour Tag.xaml
    /// </summary>
    public partial class Tag : TagVisualization
    {
        // Constantes, enumérations         ======================================================================================================

        private static Dictionary<int, MdlTag> _mdls = new Dictionary<int,MdlTag>();
        private static Dictionary<int, Tag> _views = new Dictionary<int, Tag>();
        private static int lastIDInsert = 0;

        // Variables membres                ======================================================================================================

        private MdlTag _mdl = null;
        private int _id;

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

            //On masque par défaut tous les éléments du TagVisualiseur
            Message.Visibility = System.Windows.Visibility.Hidden;
            Message.IsEnabled = false;

            MenuDefault.Visibility = System.Windows.Visibility.Hidden;
            MenuDefault.IsEnabled = false;

            MenuAttaque.Visibility = System.Windows.Visibility.Hidden;
            MenuAttaque.IsEnabled = false;

            TextSelector.Visibility = System.Windows.Visibility.Hidden;
            TextSelector.IsEnabled = false;

            ImageSelector.Visibility = System.Windows.Visibility.Hidden;
            ImageSelector.IsEnabled = false;

        }

        // Fonctionnalités                  ======================================================================================================

        private void valider(object sender, RoutedEventArgs e)
        {
            //On saisit les informatiosn entrées dans le modèle
            if (_mdl.hasTextEdit()) _mdl.textContent = TextSelector.Text;
            if (_mdl.hasImageSelector()) _mdl.textContent = ImageSelector.Text;

            //On valide la carte
            _mdl.validerCarte();
            updateAll();

            //On actualise le jeu
            ChtemeleSurfaceApplication.SurfaceWindow1.getInstance.update();
        }

        private void validerNord(object sender, RoutedEventArgs e) { if (_mdl.hasPlayerSelector()) _mdl.setTargetPlayer(Game_classes.Player.NORD); valider(sender, e); }
        private void validerSud(object sender, RoutedEventArgs e) { if (_mdl.hasPlayerSelector()) _mdl.setTargetPlayer(Game_classes.Player.SUD); valider(sender, e); }
        private void validerEst(object sender, RoutedEventArgs e) { if (_mdl.hasPlayerSelector()) _mdl.setTargetPlayer(Game_classes.Player.EST); valider(sender, e); }
        private void validerOuest(object sender, RoutedEventArgs e) { if (_mdl.hasPlayerSelector()) _mdl.setTargetPlayer(Game_classes.Player.OUEST); valider(sender, e); }

        private void gotTag(object sender, RoutedEventArgs e)
        {
            //On a récupéré un tag sur la table, on créée un MdlTag
            ++lastIDInsert;
            _id = lastIDInsert;
            _mdl = new MdlTag((int)VisualizedTag.Value);
            _mdls.Add(lastIDInsert, _mdl);
            _views.Add(lastIDInsert, this);

            _mdl.onTag();

            // Affichage du bon Layout
            updateAll();

            


            /*
            int test3 = CarteAssoc.AssocTagCarte[(int)VisualizedTag.Value].tag;


            if (test3 == 101 || test3 == 105 || test3 == 106 || test3 == 111
                || test3 == 119 || test3 == 121 || test3 == 215 || test3 == 219 ||
                test3 == 221 || test3 == 229 || test3 == 230)
            {
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                Retirer_carte.Text = "clavier";
                // SurfaceTextBox.IsEnabledProperty;
            }
            if (test3 == 217)
            {
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                Retirer_carte.Text = "image";
                // SurfaceScrollViewer.ActualHeightProperty = 50;
            }
            if (test3 == 87 || test3 == 89 || test3 == 91 ||
                test3 == 81 || test3 == 94 || test3 == 95)
            {
                Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                Retirer_carte.Text = "Choisir joueur pour action";
                // affiche la doc au centre car première position dans XAML
                doc1.Visibility = System.Windows.Visibility.Visible;
                validate.Visibility = System.Windows.Visibility.Hidden;

                // ne pas affichier les positions/joueurs inactives
                if (players.joueurS == null)
                    PS.Visibility = System.Windows.Visibility.Hidden;
                if (players.joueurE == null)
                    PE.Visibility = System.Windows.Visibility.Hidden;
                if (players.joueurO == null)
                    PO.Visibility = System.Windows.Visibility.Hidden;
                if (players.joueurN == null)
                    PN.Visibility = System.Windows.Visibility.Hidden;
                
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
                if (carteAssoc == null)
                    carteAssoc = new CarteAssoc();
                if (multiCardOnScreen != 1)
                {
                    ElemMenu.Visibility = System.Windows.Visibility.Hidden;
                    Retirer_carte.Visibility = System.Windows.Visibility.Visible;
                    inputBox.Visibility = System.Windows.Visibility.Hidden;
                    Retirer_carte.Text = "Plusieurs cartes sont détectées, veuillez retirer cette carte.";
                }
                else
                {
                    //tester si c'est une attaque
                    curCard = CarteAssoc.AssocTagCarte[(int)VisualizedTag.Value].getCarte();
                    if (curCard.getTextEdit() == false)
                    {
                        inputBox.Visibility = System.Windows.Visibility.Hidden;
                    }
                }
            }*/
        }

        private void lostTag(object sender, RoutedEventArgs e)
        {

            _mdls.Remove(_id);
            _views.Remove(_id);
            _mdl.loseTag();
            _mdl = null;
            
            updateAll();

            //multiCardOnScreen--;
        }

        private static void updateAll()
        {
            foreach (KeyValuePair<int, MdlTag> mdl in _mdls)
            {
                mdl.Value.computeMulticard();

            }

            foreach (KeyValuePair<int, Tag> view in _views)
            {
                view.Value.Message.Text = view.Value._mdl.getInfoMessage();
                view.Value.Message.Visibility = (view.Value.Message.Text == "") ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;

                if (view.Value._mdl.isPlayable())
                {
                    if (view.Value._mdl.hasTextEdit())  // inputBox
                    {
                        view.Value.TextSelector.Visibility = (view.Value._mdl.isPlayable()) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
                        view.Value.TextSelector.IsEnabled = view.Value._mdl.isPlayable();
                    }


                    if (view.Value._mdl.hasPlayerSelector())    // MenuAttaque
                    {
                        view.Value.MenuAttaque.Visibility = (view.Value._mdl.isPlayable()) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
                        view.Value.MenuAttaque.IsEnabled = view.Value._mdl.isPlayable();
                        view.Value.MenuDefault.Visibility = System.Windows.Visibility.Hidden;
                        view.Value.MenuDefault.IsEnabled = false;
                    }
                    else    // MenuDefault
                    {
                        view.Value.MenuDefault.Visibility = (view.Value._mdl.isPlayable()) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
                        view.Value.MenuDefault.IsEnabled = view.Value._mdl.isPlayable();
                        view.Value.MenuAttaque.Visibility = System.Windows.Visibility.Hidden;
                        view.Value.MenuAttaque.IsEnabled = false;
                    }

                    if (view.Value._mdl.hasImageSelector())  // imageSelector
                    {
                        view.Value.ImageSelector.Visibility = (view.Value._mdl.isPlayable()) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
                        view.Value.ImageSelector.IsEnabled = view.Value._mdl.isPlayable();
                    }
                }
                else
                {
                    view.Value.MenuDefault.Visibility = System.Windows.Visibility.Hidden;
                    view.Value.MenuDefault.IsEnabled = false;

                    view.Value.MenuAttaque.Visibility = System.Windows.Visibility.Hidden;
                    view.Value.MenuAttaque.IsEnabled = false;

                    view.Value.TextSelector.Visibility = System.Windows.Visibility.Hidden;
                    view.Value.TextSelector.IsEnabled = false;

                    view.Value.ImageSelector.Visibility = System.Windows.Visibility.Hidden;
                    view.Value.ImageSelector.IsEnabled = false;
                }


                
            }
            
        }

        private void layoutMenu()
        {
            if (_mdl.hasPlayerSelector())    // MenuAttaque
            {

            }
            else    // MenuDefault
            {

            }
        }

        private void attackPlayer(object sender, RoutedEventArgs e)
        {

        }
    }
}
