using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication
{
    abstract class AttaqueCarte : EventCarte
    {
        protected Game_classes.Player _cible;
        Game_classes.Player getCible() { return _cible;}

        public AttaqueCarte()
        {
            //_cible = getCible();
        }

        override public void onPlay() { }
        override public void onValid() { }
    }
}
