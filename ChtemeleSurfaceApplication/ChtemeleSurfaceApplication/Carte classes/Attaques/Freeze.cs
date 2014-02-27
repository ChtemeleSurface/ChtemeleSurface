using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Attaques
{
    class Freeze : AttaqueCarte
    {
        public  Freeze()
            : base()
        { 
        }

        public override void onValid()
        {
            //Game_classes.Player curplayer = Game_classes.Game.getInstance.getCurPlayer();
            target.effects().Add(new Effect_classes.Freeze());
            target.updateCarteJoueur();
        }
        public override void onDelete()
        {
            throw new NotImplementedException();
        }
    }
}
