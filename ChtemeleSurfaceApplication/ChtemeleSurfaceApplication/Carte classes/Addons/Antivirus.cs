using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Addons
{
    public class Antivirus : AddonCarte
    {
        public Antivirus() : base(){}

        public override void onValid()      // Normalement celle-ci est applée automatiquement
        {
            base.onValid();
            Game_classes.Game.getInstance.isThereAntivirus = false;
        }

        public override void onPlay()
        {
            base.onPlay();
            Game_classes.Game.getInstance.isThereAntivirus = true;
        }

        public override void onDelete()
        {
            base.onDelete();
            Game_classes.Game.getInstance.isThereAntivirus = false;
        }
    }
}
