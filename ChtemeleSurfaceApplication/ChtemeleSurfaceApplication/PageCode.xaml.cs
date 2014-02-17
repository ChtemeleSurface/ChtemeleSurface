using System;

using System.IO;

//using System.Windows.Shapes.Path;

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
//using System.Windows.Shapes;

using ChtemeleSurfaceApplication.HTML_classes;
using ChtemeleSurfaceApplication.Game_classes;
using ChtemeleSurfaceApplication.Modeles;
using Microsoft.Surface.Presentation.Controls;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour PageCode.xaml
    /// </summary>
    public partial class PageCode : ScatterViewItem
    {
        // Constantes, enumérations         ======================================================================================================

        // Variables membres                ======================================================================================================

        private string _text;               // texte html à afficher
        private MdlPageCode _mdl;           // Modèle

        // Constructeurs                    ======================================================================================================

        public PageCode()
        {
            InitializeComponent();

            _mdl = new MdlPageCode();

            // URL du fichier local à lire (ne fonctionne pas avec les URLs distantes)
            //string temp = System.IO.Directory.GetCurrentDirectory();
            //temp = temp + "/Resources/Savegame/game_0.html";
            //string temp = System.IO.Path.GetFullPath("./Resources/Savegame/game_0.html");

            ShowCode();
        }

        // Fonctionnalités                  ======================================================================================================

        // Retourne les lignes récupéré par le set
        public string getTextCode()
        {
            return _text;
        }

        // Lis un fichier et enregistre chaque ligne
        public void setTextCode(string txt)
        {
            _text = txt;
        }

        // Affiche le texte
        public void ShowCode()
        {
            _mdl.renderPage();
            CodeText.Inlines.Add(new Run(_mdl.getCode()));
        }
    }
}
