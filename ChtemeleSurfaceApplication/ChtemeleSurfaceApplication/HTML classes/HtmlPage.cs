using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlPage
    {
        private HtmlElement _mainTag;

        public HtmlPage()
        {
            _mainTag.tagContent.Add(new HtmlTag("body", HtmlTag.HTMLTagType.OPENTAG));
            _mainTag.tagContent.Add(new HtmlTag("body", HtmlTag.HTMLTagType.ENDTAG));
        }

        public string renderHTML(){
            string res = "";

            res += _mainTag.renderHTML();

            return res;
        }
    }
}
