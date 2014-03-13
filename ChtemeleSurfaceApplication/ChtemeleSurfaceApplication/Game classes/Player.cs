using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication;

namespace ChtemeleSurfaceApplication.Game_classes
{
    public class Player
    {
        // Constantes, enumérations         ======================================================================================================

        //Position du joueur sur la table de jeu
        public const int OUT = 0;
        public const int NORD = 1;
        public const int EST = 2;
        public const int SUD = 3;
        public const int OUEST = 4;

        // Noms des navigateurs
        public const int FIREFOX = 0;
        public const int CHROME = 1;
        public const int IE = 2;
        public const int SAFARI = 3;
        public const int OPERA = 4;
        public static Dictionary<int, string> browserNames = new Dictionary<int, string>
            {
                {0, "Firefox"},
                {1, "Chrome"},
                {2, "Internet Explorer"},
                {3, "Safari"},
                {4, "Opera"}
            };



        // Variables membres                ======================================================================================================

        public  string name;                //Nom du joueur
        public  int score;                  //score total accumulé
        private Combo _lastCombo;           //Dernière combinaison effectuée
        private  int _handSize;               //taille max de la main du joueur;
        private  int _nbCards;                //nombre de cartes en main.
        private List<Effect> _effects;      //Effets actifs sur le joueur
        private int _position;              //position du joueur (voir enumeration)
        private int _browser;               //navigateur
        private Player _save;               // Sauvegarde de l'état du joueur

        // Constructeurs                    ======================================================================================================

        // Paramètres : n nom du joueur
        //              p position du joueur
        public Player(string n, int p, int b)
        {
            name = n;
            score = 0;
            _lastCombo = new Combo();
            _handSize = Game.DEFAULT_HAND_SIZE;
            _nbCards = _handSize;
            _effects = new List<Effect>();
            _position = p;
            _browser = b;
            _save = null;
        }



        // Accesseurs / Mutateurs           ======================================================================================================

        public Combo lastCombo(){ return _lastCombo;}
        public List<Effect> effects() { return _effects; }
        public int position() { return _position; }
        public int browser { get { return _browser; } }
        public int handSize { get { return _handSize; } }
        public int nbCards { get { return _nbCards; } set { _nbCards = value; } }

        // Fonctionnalités                  ======================================================================================================

        // charge les données du joueur depuis une chaine de texte.
        public void loadData()
        {

        }

        // retourne les données du joueur sous forme de chaine de texte
        public string getSaveData()
        {
            string ret = "";

            return ret;
        }

        public void addPoint(int scoreAdd)
        {
            score += scoreAdd;
        }

        public void applyEffects()
        {
            // aucun effet n'a de sens sur le jeu. Cette focntion se contente de vider la liste des effets.
            _effects.Clear();
        }

        public bool isFrozen()
        {
            foreach (Effect effect in _effects)
            {
                if (effect is Effect_classes.Freeze) return true;
            }
            return false;
        }
    }
}
