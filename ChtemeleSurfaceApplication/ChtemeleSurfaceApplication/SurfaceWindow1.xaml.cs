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

            /*ScatterViewItem clavier = new ScatterViewItem();
            clavier.Content = new Clavier();
            this.clavier.Content = clavier;*/

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

            //Mise en page 
        }
    }
}