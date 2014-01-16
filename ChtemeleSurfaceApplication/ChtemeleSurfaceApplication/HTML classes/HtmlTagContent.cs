using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlTagContent
    {
        private int _uniqId;
        private int _score;
        private HtmlElement _parent;


        public virtual string RenderHTML() { return null; }
    }
}
