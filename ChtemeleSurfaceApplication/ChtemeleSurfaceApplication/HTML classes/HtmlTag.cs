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

            res += openSymbol[_type];
            res += _tagname;
            if (_type == HTMLTagType.OPENTAG) res += attribs;
            res += endSymbol;

            return res;
        }
    }
}
