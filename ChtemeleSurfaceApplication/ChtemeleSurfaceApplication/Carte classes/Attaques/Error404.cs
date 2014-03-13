using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Attaques
{
    public class Error404 : AttaqueCarte
    {
        public Error404() : base() { }

        public override void onValid()
        {
            target.addPoint(-target.lastCombo().score);
        }

        public override void onPlay() { }
        public override void onDelete() { }
    }
}
