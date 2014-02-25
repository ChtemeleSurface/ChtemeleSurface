using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 
 * Au prochain tour vous piocherez jusqu’à avoir 2 cartes de plus. (12 au lieu de 10, 8 au lieu de 10.)
 * 
 * */

// include
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Effect_classes
{
    class BrowserUpdate : Effect
    {
        public Player player;

        // Constructeur
        public BrowserUpdate()
            : base()
        {
            _type = EffectType.BROWSERUPDATE;
        }
    }
}
