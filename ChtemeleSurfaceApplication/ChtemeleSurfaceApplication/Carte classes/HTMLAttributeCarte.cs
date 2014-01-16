using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.Carte_classes
{
    class HTMLAttributeCarte : HTMLCarte
    {
        private string _key;
        private string _value;

        public HTMLAttributeCarte(string key, string value)
        {
            _key = key;
            _value = value;

        }
    }
}
