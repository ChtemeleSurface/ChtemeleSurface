using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes.Attaques
{
    public class Error303 : AttaqueCarte
    {
      
        public  Error303()
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
