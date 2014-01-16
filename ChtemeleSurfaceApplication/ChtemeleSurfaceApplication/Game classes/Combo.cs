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
        // Dernier combo du joueur (code total joué)
        private string[] lastCombo;
        // Nb de carte que le joueur a joué
        private int nbCarte;


        // SET - GET
        // variable -> codeScore;
        public int getScoreJoueur()
        {
            return codeScore;
        }

        public void setScoreJoueur(int a)
        {
            codeScore = a;
        }

        // SET - GET
        // variable -> []code;
        public string[] getCodeJoueur()
        {
            return code;
        }

        public void setCodeJoueur(string[] a)
        {
            code = a;
        }

        // SET - GET
        // variable -> []lastCombo;
        public string[] getComboJoueur()
        {
            return lastCombo;
        }

        public void setComboJoueur(string[] a)
        {
            lastCombo = a;
        }

        // SET - GET
        // variable -> nbCarte;
        public int getComboJoueur()
        {
            return nbCarte;
        }

        public void setComboJoueur(int a)
        {
            nbCarte = a;
        }
    }
}
