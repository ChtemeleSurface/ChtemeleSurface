using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication
{
    public abstract class AttaqueCarte : EventCarte
    {
        public AttaqueCarte() : base()
        {
        }

        override public void onPlay() { }
        override public void onValid() { }
    }
}
