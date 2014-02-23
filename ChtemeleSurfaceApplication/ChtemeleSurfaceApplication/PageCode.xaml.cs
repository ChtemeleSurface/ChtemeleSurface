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

        /*private Dictionary<StrTypePair.StrType, Color> colorTable = new Dictionary<StrTypePair.StrType, Color>
        {
            {StrTypePair.StrType.DOCTYPE, Colors.BlueViolet},

            {StrTypePair.StrType.USR_TAG, Color.FromRgb(0, 0, 127)},
            {StrTypePair.StrType.USR_TAG_ATTR_NAME, Color.FromRgb(255, 0, 0)},
            {StrTypePair.StrType.USR_TAG_ATTR_AFFECT, Color.FromRgb(0, 0, 0)},
            {StrTypePair.StrType.USR_TAG_ATTR_VALUE, Color.FromRgb(128, 0, 255)},
            {StrTypePair.StrType.USR_TEXT, Color.FromRgb(0, 0, 0)},

            {StrTypePair.StrType.USR_TAG, Color.FromRgb(127, 127, 255)},
            {StrTypePair.StrType.USR_TAG_ATTR_NAME, Color.FromRgb(255, 127, 127)},
            {StrTypePair.StrType.USR_TAG_ATTR_AFFECT, Color.FromRgb(127, 127, 127)},
            {StrTypePair.StrType.USR_TAG_ATTR_VALUE, Color.FromRgb(180, 127, 255)},
            {StrTypePair.StrType.USR_TEXT, Color.FromRgb(127, 127, 127)},

            {StrTypePair.StrType.COMMENT, Color.FromRgb(0, 127, 0)},
            {StrTypePair.StrType.LINE_BREAK, Color.FromRgb(0, 0, 0)}
        };*/

        private Dictionary<StrTypePair.StrType, Color> colorTable = new Dictionary<StrTypePair.StrType, Color>
        {
            {StrTypePair.StrType.DOCTYPE, Colors.SaddleBrown},

            {StrTypePair.StrType.USR_TAG, Colors.Blue},
            {StrTypePair.StrType.USR_OPEN_TAG, Colors.Blue},
            {StrTypePair.StrType.USR_END_TAG, Colors.Blue},
            {StrTypePair.StrType.USR_TAG_NAME, Colors.Blue},
            {StrTypePair.StrType.USR_TAG_ATTR_NAME, Colors.Red},
            {StrTypePair.StrType.USR_TAG_ATTR_AFFECT, Colors.Black },
            {StrTypePair.StrType.USR_TAG_ATTR_VALUE, Colors.Purple},
            {StrTypePair.StrType.USR_TEXT, Colors.Black},

            {StrTypePair.StrType.AUTO_TAG, Colors.LightBlue},
            {StrTypePair.StrType.AUTO_OPEN_TAG, Colors.LightBlue},
            {StrTypePair.StrType.AUTO_END_TAG, Colors.LightBlue},
            {StrTypePair.StrType.AUTO_TAG_NAME, Colors.LightBlue},
            {StrTypePair.StrType.AUTO_TAG_ATTR_NAME, Colors.Pink},
            {StrTypePair.StrType.AUTO_TAG_ATTR_AFFECT, Colors.Gray},
            {StrTypePair.StrType.AUTO_TAG_ATTR_VALUE, Colors.LightPink},
            {StrTypePair.StrType.AUTO_TEXT, Colors.Gray},

            {StrTypePair.StrType.COMMENT, Colors.Green},
            {StrTypePair.StrType.LINE_BREAK, Colors.Black}
        };

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

            Width = ScatterCodeText.Width;
            Height = ScatterCodeText.Height;
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
            CodeText.Inlines.Clear();
            foreach (StrTypePair pair in _mdl.getCode())
            {
                Run txt = new Run(pair.str);
                txt.Foreground = new SolidColorBrush(colorTable[pair.type]);
                CodeText.Inlines.Add(txt);
            }
            //CodeText.Inlines.Add(new Run(_mdl.getCode()));
        }
    }
}
