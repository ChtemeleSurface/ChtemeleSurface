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

        private string _code;                // code de la combinaison
        private int _codeScore;              // Score généré par la combinaison
        private int _nbCards;                // Nombre de cartes de la combinaison

        // Constructeurs                    ======================================================================================================

        public Combo()
        {
            _code = "";
            _codeScore = 0;
            _nbCards = 0;
        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public string code { get { return _code; } }
        public int score { get { return _codeScore; } }
        public int nbCards { get { return _nbCards; } }

        // Fonctionnalités                  ======================================================================================================

        public void addCard(HTMLCarte c)
        {
            _nbCards++;
            _codeScore += c.score;
            // TODO : trouver comment récupréer le code
        }

        public void reset()
        {
            _code = "";
            _codeScore = 0;
            _nbCards = 0;
        }
    }
}
