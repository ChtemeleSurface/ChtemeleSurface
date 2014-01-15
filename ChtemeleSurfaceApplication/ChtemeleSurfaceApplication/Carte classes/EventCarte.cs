using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication
{
    abstract class EventCarte : Carte
    {
        abstract void onPlay();
        abstract void onValid();
    }
}
