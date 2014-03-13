﻿using System.Windows;
using Microsoft.Surface.Presentation.Controls;
using System.Collections.Generic;

using ChtemeleSurfaceApplication.Carte_classes.Addons;
using ChtemeleSurfaceApplication.Carte_classes.Attaques;
using ChtemeleSurfaceApplication.Carte_classes;
using ChtemeleSurfaceApplication.Modeles;
using System.Media;

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
        private static Tag antivirus = null;

        // Variables membres                ======================================================================================================

        private MdlTag _mdl = null;
        private int _id;

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



        // Evénements                  ======================================================================================================

        private void valider(object sender, RoutedEventArgs e)
        {
            //On saisit les informatiosn entrées dans le modèle
            if (_mdl.hasTextEdit()) _mdl.textContent = TextSelector.Text;
            if (_mdl.hasImageSelector()) _mdl.textContent = ImageSelector.Text;

            //On valide la carte
            _mdl.validerCarte();
            updateAll();

            //Update du jeu
            SurfaceWindow1.getInstance.updateCodeView();
            SurfaceWindow1.getInstance.updateZonesJoueur();

            //Bruitage
            Sounder.playCardSound(_mdl.card);
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

            //Si on a un antivirus, on le stocke
            if (_mdl.tag == (int)MdlTag.TagCorrespondance.ANTIVIRUS)
                antivirus = this;

            //On vérifie les catalyses  (si des cartes s'activent automatiquement)
            catalyse();

            // Affichage du bon Layout
            updateAll();

            // Bruitage
            if (!_mdl.isPlayable())
                Sounder.playSound(Sounder.FX_ERROR);
            else
                Sounder.playSound(Sounder.FX_TAGOK);
        }

        private void lostTag(object sender, RoutedEventArgs e)
        {
            _mdl.onRemoved();
            _mdls.Remove(_id);
            _views.Remove(_id);
            _mdl = null;

            updateAll();
        }

        // Fonctionnalités                  ======================================================================================================

        private void layoutMenu()
        {
            if (_mdl.hasPlayerSelector())    // MenuAttaque
            {

            }
            else    // MenuDefault
            {

            }
        }

        private void catalyse()
        {
            foreach (KeyValuePair<int, MdlTag> mdl in _mdls)
            {
                if (!mdl.Value.isPlayable()) continue;

                // CAS 1 : Antivirus + Attaque quelconque
                if (antivirus != null && mdl.Value.typeCard == Carte.TypeCarte.ATTACK_CARD && antivirus._mdl.isPlayable())
                {
                    antivirus._mdl.validerCarte();
                    mdl.Value.canceled = true;
                }
            }
        }

        // Update                           ======================================================================================================

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
    }
}
