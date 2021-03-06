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
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;

using ChtemeleSurfaceApplication.Modeles;

using ChtemeleSurfaceApplication.Game_classes;
using System.Media;



namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        // Constantes, enum�rations         ======================================================================================================

        public static SurfaceWindow1 instance = null;               //Singleton
        public static SurfaceWindow1 getInstance{get{return instance;}}
        public MdlGame getMdl { get { return _mdl; } }

        // Variables membres                ======================================================================================================

        private MdlGame _mdl;
        //private Game _game;                                         // R�f�rence vers le jeu
        public static Dictionary<int, CartesJoueurs> tabCartes;     // Tableau des cartes Joueurs localis�es

        // Constructeurs                    ======================================================================================================

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();
            instance = this;

            tabCartes = new Dictionary<int, CartesJoueurs>
            {
                {Player.SUD, ZoneJoueurS.CarteJoueur},
                {Player.EST, ZoneJoueurE.CarteJoueur},
                {Player.NORD, ZoneJoueurN.CarteJoueur},
                {Player.OUEST, ZoneJoueurO.CarteJoueur}
            };

            // Position des cartes joueurs
            ZoneJoueurN.CarteJoueur.position = Player.NORD;
            ZoneJoueurS.CarteJoueur.position = Player.SUD;
            ZoneJoueurE.CarteJoueur.position = Player.EST;
            ZoneJoueurO.CarteJoueur.position = Player.OUEST;

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();

            ComputeWidgetsPositions(MainScatterView.Width, MainScatterView.Height);
        }
        
        private void SurfaceWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _mdl = new MdlGame();
            updateStepIndicator();

        }

        // Accesseurs & Mutateurs           ======================================================================================================

        public ZoneJoueur getCurrentPlayerZone()
        {
            switch (_mdl.getCurrentPlayer().position())
            {
                case Player.SUD: return SurfaceWindow1.getInstance.ZoneJoueurS;
                case Player.OUEST: return SurfaceWindow1.getInstance.ZoneJoueurO;
                case Player.NORD: return SurfaceWindow1.getInstance.ZoneJoueurN;
                case Player.EST: return SurfaceWindow1.getInstance.ZoneJoueurE;
                default: return null;
            }
        }

        // Ev�nements                  ======================================================================================================

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        /// <summary>
        /// Re-dessine la fen�tre, repositionne les �l�ments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainScatterView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ComputeWidgetsPositions(e.NewSize.Width, e.NewSize.Height);
        }

        public void rotateCenterView(int pos)
        {
            switch(pos)
            {
                case Player.SUD:
                    CenterView.Orientation = 0;
                    PageCode.Orientation = 0;
                    PageRendu.Orientation = 0;
                    break;
                case Player.OUEST:
                    CenterView.Orientation = 0;
                    PageCode.Orientation = 90;
                    PageRendu.Orientation = 90;
                    break;
                case Player.NORD:
                    CenterView.Orientation = 180;
                    PageCode.Orientation = 0;
                    PageRendu.Orientation = 0;
                    break;
                case Player.EST:
                    CenterView.Orientation = 180;
                    PageCode.Orientation = 90;
                    PageRendu.Orientation = 90;
                    break;
                default: break;
            }
        }

        private void twoPlayer(object sender, RoutedEventArgs e)
        {
            _mdl.setNbPlayer(2);
            initGrid.Visibility = System.Windows.Visibility.Hidden;
            playGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void threePlayer(object sender, RoutedEventArgs e)
        {
            _mdl.setNbPlayer(3);
            initGrid.Visibility = System.Windows.Visibility.Hidden;
            playGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void fourPlayer(object sender, RoutedEventArgs e)
        {
            _mdl.setNbPlayer(4);
            initGrid.Visibility = System.Windows.Visibility.Hidden;
            playGrid.Visibility = System.Windows.Visibility.Visible;
        }

        protected void OnPreviewTouchDown(object sender, TouchEventArgs e)
        {
            bool isFinger = e.TouchDevice.GetIsFingerRecognized();
            bool isTag = e.TouchDevice.GetIsTagRecognized();

            if (isFinger == false && isTag == false)
            {
                e.Handled = true;
            }
        }

        // Fonctionnalit�s                  ======================================================================================================

        private void ComputeWidgetsPositions(double x, double y)
        {
            //Position des zones joueurs
            ZoneJoueurS.Center = new Point((x / 2) - 20, y - (ZoneJoueurS.Height / 2));
            ZoneJoueurO.Center = new Point(ZoneJoueurO.Height / 2, (y / 2) - 20);
            ZoneJoueurN.Center = new Point((x / 2) + 20, ZoneJoueurN.Height / 2);
            ZoneJoueurE.Center = new Point(x - ZoneJoueurE.Height / 2, (y / 2) + 20);

            //taille et position du centralview
            CenterView.Height = y - ZoneJoueurS.Height - ZoneJoueurN.Height;
            CenterView.Width = x - ZoneJoueurO.Height - ZoneJoueurE.Height;
            CenterView.Center = new Point(x / 2.0, y / 2.0);

            // Taille du scatter contenant les deux rendus + la zone de pioche
            ScatterCenterView.Height = CenterView.Height;
            ScatterCenterView.Width = CenterView.Width;

            // Emplacement selon rotation des �lements des rendus
            if ((CenterView.Orientation == 0 && PageCode.Orientation == 90) || (PageCode.Orientation == 180 && PageCode.Orientation == 90))
            {

                ZonePioche.Width = ScatterCenterView.Width - PageCode.Width - PageRendu.Width;
                ZonePioche.Height = ScatterCenterView.Height;

                PageCode.Height = ScatterCenterView.Height;
                PageRendu.Height = ScatterCenterView.Height;
                PageRendu.Height = ScatterCenterView.Height;
                PageCode.Height = ScatterCenterView.Height;

                ZonePioche.Width = ScatterCenterView.Width / 10;
                PageCode.Width = (ScatterCenterView.Width - ZonePioche.Width) / 2.0;
                PageRendu.Width = (ScatterCenterView.Width - ZonePioche.Width) / 2.0;
                PageCode.Width = (ScatterCenterView.Width - ZonePioche.Width) / 2.0;
                PageRendu.Width = (ScatterCenterView.Width - ZonePioche.Width) / 2.0;
            }
            if ((CenterView.Orientation == 0 && PageCode.Orientation == 0) || (PageCode.Orientation == 180 && PageCode.Orientation == 0))
            {

                ZonePioche.Height = ScatterCenterView.Height;

                PageCode.Width = ScatterCenterView.Height;
                PageRendu.Width = ScatterCenterView.Height;
                PageRendu.Width = ScatterCenterView.Height;
                PageCode.Width = ScatterCenterView.Height;

                ZonePioche.Width = ScatterCenterView.Width - PageCode.Width - PageRendu.Width;

                PageCode.Height = (ScatterCenterView.Width - ZonePioche.Width) / 2.0;
                PageRendu.Height = (ScatterCenterView.Width - ZonePioche.Width) / 2.0;
                PageCode.Height = (ScatterCenterView.Width - ZonePioche.Width) / 2.0;
                PageRendu.Height = (ScatterCenterView.Width - ZonePioche.Width) / 2.0;
            }

            ZonePioche.Center = new Point(ScatterCenterView.Width / 2.0, ScatterCenterView.Height / 2.0);
            PageCode.Center = new Point(PageCode.Width / 2.0, ScatterCenterView.Height / 2.0);
            PageRendu.Center = new Point(ScatterCenterView.Width - PageRendu.Width / 2.0, ScatterCenterView.Height / 2.0);

            //Zone de pioche/defausse/StepIndicator
            ZonePiocheGrid.Width = ZonePioche.Width;
            ZonePiocheGrid.Height = ZonePioche.Height;
        }

        public void layoutGameStarted()
        {
            //Supprime les zone de joueur inactive
            if (_mdl.getPlayerAt(Player.SUD) == null)
                ZoneJoueurS.Visibility = System.Windows.Visibility.Hidden;
            if (_mdl.getPlayerAt(Player.EST) == null)
                ZoneJoueurE.Visibility = System.Windows.Visibility.Hidden;
            if (_mdl.getPlayerAt(Player.OUEST) == null)
                ZoneJoueurO.Visibility = System.Windows.Visibility.Hidden;
            if (_mdl.getPlayerAt(Player.NORD) == null)
                ZoneJoueurN.Visibility = System.Windows.Visibility.Hidden;

            switch (_mdl.getCurrentPlayer().position())
            {
                case Player.SUD:   ZoneJoueurS.active = true; break;
                case Player.OUEST: ZoneJoueurO.active = true; break;
                case Player.NORD:  ZoneJoueurN.active = true; break;
                case Player.EST:   ZoneJoueurE.active = true; break;
                default: break;
            }

            rotateCenterView(_mdl.getCurrentPlayer().position());
            updateZonesJoueur();
            updateCodeView();
            Sounder.playCurrentPlayerSound();
            SurfaceWindow1.getInstance.indicatorCurrentPlayer(IndicatorMessages.YOUR_TURN);
        }

        public void indicatorAt(string text, Player p)
        {
            switch (p.position())
            {
                case Player.SUD: ZoneJoueurS.showIndicator(text); break;
                case Player.OUEST: ZoneJoueurO.showIndicator(text); break;
                case Player.NORD: ZoneJoueurN.showIndicator(text); break;
                case Player.EST: ZoneJoueurE.showIndicator(text); break;
                default: break;
            }
        }

        public void indicatorCurrentPlayer(string text)
        {
            indicatorAt(text, _mdl.getCurrentPlayer());
        }

        // Update                           ======================================================================================================

        public void updateCodeView()
        {
            PageCode.saveHTML(_mdl.htmlFilePath);
            PageCode.ShowCode();
            PageRendu.update();
        }

        public void updateRotation()
        {
            rotateCenterView(_mdl.getCurrentPlayer().position());
        }

        public void updateStepIndicator()
        {
            StepIndicator.Text = _mdl.getCurrentStep().ToString() + '/' + _mdl.getTotalStep().ToString();
        }

        public void updateZonesJoueur()
        {

            // SUD
            if (_mdl.getPlayerAt(Player.SUD) != null)
            {
                ZoneJoueurS.active = (_mdl.getCurrentPlayer() == _mdl.getPlayerAt(Player.SUD));
                ZoneJoueurS.Visibility = System.Windows.Visibility.Visible;
                ZoneJoueurS.IsEnabled = true;
                ZoneJoueurS.update();
            }
            else
            {
                ZoneJoueurS.active = false;
                ZoneJoueurS.Visibility = System.Windows.Visibility.Hidden;
                ZoneJoueurS.IsEnabled = false;
            }

            // OUEST
            if (_mdl.getPlayerAt(Player.OUEST) != null)
            {
                ZoneJoueurO.active = (_mdl.getCurrentPlayer() == _mdl.getPlayerAt(Player.OUEST));
                ZoneJoueurO.Visibility = System.Windows.Visibility.Visible;
                ZoneJoueurO.IsEnabled = true;
                ZoneJoueurO.update();
            }
            else
            {
                ZoneJoueurO.active = false;
                ZoneJoueurO.Visibility = System.Windows.Visibility.Hidden;
                ZoneJoueurO.IsEnabled = false;
            }

            // NORD
            if (_mdl.getPlayerAt(Player.NORD) != null)
            {
                ZoneJoueurN.active = (_mdl.getCurrentPlayer() == _mdl.getPlayerAt(Player.NORD));
                ZoneJoueurN.Visibility = System.Windows.Visibility.Visible;
                ZoneJoueurN.IsEnabled = true;
                ZoneJoueurN.update();
            }
            else
            {
                ZoneJoueurN.active = false;
                ZoneJoueurN.Visibility = System.Windows.Visibility.Hidden;
                ZoneJoueurN.IsEnabled = false;
            }

            // EST
            if (_mdl.getPlayerAt(Player.EST) != null)
            {
                ZoneJoueurE.active = (_mdl.getCurrentPlayer() == _mdl.getPlayerAt(Player.EST));
                ZoneJoueurE.Visibility = System.Windows.Visibility.Visible;
                ZoneJoueurE.IsEnabled = true;
                ZoneJoueurE.update();
            }
            else
            {
                ZoneJoueurE.active = false;
                ZoneJoueurE.Visibility = System.Windows.Visibility.Hidden;
                ZoneJoueurE.IsEnabled = false;
            }
        }
    }
}