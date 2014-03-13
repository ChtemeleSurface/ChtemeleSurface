using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Attaques
{
    public class Freeze : AttaqueCarte
    {
        public Freeze() : base() { }

        public override void onValid()
        {
            target.effects().Add(new Effect_classes.Freeze());
        }

        public override void onPlay() { }
        public override void onDelete() { }
    }
}
