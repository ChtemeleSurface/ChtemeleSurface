using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
