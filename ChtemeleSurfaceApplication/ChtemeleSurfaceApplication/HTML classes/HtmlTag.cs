using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    

    class HtmlTag : HtmlTagContent
    {
        public enum HTMLTagType {OPENTAG, ENDTAG};

        private string _tagname;
        private HTMLTagType _type;

        //options de génération HTML
        private static Dictionary<HTMLTagType, string> openSymbol = new Dictionary<HTMLTagType,string>
        {
            {HTMLTagType.OPENTAG , "<"},
            {HTMLTagType.ENDTAG , "</"}
        };
        private static string endSymbol = ">";

        private static List<string> multiLineTags = new List<string>
        {
            "body", "p", "div", "blockquote", "header", "footer", "aside", "hr"
        };

        private static List<string> monoLineTags = new List<string>
        {
            "h1", "h2", "br"
        };


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

        public override string renderHTML()
        {
            return renderHTML("");
        }

        public override string renderHTML(string attribs)
        {
            string res = "";
            bool multiline = multiLineTags.Exists(v => v == _tagname);
            bool monoline = monoLineTags.Exists(v => v == _tagname);

            res += openSymbol[_type];
            res += _tagname;
            if (_type == HTMLTagType.OPENTAG) res += attribs;
            res += endSymbol;

            if (multiline) res += "\n";
            if (_type == HTMLTagType.ENDTAG && monoline) res += "\n";
            
            return res;
        }
    }
}
