using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Game_classes
{
    class Combo
    {
        // Contient le code (HTML) du joueur
        private string[] code;
        // Score du code total
        private int codeScore;

        public enum BonusCombo
        {
            FULLHAND,
            NOERRER,
            LASTTURN
        };




        public int getScoreJoueur()
        {
            return codeScore;
        }

        public void setScoreJoueur(int score)
        {
            codeScore = score;
        }

        //public string getScoreJoueur()
        //{
        //    //return code;
        //}

    }
}
