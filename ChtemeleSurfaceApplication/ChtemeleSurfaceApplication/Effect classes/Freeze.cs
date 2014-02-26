﻿using System;
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
    class Freeze : Effect
    {
        private Player _player;

        // Constructeur
        public Freeze()
            : base()
        {
            _type = EffectType.FREEZE;
        }

    }
}
