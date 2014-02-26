﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Attaques
{
    class CrashBrowser : AttaqueCarte
    {
        public  CrashBrowser()
            : base()
        {
        }

        public override void onValid()
        {
            //Game_classes.Player curplayer = Game_classes.Game.getInstance.getCurPlayer();
            _cible.effects().Add(new Effect_classes.CrashBrowser());
            _cible.updateCarteJoueur();
        }

        public override void onDelete()
        {
            throw new NotImplementedException();
        }
    }
}
