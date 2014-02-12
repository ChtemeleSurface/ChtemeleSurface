using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication;

namespace ChtemeleSurfaceApplication.Game_classes
{
    class Player
    {
        // score total du joueur
        private int scoreJoueur;
        // Nombre de carte en main du joueur
        private int nbCarte;
        // Nombre MAXIMAL de carte en main du joueur
        private int MAXnbCarte;
        // Permet au joueur de jouer ou non
        private bool canPlay;
        // Nombre de carte à piocher (par defaut : 10)
        private int nbCardPlayerPioche; // ET OUAIS FRENGLISH !

        public int position; //position du joueur sur l'écran : 1=nord, 2=est, 3=sud, 4=ouest
        public const int OUT = 0;
        public const int NORD = 1;
        public const int EST = 2;
        public const int SUD = 3;
        public const int OUEST = 4;


         //association des tags avec les cartes
        public static Dictionary<string, int> Navigateur = new Dictionary<string, int>
        {
            {"Firefox", 0},
            {"Chrome", 1},
            {"Internet Explorer", 2},
            {"Safari", 3},
            {"Opera", 4}
        };
        
        // Nom joueur
        private string Nom;

        // variable lie play et cartejoueur
        public CartesJoueurs Carte;


        //constructeur
        public Player(int navigateur, CartesJoueurs carteJ)
        {
            Nom = CartesJoueurs.Navigateurs[navigateur];
            Carte = carteJ;

            Carte.PseudoCarte.Text = Nom;
        }



        // SET - GET
        // variable -> scoreJoueur;
        public int getScoreJoueur()
        {
            return scoreJoueur;
        }

        public void setScoreJoueur(int score)
        {
            scoreJoueur = score;
        }

        // SET - GET
        // variable -> nbCarte;
        public int getNbCartesJoueur()
        {
            return nbCarte;
        }

        public void setNbCartesJoueur(int a)
        {
            nbCarte = a;
        }

        // SET - GET
        // variable -> canPlay;
        public bool getCanPlayerPlay()
        {
            return canPlay;
        }

        public void setCanPlayerPlay(bool a)
        {
            canPlay = a;
        }

        // SET - GET
        // variable -> MAXnbCarte;
        public int getPlayerMAxNbCard()
        {
            return MAXnbCarte;
        }

        public void setPlayerMAxNbCard(int a)
        {
            MAXnbCarte = a;
        }

        // SET - GET
        // variable -> MAXnbCarte;
        public int getPlayerCanTake()
        {
            return nbCardPlayerPioche;
        }

        public void setPlayerCanTake(int a)
        {
            nbCardPlayerPioche = a;
        }
    }
}
