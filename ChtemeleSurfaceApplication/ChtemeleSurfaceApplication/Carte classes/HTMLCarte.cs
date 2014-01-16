using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChtemeleSurfaceApplication
{
    abstract class HTMLCarte : Carte
    {
        override public abstract void onPlay();
        override public abstract void onValid();
    }
}
