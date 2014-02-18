using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    abstract class HtmlTagContent
    {
        private int _uniqId;
        private int _score;
        private HtmlElement _parent;

        private static int lastId = 0;

        public HtmlTagContent()
        {
            _uniqId = lastId;
            lastId++;
        }

        public HtmlTagContent(HtmlElement parent) : this()
        {
            _parent = parent;
        }
    }
}
