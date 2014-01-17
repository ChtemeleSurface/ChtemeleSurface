﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication
{
    abstract class EventCarte : Carte
    {
        override public abstract void onPlay();
        override public abstract void onValid();
        override public abstract void onDelete();
        private Player _target;

    }
}
