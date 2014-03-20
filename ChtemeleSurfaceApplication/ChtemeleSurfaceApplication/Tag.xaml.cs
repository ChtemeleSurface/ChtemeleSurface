using System.Windows;
using Microsoft.Surface.Presentation.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

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
            //if (_mdl.hasImageSelector()) _mdl.textContent = ImageSelector.Text;

            //On valide la carte
            bool success = _mdl.validerCarte();

            updateAll();

            //Update du jeu
            SurfaceWindow1.getInstance.updateCodeView();
            SurfaceWindow1.getInstance.updateZonesJoueur();

            showIndicators();

            //Bruitage
            if (success)
                Sounder.playCardSound(_mdl.card);
            else
                Sounder.playSound(Sounder.FX_ERROR);
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
                // Il ne faut afficher que les joueurs présents dans la partie
                // Nord
                if (_mdl.playerExists(Game_classes.Player.NORD))
                {
                    MA_PlayerNord.Header = SurfaceWindow1.getInstance.getMdl.getPlayerAt(Game_classes.Player.NORD).name;
                    MA_PlayerNord.Visibility = System.Windows.Visibility.Visible;
                    MA_PlayerNord.IsEnabled = true;
                }
                else
                {
                    MA_PlayerNord.Visibility = System.Windows.Visibility.Collapsed;
                    MA_PlayerNord.IsEnabled = false;
                }

                //Est
                if (_mdl.playerExists(Game_classes.Player.EST))
                {
                    MA_PlayerEst.Header = SurfaceWindow1.getInstance.getMdl.getPlayerAt(Game_classes.Player.EST).name;
                    MA_PlayerEst.Visibility = System.Windows.Visibility.Visible;
                    MA_PlayerEst.IsEnabled = true;
                }
                else
                {
                    MA_PlayerEst.Visibility = System.Windows.Visibility.Collapsed;
                    MA_PlayerEst.IsEnabled = false;
                }

                //Ouest
                if (_mdl.playerExists(Game_classes.Player.OUEST))
                {
                    MA_PlayerOuest.Header = SurfaceWindow1.getInstance.getMdl.getPlayerAt(Game_classes.Player.OUEST).name;
                    MA_PlayerOuest.Visibility = System.Windows.Visibility.Visible;
                    MA_PlayerOuest.IsEnabled = true;
                }
                else
                {
                    MA_PlayerOuest.Visibility = System.Windows.Visibility.Collapsed;
                    MA_PlayerOuest.IsEnabled = false;
                }
                    
            }
            else    // MenuDefault
            {
                // Rien à changer
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

        private void showIndicators(){
            string currentPlayerIndicator = "";
            string targetPlayerIndicator = "";

            switch (_mdl.tag)
            {
                case (int)MdlTag.TagCorrespondance.ANTIVIRUS: break;
                case (int)MdlTag.TagCorrespondance.BROWSER_UPDATE: break;
                case (int)MdlTag.TagCorrespondance.CAFE:
                    currentPlayerIndicator = IndicatorMessages.CAFE_EFFECT; break;
                case (int)MdlTag.TagCorrespondance.CODE_INSPECTOR:
                    currentPlayerIndicator = IndicatorMessages.CODE_INSPECTOR_EFFECT; break;
                case (int)MdlTag.TagCorrespondance.CTRL_F5:
                    currentPlayerIndicator = IndicatorMessages.CTRL_F5_EFFECT; break;
                case (int)MdlTag.TagCorrespondance.ERROR_303:
                    currentPlayerIndicator = string.Format(IndicatorMessages.ERROR303_EFFECT, _mdl.targetPlayer.name); break;
                case (int)MdlTag.TagCorrespondance.ERROR_403:
                    currentPlayerIndicator = string.Format(IndicatorMessages.ERROR403_EFFECT, _mdl.targetPlayer.name); break;
                case (int)MdlTag.TagCorrespondance.ERROR_404:
                    targetPlayerIndicator = string.Format(IndicatorMessages.ERROR404_EFFECT, _mdl.targetPlayer.lastCombo().score.ToString()); break;
                case (int)MdlTag.TagCorrespondance.MAN_IN_THE_MIDDLE:
                    currentPlayerIndicator = string.Format(IndicatorMessages.MAN_IN_THE_MIDDLE_EFFECT, _mdl.targetPlayer.name); break;

                default: break;
            }

            if (currentPlayerIndicator.Length != 0)
                SurfaceWindow1.getInstance.indicatorCurrentPlayer(currentPlayerIndicator);
            if (targetPlayerIndicator.Length != 0)
                SurfaceWindow1.getInstance.indicatorAt(targetPlayerIndicator, _mdl.targetPlayer);
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
                        view.Value.TextSelector.Visibility = System.Windows.Visibility.Hidden;
                        
                        string imagesPath = System.IO.Directory.GetCurrentDirectory();
                        imagesPath = imagesPath + "\\Resources\\Image\\";

                        try
                        {
                            string[] files = System.IO.Directory.GetFiles(imagesPath, "*.jpg");
                            ObservableCollection<string> items = new ObservableCollection<string>();
                            Collection<string> names = new Collection<string>();
                            foreach (string file in files)
                            {
                                items.Add(file);
                            }
                            view.Value.ImageSelector.ItemsSource = items;
                        }
                        catch (System.IO.DirectoryNotFoundException) { }
                    }
                    view.Value.layoutMenu();
                    
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

        private void img_Click(object sender, RoutedEventArgs e)
        {
            SurfaceButton btn = e.Source as SurfaceButton;
            string imagesPath = System.IO.Directory.GetCurrentDirectory();
            
            //On recupère le nom de l'image
            string imgName = (btn.Content as Image).Source.ToString();
            bool find = false;
            int length = 0;
            for (int i = imgName.Length-1; i > 0 && find != true; i--)
            {
                if (imgName[i] == '/')
                {
                    find = true;
                    length = i+1;
                }
            }
            imgName = imgName.Substring(length);
            TextSelector.Text = "Resources/Documentation/img/" + imgName;
        }
    }
}
