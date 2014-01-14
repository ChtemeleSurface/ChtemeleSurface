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
    /// Logique d'interaction pour PageCode.xaml
    /// </summary>
    public partial class PageCode : ScatterViewItem
    {
        private string[] lines;

        // Constructeur
        public PageCode()
        {
            InitializeComponent();

            // URL du fichier local à lire (ne fonctionne pas avec les URLs distantes)
            setTextCode("C:/Program Files (x86)/Common Files/Java/Java Update/task.xml");
            // affiche le code dans la zone prévu
            ShowCode();
        }

        // Retourne les lignes récupéré par le set
        public string[] getTextCode()
        {
            return lines;
        }

        // Lis un fichier et enregistre chaque ligne
        public void setTextCode(string fileUrl)
        {
            lines = System.IO.File.ReadAllLines(@fileUrl); //@+fileUrl
        }

        // Lis chaque ligne du tableau et envoie chaque ligne dans un Inline
        // Gestion de l'indentation et coloration syntaxique non-géré
        public void ShowCode()
        {
            for (int i = 0; i < lines.Length; i++)
                CodeText.Inlines.Add(new Run(lines[i]));
        }


    }
}
