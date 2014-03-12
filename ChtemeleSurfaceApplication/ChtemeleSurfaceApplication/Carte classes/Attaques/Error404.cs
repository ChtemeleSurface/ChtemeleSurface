using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Attaques
{
    public class Error404 : AttaqueCarte
    {
        public  Error404()
            : base()
        { 
        }

        public override void onValid()
        {
            // Elfe airien
        }

        public override void onDelete()
        {
            throw new NotImplementedException();
        }
    }
}
