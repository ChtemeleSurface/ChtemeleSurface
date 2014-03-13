using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication
{
    public abstract class AddonCarte : EventCarte
    {
        public AddonCarte() : base() { }

        override public void onPlay() { }
        override public void onValid() { }
        override public void onDelete() { }
    }
}
