using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication
{
    abstract class AttaqueCarte : EventCarte
    {
        abstract void onPlay();
        abstract void onValid();
    }
}
