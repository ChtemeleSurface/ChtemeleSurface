using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlElement : HtmlTagContent
    {
        private string _name;
        private bool _isCorrect;
        private List<HtmlTagAttribute> _attributes;
        private List<HtmlTagContent> _tagContent;
        private int _score;

        public HtmlElement(string name)
        {

        }

        public HtmlElement()
        {
            // TODO: Complete member initialization
        }
    }
}
