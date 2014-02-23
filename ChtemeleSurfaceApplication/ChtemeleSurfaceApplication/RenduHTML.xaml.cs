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

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour RenduHTML.xaml
    /// </summary>
    public partial class RenduHTML : ScatterViewItem
    {
        // Variable contenant l'URL ou URI du fichier
        private string fileURL;

        // Constructeur
        public RenduHTML()
        {
            InitializeComponent();

            fileURL = System.IO.Directory.GetCurrentDirectory();
            fileURL = fileURL + "/Resources/Savegame/game_0.html";
            //fileURL = System.IO.Path.GetFullPath("./Resources/Savegame/game_0.html");


            WebRenderer();
        }


        // GET & SET
        public string getFileUrl()
        {
            return fileURL;
        }
        public void setFileUrl(string fileUrl)
        {
            fileURL = fileUrl;
        }

        // Initialise la source de la page à afficher
        private void WebRenderer()
        {
            webControl.Source = new Uri(getFileUrl());
        }

        // Appliquer un style CSS
        private void applyCss1(object sender, RoutedEventArgs e)
        {
            changeStyleSheet(1);
        }
        private void applyCss2(object sender, RoutedEventArgs e)
        {
            changeStyleSheet(2);
        }
        private void applyCss3(object sender, RoutedEventArgs e)
        {
            changeStyleSheet(3);
        }

        // Fonction modifiant la page web fichier local ( et ou ram ? )
        // Regroupe le traitement dans une seule fonction
        public void changeStyleSheet(int a)
        {
            // lire  la ligne X
            string ligne = "a";

            // conversion string -> int
            int version = 1;    // defaut
            try
            {
                version = Convert.ToInt32(ligne);
            }
            catch(Exception ex)
            {
                // affichage de l'erreur
            }

            // si le CSS désiré est déjà celui appliqué
            if (a == version)
                return;

            // changement du nom
            string css = "styleCss";
            switch (a)
            {
                case 1 :
                css = css + "1.css";
                break;
                case 2:
                css = css + "2.css";
                break;
                case 3:
                css = css + "3.css";
                break;
            }
        }

    }
}
