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
            _mainTag = new HtmlElement("body");
        }
    }
}
