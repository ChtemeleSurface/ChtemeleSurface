using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    public class MdlGame : Modele
    {
        // Constantes, enumérations         ======================================================================================================

        public const string DEFAULT_HTMLCODE_FILEPATH = "./currentHtml.html";

        // Variables membres                ======================================================================================================

        //Modèles fils
        MdlCarteJoueur _mCarteS, _mCarteO, _mCarteN, _mCarteE;
        MdlPageCode _mPageCode;
        MdlRenduHtml _mPageRendu;
        //MdlTag _mTag;
        //Dictionary<int, MdlTag> _mTags = new Dictionary<int, MdlTag>();


        //Membres
        string _htmlFilePath;                // chemin vers le fichier de sauvegarde du code
        string _gameFilePath;                // chemin vers le fichier de sauvegarde de la partie

        // Constructeurs                    ======================================================================================================

        public MdlGame()
            : base()
        {
            _mCarteS = new MdlCarteJoueur(_game.playerS);
            _mCarteO = new MdlCarteJoueur(_game.playerO);
            _mCarteN = new MdlCarteJoueur(_game.playerN);
            _mCarteE = new MdlCarteJoueur(_game.playerE);
            _mPageCode = new MdlPageCode();
            _mPageRendu = new MdlRenduHtml();


            _htmlFilePath = DEFAULT_HTMLCODE_FILEPATH;
        }

        // Accesseurs & Mutateurs           ======================================================================================================

        public MdlCarteJoueur mCarteS { get { return _mCarteS; } }
        public MdlCarteJoueur mCarteO { get { return _mCarteO; } }
        public MdlCarteJoueur mCarteN { get { return _mCarteN; } }
        public MdlCarteJoueur mCarteE { get { return _mCarteE; } }
        public MdlPageCode mPageCode { get { return _mPageCode; } }
        public MdlRenduHtml mPageRendu { get { return _mPageRendu; } }

        public string htmlFilePath { get { return _htmlFilePath; } set { _htmlFilePath = value; } }

        void setGameFilePath(string s) { _gameFilePath = s; }
        //void setHtmlFilePath(string s) { _htmlFilePath = s; }

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

        /// <summary>
        /// Retourne à quelle position est située le navigateur passé en paramètre
        /// </summary>
        /// <param name="nav">L'id du navigateur à trouver (Player.__constante__)</param>
        /// <returns>Player.NORD|SUD|EST|OUEST ou Player.OUT si le navigateur n'est pas en jeu.</returns>
        public int getBrowserPosition(int nav){
            if (_game.LocationNav.ContainsKey(nav))
                return _game.LocationNav[nav];
            else
                return Player.OUT;
        }

        public void setBrowserPosition(int nav, int pos)
        {
            _game.LocationNav[nav] = pos;
        }

        public void newPlayer(Player p)
        {
            if (getPlayerAt(p.position()) == null)
            {
                _game.setPlayer(p, p.position());
                switch (p.position())
                {
                    case Player.SUD: _mCarteS = new MdlCarteJoueur(p); break;
                    case Player.OUEST: _mCarteO = new MdlCarteJoueur(p); break;
                    case Player.NORD: _mCarteN = new MdlCarteJoueur(p); break;
                    case Player.EST: _mCarteE = new MdlCarteJoueur(p); break;
                    default: break;
                }
            }
        }

        public Player getPlayerAt(int pos)
        {
            switch (pos)
            {
                case Player.SUD: return _game.playerS;
                case Player.OUEST: return _game.playerO;
                case Player.NORD: return _game.playerN;
                case Player.EST: return _game.playerE;
                default: return null;
            }
        }

        public void initGame()
        {
            _game.initGame();
        }

        /// <summary>
        /// Termine le tour du joueur actuel
        /// </summary>
        public void nextSubStep()
        {
            _game.nextPlayer();
        }

        public Player getCurrentPlayer()
        {
            return _game.getCurPlayer();
        }



    }
}
