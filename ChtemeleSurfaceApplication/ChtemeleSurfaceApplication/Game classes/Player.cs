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
        public  int handSize;               //taille max de la main du joueur;
        public  int nbCards;                //nombre de cartes en main.
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
            handSize = Game.DEFAULT_HAND_SIZE;
            nbCards = handSize;
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

        /*/// <summary>
        /// Sauvegarde l'état du joueur
        /// </summary>
        public void save()
        {
            _save = this.clone();
        }

        /// <summary>
        /// Restaure le joueur tel qu'il a été sauvegardé.
        /// </summary>
        public void restore()
        {

        }

        /// <summary>
        /// Clone le joueur en mémoire et renvoie la copie
        /// </summary>
        /// <returns></returns>
        public Player clone()
        {
            Player ret = new Player(this.name, this._position, this._browser);
            ret._lastCombo = new Combo(this._lastCombo);
            ret._effects = new List<Effect>();
            this._effects.CopyTo(ret._effects.ToArray());


            return ret;
        }*/
    }
}
