using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    class MdlGame : Modele
    {
        // Constantes, enumérations         ======================================================================================================

        public const string DEFAULT_HTMLCODE_FILEPATH = "./currentHtml.html";

        // Variables membres                ======================================================================================================

        string _htmlFilePath;                // chemin vers le fichier de sauvegarde du code
        string _gameFilePath;                // chemin vers le fichier de sauvegarde de la partie

        // Constructeurs                    ======================================================================================================

        public MdlGame()
            : base()
        {
            _htmlFilePath = DEFAULT_HTMLCODE_FILEPATH;
        }

        // Accesseurs & Mutateurs

        void setGameFilePath(string s) { _gameFilePath = s; }
        void setHtmlFilePath(string s) { _htmlFilePath = s; }

        // Fonctionnalités                  ======================================================================================================

        public int getCurrentStep() { return _game.getCurrentStep(); }
        public int getTotalStep() { return _game.getTotalSteps(); }
        public void setNbPlayer(int n) { _game.setNbPlayer(n); }

        public bool saveGame()
        {
            return false;
        }

        public bool loadGame()
        {
            return false;
        }

        public void saveHTML()
        {
            MdlRenduHtml mdlRendu = new MdlRenduHtml();
            mdlRendu.renderPage();
            string toSave = mdlRendu.getCode();
            System.IO.StreamWriter file = new System.IO.StreamWriter(_htmlFilePath);
            file.WriteLine(toSave);
            file.Close();
        }

        public string loadHTML()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(_htmlFilePath);
            return file.ReadToEnd();
        }

    }
}
