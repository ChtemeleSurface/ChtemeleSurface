using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Game_classes
{
    class Game
    {
        // Constantes, enumérations         ======================================================================================================

        public static int defaultHandSize = 10;
        public static int defaultNbSteps = 10;

        //Singleton
        private static Game instance = null;
        public static Game getInstance{
            get{
                if (instance == null)
                    instance = new Game();
                return instance;
            }
        }

        // Variables membres                ======================================================================================================

        public  Player joueurS, joueurN, joueurE, joueurO;       //les 4 joueurs

        private int _step;       // numéro du tour actuel
        private int _nbSteps;    // nombre de tours de la partie
        private Player _currentPlayer;     // joueur actif

        private HtmlPage _page;         // page HTML de la partie

        //Position des navigateurs sur la table
        public Dictionary<int, int> LocationNav;


        // Constructeurs                    ======================================================================================================

        protected Game()
        {
            joueurS = null;
            joueurN = null;
            joueurE = null;
            joueurO = null;
            _step = 0;
            _nbSteps = Game.defaultNbSteps;
            _currentPlayer = null;
            _page = new HtmlPage();
            LocationNav = new Dictionary<int, int>
                {
                    {Player.FIREFOX, 0},
                    {Player.CHROME, 0},
                    {Player.IE, 0},
                    {Player.SAFARI, 0},
                    {Player.OPERA, 0}
                };
        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public HtmlPage getPage() { return _page; }

        // Fonctionnalités                  ======================================================================================================

        // Retourne le code à interpréter dans le nativateur de rendu
        public string getRawHTML()
        {
            string ret = _page.renderHTML();
            return ret;
        }

        // Retourne le code à afficher dans l'éditeur de code
        public string getFormatedHTML()
        {
            string ret = _page.renderHTML();
            return ret;
        }

    }
}
