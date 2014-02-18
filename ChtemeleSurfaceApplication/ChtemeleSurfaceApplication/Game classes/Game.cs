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

        private int _nbPlayer;      //Nombre de joueur
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

        public void nextPlayer()
        {
            switch(_currentPlayer.position())
            {
                case 1:
                    SurfaceWindow1.getInstance.rotateCenterView(270);
                    _currentPlayer = joueurE;
                    if (joueurE == null)
                        nextPlayer();
                    break;
                case 2:
                    SurfaceWindow1.getInstance.rotateCenterView(0);
                    _currentPlayer = joueurS;
                    if (joueurS == null)
                        nextPlayer();
                    break;
                case 3:
                    SurfaceWindow1.getInstance.rotateCenterView(90);
                    _currentPlayer = joueurO;
                    if (joueurO == null)
                        nextPlayer();
                    break;
                case 4:
                    SurfaceWindow1.getInstance.rotateCenterView(180);
                    _currentPlayer = joueurN;
                    if (joueurN == null)
                        nextPlayer();
                    break;
            }
        }

        public void setNbPlayer(int nbPlayer)
        {
            _nbPlayer = nbPlayer;
        }

        public int getNbPlayer()
        {
            return _nbPlayer;
        }

        public void initGame()
        {
            //Supprime les zone de joueur inactive
            if(joueurS == null)
                SurfaceWindow1.getInstance.PlayerSScatterView.Visibility = System.Windows.Visibility.Hidden;
            if (joueurE == null)
                SurfaceWindow1.getInstance.PlayerEScatterView.Visibility = System.Windows.Visibility.Hidden;
            if (joueurO == null)
                SurfaceWindow1.getInstance.PlayerOScatterView.Visibility = System.Windows.Visibility.Hidden;
            if (joueurN == null)
                SurfaceWindow1.getInstance.PlayerNScatterView.Visibility = System.Windows.Visibility.Hidden;

            //initialise la parti
            if (joueurS != null)
                _currentPlayer = joueurS;
            else if (joueurO != null)
                _currentPlayer = joueurO;
            else
                _currentPlayer = joueurN;       //On ne va pas plus loin, la parti est de minimum 2 joueurs
        }
    }
}
