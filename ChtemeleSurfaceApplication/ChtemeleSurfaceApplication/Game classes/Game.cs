using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Game_classes
{
    public class Game
    {
        // Constantes, enumérations         ======================================================================================================

        public static int DEFAULT_HAND_SIZE = 10;
        public static int DEFAULT_NB_STEPS = 10;

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

        private Player _joueurS, _joueurN, _joueurE, _joueurO;       //les 4 joueurs

        private int _nbPlayer;      //Nombre de joueur
        private int _step;       // numéro du tour actuel
        private int _subStep;
        private int _nbSteps;    // nombre de tours de la partie
        private Player _currentPlayer;     // joueur actif
        private bool gameStarted;

        private HtmlPage _page;         // page HTML de la partie

        //Position des navigateurs sur la table
        public Dictionary<int, int> LocationNav;


        // Constructeurs                    ======================================================================================================

        protected Game()
        {
            _joueurS = null;
            _joueurN = null;
            _joueurE = null;
            _joueurO = null;
            _step = 0;
            _subStep = 0;
            _nbSteps = Game.DEFAULT_NB_STEPS;
            _currentPlayer = null;
            gameStarted = false;
            _page = new HtmlPage();
            LocationNav = new Dictionary<int, int>
                {
                    {Player.FIREFOX, Player.OUT},
                    {Player.CHROME, Player.OUT},
                    {Player.IE, Player.OUT},
                    {Player.SAFARI, Player.OUT},
                    {Player.OPERA, Player.OUT}
                };
        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public HtmlPage getPage() { return _page; }
        public bool getGameStarted() { return gameStarted; }
        public Player getCurPlayer() { return _currentPlayer; }
        public int getCurrentStep() { return _step; }
        public int getTotalSteps() { return _nbSteps; }

        public Player playerS { get { return _joueurS; } }
        public Player playerO { get { return _joueurO; } }
        public Player playerN { get { return _joueurN; } }
        public Player playerE { get { return _joueurE; } }

        // Fonctionnalités                  ======================================================================================================

        /// <summary>
        /// Setter du joeur à la position spécifiée.
        /// </summary>
        /// <param name="p">Nouvelle valeur</param>
        /// <param name="position">Player.NORD|SUD|EST|OUEST</param>
        public void setPlayer(Player p, int position)
        {
            switch (position)
            {
                case Player.SUD:   _joueurS = p; break;
                case Player.OUEST: _joueurO = p; break;
                case Player.NORD:  _joueurN = p; break;
                case Player.EST:   _joueurE = p; break;
                default: break;
            }
        }

        /// <summary>
        /// Setter du joeur à la position spécifiée.
        /// </summary>
        /// <param name="p">Nouvelle valeur</param>
        /// <param name="position">Player.NORD|SUD|EST|OUEST</param>
        public Player getPlayer(int position)
        {
            switch (position)
            {
                case Player.SUD: return _joueurS;
                case Player.OUEST: return _joueurO;
                case Player.NORD: return _joueurN;
                case Player.EST: return _joueurE;
                default: return null;
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
            // Step 1 : On choisit le joueur qui commence au hasard.
            Random rand = new Random();

            //      Step 1.1 : On dresse une liste des joueurs disponibles
            List<int> listePos = new List<int>();
            if (_joueurS != null) listePos.Add(Player.SUD);
            if (_joueurO != null) listePos.Add(Player.OUEST);
            if (_joueurN != null) listePos.Add(Player.NORD);
            if (_joueurE != null) listePos.Add(Player.EST);

            //      Step 1.2 : On choisit aléatoirement lequel de ces joueur sera celui qui commence
            int numPlay = rand.Next(0, listePos.Count - 1);
            _currentPlayer = getPlayer(listePos[numPlay]);

            // Step 2 : On dit que le jeu a commencé.
            gameStarted = true;
        }

        /// <summary>
        /// Met dans currentPlayer le jour suivant en suivant le sens horaire.
        /// </summary>
        public void nextPlayer()
        {
            // Step 0 : On incrémente les valeurs des étapes, et on passe la fin 
            _subStep++;
            if (_subStep >= _nbPlayer) _step++;
            _subStep %= _nbPlayer;

            if (_step >= _nbSteps) endGame();


            //      Step 1.1 : On dresse une liste des joueurs disponibles
            int indexCurPlayer = 0;
            bool found = false;
            List<int> listePos = new List<int>();
            if (_joueurS != null){
                listePos.Add(Player.SUD);
                if (_currentPlayer != _joueurS) //c'est le 1ere test, on sait que found = false, forcément, pas besoin de tester.
                    indexCurPlayer++;
                else
                    found = true;
            }
            if (_joueurO != null)
            {
                listePos.Add(Player.OUEST);
                if (_currentPlayer != _joueurO && !found)
                    indexCurPlayer++;
                else
                    found = true;
            }
            if (_joueurN != null)
            {
                listePos.Add(Player.NORD);
                if (_currentPlayer != _joueurN && !found)
                    indexCurPlayer++;
                else
                    found = true;
            }
            if (_joueurE != null)
            {
                listePos.Add(Player.EST);
                if (_currentPlayer != _joueurE && !found)
                    indexCurPlayer++;
                else
                    found = true;
            }

            indexCurPlayer++;
            indexCurPlayer %= _nbPlayer;

            _currentPlayer = getPlayer(listePos[indexCurPlayer]);

            // On a le joueur suivant, on reset sa dernière combo

            _currentPlayer.lastCombo().reset();
        }

        public void endGame()
        {
            // Fin de partie
            gameStarted = false;
        }

        private int Random()
        {
            throw new NotImplementedException();
        }
    }
}
