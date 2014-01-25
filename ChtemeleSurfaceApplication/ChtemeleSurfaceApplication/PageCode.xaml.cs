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
using Microsoft.Surface.Presentation.Controls;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour PageCode.xaml
    /// </summary>
    public partial class PageCode : ScatterViewItem
    {
        private string _text;


        // Constructeur
        public PageCode()
        {
            InitializeComponent();

            _text = Game.getInstance._page.renderHTML();

            // URL du fichier local à lire (ne fonctionne pas avec les URLs distantes)
            //string temp = System.IO.Directory.GetCurrentDirectory();
            //temp = temp + "/Resources/Savegame/game_0.html";
            //string temp = System.IO.Path.GetFullPath("./Resources/Savegame/game_0.html");

            setTextCode(_text);
            ShowCode();
        }

        // Retourne les lignes récupéré par le set
        public string getTextCode()
        {
            return _text;
        }

        // Lis un fichier et enregistre chaque ligne
        public void setTextCode(string txt)
        {

            //_text = System.IO.File.ReadAllText(@fileUrl); //@+fileUrl
            _text = txt;
        }

        // Lis chaque ligne du tableau et envoie chaque ligne dans un Inline
        // Gestion de l'indentation et coloration syntaxique non-géré
        public void ShowCode()
        {
            //CodeText.Inlines.Add(new Run(lines[i]));
            CodeText.Inlines.Add(new Run(_text));
        }
    }
}
