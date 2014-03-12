using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication
{
    public abstract class EventCarte : Carte
    {
        public EventCarte() : base() { }

        override public abstract void onPlay();
        override public abstract void onValid();
        override public abstract void onDelete();
        public Player target;

    }
}
