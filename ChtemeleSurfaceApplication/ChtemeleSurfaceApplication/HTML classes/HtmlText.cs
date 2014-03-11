using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    public class HtmlText : HtmlTagContent
    {
        private string _str;

        public HtmlText(string str)
            : base()
        {
            _str = str;
        }

        public string getText() { return _str; }
    }
}
