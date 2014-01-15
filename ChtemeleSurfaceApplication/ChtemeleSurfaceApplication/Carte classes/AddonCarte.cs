using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication
{
    abstract class AddonCarte : EventCarte
    {
        abstract void onPlay();
        abstract void onValid();
    }
}
