﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Addons
{
    public class BrowserUpdate : AddonCarte
    {
        public BrowserUpdate() : base(){}

        public override void onValid()
        {
            Game_classes.Player curplayer = Game_classes.Game.getInstance.getCurPlayer();
            curplayer.effects().Add(new Effect_classes.BrowserUpdate());
        }

        public override void onPlay() { }
        public override void onDelete() { }
    }
}
