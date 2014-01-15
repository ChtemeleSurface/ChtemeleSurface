using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Carte_classes
{
    class HTMLTagCarte
    {
        private HtmlTag _tag;
        private HtmlTag.HTMLTagType _type;

        public HTMLTagCarte()
        {
            _type = HtmlTag.HTMLTagType.OPENTAG; 
        }
    }

}
