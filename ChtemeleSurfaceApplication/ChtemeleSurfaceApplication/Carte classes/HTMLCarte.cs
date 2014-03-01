using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;


namespace ChtemeleSurfaceApplication
{
    abstract class HTMLCarte : Carte
    {
        protected int _score;

        public HTMLCarte(int s)
            : base()
        {
            _score = s;
        }

        public string textcontent = "";

        override public abstract void onPlay();
        override public abstract void onValid();
    }
}
