using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;


namespace ChtemeleSurfaceApplication
{
    public abstract class HTMLCarte : Carte
    {
        // Constantes, enumérations         ======================================================================================================



        // Variables membres                ======================================================================================================

        protected int _score;                   // Score qu'occtroie la carte
        protected string _textcontent = "";     // Texte qu'on a inscrit dans la carte

        // Constructeurs                    ======================================================================================================

        public HTMLCarte(int s)
            : base()
        {
            _score = s;
        }

        // Accesseurs & Mutateurs           ======================================================================================================

        public int score { get { return _score; } }
        public string textcontent { get { return _textcontent; } set { _textcontent = value; } }

        // Fonctionnalités                  ======================================================================================================

        override public abstract void onPlay();
        override public abstract void onValid();
    }
}
