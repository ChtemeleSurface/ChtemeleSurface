using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    

    class HtmlTag
    {
        public enum HTMLTagType {OPENTAG, ENDTAG};

        private string _tagname;
        private HTMLTagType _type;

        //options de génération HTML
        public static Dictionary<HtmlTag.HTMLTagType, string> openSymbol = new Dictionary<HtmlTag.HTMLTagType, string>
        {
            {HtmlTag.HTMLTagType.OPENTAG , "<"},
            {HtmlTag.HTMLTagType.ENDTAG , "</"}
        };
        public static string endSymbol = ">";


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="type"></param>
        public HtmlTag(string tag, HTMLTagType type)
        {
            _tagname = tag;
            _type = type;
        }

        public string getTagName() { return _tagname; }
        public HTMLTagType getType() { return _type; }
    }
}
