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
        private bool gameStarted;

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
            gameStarted = false;
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
        public bool getGameStarted() { return gameStarted; }
        public Player getCurPlayer() { return _currentPlayer; }

        // Fonctionnalités                  ======================================================================================================

        public void nextPlayer()
        {
            SurfaceWindow1.getInstance.ZoneJoueurE.active = false;
            SurfaceWindow1.getInstance.ZoneJoueurN.active = false;
            SurfaceWindow1.getInstance.ZoneJoueurO.active = false;
            SurfaceWindow1.getInstance.ZoneJoueurS.active = false;

            bool pass = false;
            int curPos = _currentPlayer.position();
            while(pass == false)
                switch (curPos)
                {
                case 1:
                        if (joueurE == null)
                            curPos++;
                        else
                        {
                            _currentPlayer = joueurE;
                            SurfaceWindow1.getInstance.ZoneJoueurE.active = true;
                            SurfaceWindow1.getInstance.rotateCenterView(270);
                            pass = true;
                        }
                    break;
                case 2:
                    if (joueurS == null)
                        curPos++;
                    else
                    {
                        _currentPlayer = joueurS;
                        SurfaceWindow1.getInstance.ZoneJoueurS.active = true;
                        SurfaceWindow1.getInstance.rotateCenterView(0);
                        pass = true;
                    }
                    break;
                case 3:
                    if (joueurO == null)
                        curPos++;
                    else
                    {
                        _currentPlayer = joueurO;
                        SurfaceWindow1.getInstance.ZoneJoueurO.active = true;
                        SurfaceWindow1.getInstance.rotateCenterView(90);
                        pass = true;
                    }
                    break;
                case 4:
                    if (joueurN == null)
                        curPos = 1;
                    else
                    {
                        _currentPlayer = joueurN;
                        SurfaceWindow1.getInstance.ZoneJoueurN.active = true;
                        SurfaceWindow1.getInstance.rotateCenterView(180);
                        pass = true;
                    }
                    break;
                }



            SurfaceWindow1.getInstance.updateZonesJoueur();
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
                SurfaceWindow1.getInstance.ZoneJoueurS.Visibility = System.Windows.Visibility.Hidden;
            if (joueurE == null)
                SurfaceWindow1.getInstance.ZoneJoueurE.Visibility = System.Windows.Visibility.Hidden;
            if (joueurO == null)
                SurfaceWindow1.getInstance.ZoneJoueurO.Visibility = System.Windows.Visibility.Hidden;
            if (joueurN == null)
                SurfaceWindow1.getInstance.ZoneJoueurN.Visibility = System.Windows.Visibility.Hidden;

            //initialise la parti avec un joueur aléatoire
            Random rnd = new Random();
            bool ok = false;
            while (ok == false)
            {
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        if (joueurS != null)
                        {
                            _currentPlayer = joueurS;
                            SurfaceWindow1.getInstance.rotateCenterView(0);
                            ok = true;
                            SurfaceWindow1.getInstance.ZoneJoueurS.active = true;
                        }
                        break;
                    case 2:
                        if (joueurO != null)
                        {
                            _currentPlayer = joueurO;
                            SurfaceWindow1.getInstance.rotateCenterView(90);
                            ok = true;
                            SurfaceWindow1.getInstance.ZoneJoueurO.active = true;
                        }
                        break;
                    case 3:
                        if (joueurN != null)
                        {
                            _currentPlayer = joueurN;
                            SurfaceWindow1.getInstance.rotateCenterView(180);
                            ok = true;
                            SurfaceWindow1.getInstance.ZoneJoueurN.active = true;
                        }
                        break;
                    case 4:
                        if (joueurE != null)
                        {
                            _currentPlayer = joueurE;
                            SurfaceWindow1.getInstance.rotateCenterView(270);
                            ok = true;
                            SurfaceWindow1.getInstance.ZoneJoueurE.active = true;
                        }
                        break;
                }
                SurfaceWindow1.getInstance.updateZonesJoueur();
            }
            gameStarted = true;
        }

        private int Random()
        {
            throw new NotImplementedException();
        }
    }
}
