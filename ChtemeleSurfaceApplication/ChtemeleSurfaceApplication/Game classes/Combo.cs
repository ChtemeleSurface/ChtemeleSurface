using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Game_classes
{
    public class Combo
    {
        // Constantes, enumérations         ======================================================================================================

        public enum BonusCombo
        {
            FULLHAND,
            NOERROR,
            LASTTURN
        }

        // Variables membres                ======================================================================================================

        private string code;                // code de la combinaison
        private int codeScore;              // Score généré par la combinaison
        private int nbCarte;                // Nombre de cartes de la combinaison

        // Constructeurs                    ======================================================================================================

        public Combo()
        {
            code = "";
            codeScore = 0;
            nbCarte = 0;
        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public int getScore() { return codeScore; }
        public void setScoreJoueur(int a) { codeScore = a; }

        public string getCodeJoueur() { return code; }
        public void setCodeJoueur(string a) { code = a; }

        public int getNbCarte() { return nbCarte; }
        public void setComboJoueur(int a) { nbCarte = a; }

        // Fonctionnalités                  ======================================================================================================
    }
}
