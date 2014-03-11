using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Game_classes
{
    public class Effect
    {
        public enum EffectType
        {
            BROWSERUPDATE,
            CRASHBROWSER,
            FREEZE
        };

        protected EffectType _type;

        public EffectType getTypeEffect() { return _type; }

        // constructeur
        public Effect()
        {

        }
    }
}
