using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Attaques
{
    public class CrashBrowser : AttaqueCarte
    {
        public CrashBrowser() : base() { }

        public override void onValid()
        {
            target.effects().Add(new Effect_classes.CrashBrowser());
        }

        public override void onPlay() { }
        public override void onDelete() { }
    }
}
