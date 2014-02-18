using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication;

namespace ChtemeleSurfaceApplication.Game_classes
{
    class Player
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
        public  int handSize;               //taille max de la main du joueur;
        public  int nbCards;                //nombre de cartes en main.
        private List<Effect> _effects;      //Effets actifs sur le joueur
        private int _position;              //position du joueur (voir enumeration)

        // Constructeurs                    ======================================================================================================

        // Paramètres : n nom du joueur
        //              p position du joueur
        public Player(string n, int p)
        {
            name = n;
            score = 0;
            _lastCombo = new Combo();
            handSize = Game.defaultHandSize;
            nbCards = handSize;
            _effects = new List<Effect>();
            _position = p;
        }



        // Accesseurs / Mutateurs           ======================================================================================================

        public Combo lastCombo(){ return _lastCombo;}
        public List<Effect> effects() { return _effects; }
        public int position() { return _position; }




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
    }
}
