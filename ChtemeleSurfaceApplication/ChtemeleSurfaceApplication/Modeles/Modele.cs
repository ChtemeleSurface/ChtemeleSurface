using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    class Modele
    {
        protected Game _game;

        public Modele()
        {
            _game = Game.getInstance;
        }
    }
}