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

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

           /* //Clavier Sud
            ScatterViewItem clav = new ScatterViewItem();
            clav.Content = new Clavier();
            clav.Width = 400;
            clav.Height = 130;
            clav.Center = new System.Windows.Point(clav.Width/2, clav.Height/2);
            clav.Orientation = 0;
            clav.CanMove = false;
            clav.CanRotate = false;
            clav.CanScale = false;
            this.scatterSud.Items.Add(clav);*/

            // CarteNord
            ScatterViewItem CarteJoueurN = new ScatterViewItem();
            CarteJoueurN.Content = new CartesJoueurs();
            CarteJoueurN.Width = CartesJoueurs.tailleW;
            CarteJoueurN.Height = CartesJoueurs.tailleH;

            // CarteSud
            ScatterViewItem CarteJoueurS = new ScatterViewItem();
            CarteJoueurS.Content = new CartesJoueurs();
            CarteJoueurS.Width = CartesJoueurs.tailleW;
            CarteJoueurS.Height = CartesJoueurs.tailleH;

            // CarteEst
            ScatterViewItem CarteJoueurE = new ScatterViewItem();
            CarteJoueurE.Content = new CartesJoueurs();
            CarteJoueurE.Width = CartesJoueurs.tailleW;
            CarteJoueurE.Height = CartesJoueurs.tailleH;

            // CarteOuest
            ScatterViewItem CarteJoueurO = new ScatterViewItem();
            CarteJoueurO.Content = new CartesJoueurs();
            CarteJoueurO.Width = CartesJoueurs.tailleW;
            CarteJoueurO.Height = CartesJoueurs.tailleH;

            //Initialisation positions zone Nord
            DocNord.Center = new Point(PlayerNScatterView.Width / 4, PlayerNScatterView.Height / 2);
            ClavierNord.Center = new Point(PlayerNScatterView.Width / 2, PlayerNScatterView.Height / 2);
            CarteNord.Center = new Point((PlayerNScatterView.Width / 2) + (PlayerNScatterView.Width / 4), PlayerNScatterView.Height / 2);

            //Initialisation positions zone Sud
            DocSud.Center = new Point(PlayerSScatterView.Width / 4, PlayerSScatterView.Height / 2);
            ClavierSud.Center = new Point(PlayerSScatterView.Width / 2, PlayerSScatterView.Height / 2);
            CarteSud.Center = new Point((PlayerSScatterView.Width / 2) + (PlayerSScatterView.Width / 4), PlayerSScatterView.Height / 2);

            //Initialisation positions zone Est
            DocEst.Center = new Point(PlayerEScatterView.Width / 4, PlayerEScatterView.Height / 2);
            ClavierEst.Center = new Point(PlayerEScatterView.Width / 2, PlayerEScatterView.Height / 2);
            CarteEst.Center = new Point((PlayerEScatterView.Width / 2) + (PlayerEScatterView.Width / 4), PlayerEScatterView.Height / 2);

            //Initialisation positions zone Ouest
            DocOuest.Center = new Point(PlayerOScatterView.Width / 4, PlayerOScatterView.Height / 2);
            ClavierOuest.Center = new Point(PlayerOScatterView.Width / 2, PlayerOScatterView.Height / 2);
            CarteOuest.Center = new Point((PlayerOScatterView.Width / 2) + (PlayerOScatterView.Width / 4), PlayerOScatterView.Height / 2);

            //Position Widgets Centeriew



            //Page de code balise carte



            //Page rendu HTML




            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();

            ComputeWidgetsPositions(MainScatterView.Width, MainScatterView.Height);
        }

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
        /// Re-dessine la fenêtre, repositionne les éléments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainScatterView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ComputeWidgetsPositions(e.NewSize.Width, e.NewSize.Height);
        }


        private void ComputeWidgetsPositions(double x, double y)
        {
            //Position des zones joueurs
            PlayerSScatterView.Center = new Point(x / 2, y - (PlayerSScatterView.Height / 2));
            PlayerOScatterView.Center = new Point(PlayerOScatterView.Height / 2, y / 2);
            PlayerNScatterView.Center = new Point(x / 2, PlayerSScatterView.Height / 2);
            PlayerEScatterView.Center = new Point(x - PlayerOScatterView.Height / 2, y/2);

            //taille et position du centralview
            CenterView.Height = y - PlayerSScatterView.Height - PlayerNScatterView.Height;
            CenterView.Width = x - PlayerOScatterView.Height - PlayerEScatterView.Height;
            CenterView.Center = new Point(x / 2, y / 2);

            
        }
    }
}