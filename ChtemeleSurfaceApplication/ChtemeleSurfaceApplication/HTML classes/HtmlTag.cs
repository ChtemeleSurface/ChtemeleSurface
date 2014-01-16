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

        }

        override public string RenderHTML(){
            string res = "";

            if (_type == HTMLTagType.OPENTAG)
            {

            }

            return res;
        }
    }
}
