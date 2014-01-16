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

        public enum AvailableOpenTags
        {
            H1,
            H2,
            P,
            DIV,
            BLOCKQUOTE,
            HEADER,
            FOOTER,
            ASIDE,
            STRONG,
            EM,
            A
        }

        public enum AvailableEndTags
        {
            H1,
            H2,
            P,
            DIV,
            BLOCKQUOTE,
            HEADER,
            FOOTER,
            ASIDE,
            STRONG,
            EM,
            A
        };

        public enum AvailableSingleTags
        {
            BR,
            HR,
            IMG

        };

        public HTMLTagCarte()
        {
            _type = HtmlTag.HTMLTagType.OPENTAG; 
        }
    }

}
