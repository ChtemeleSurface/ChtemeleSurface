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

        public HtmlTag(string tag, HTMLTagType type)
        {
            _tagname = tag;
            _type = type;
        }

        public override string renderHTML()
        {
            string res = "";

            if (_type == HTMLTagType.OPENTAG)
            {
                res += "<";
                res += _tagname;
                res += ">";
            }
            else
            {
                res += "</";
                res += _tagname;
                res += ">";
            }

            return res;
        }

        public override string renderHTML(string attribs)
        {
            string res = "";

            if (_type == HTMLTagType.OPENTAG)
            {
                res += "<";
                res += _tagname;
                res += attribs;
                res += ">";
            }
            else throw new NotSupportedException("Les balises fermantes d'acceptent pas d'attributs.");

            return res;
        }
    }
}
