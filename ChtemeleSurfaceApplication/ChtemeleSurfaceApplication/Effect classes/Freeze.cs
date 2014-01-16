using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 
 * Le joueur ciblé passera son prochain tour.
 * 
 * */

// include
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Effect_classes
{
    class Freeze
    {
        public Player player;

        // Constructeur
        public Freeze()
        {
            if (!player.getCanPlayerPlay())
                return;
            player.setCanPlayerPlay(false);
        }
    }
}
