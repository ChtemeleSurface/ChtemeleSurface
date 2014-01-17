using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlText : HtmlTagContent
    {
        private string _str;

        public HtmlText(string str)
        {
            _str = str;
        }

        public override string renderHTML()
        {
            string ret = "";
            ret += new String(' ', HtmlTagContent.indentCount * HtmlTagContent.indentSize);
            ret += _str;
            ret += "\n";

            return ret;

        }

        public override string renderHTML(string attribs)
        {
            throw new NotImplementedException();
        }
    }
}
