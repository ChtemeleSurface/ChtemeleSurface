using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlElement : HtmlTagContent
    {
        private string _name {get; set;}
        private bool _isCorrect { get; set; }
        private List<HtmlTagAttribute> _attributes { get; set; }
        private List<HtmlTagContent> _tagContent { get; set; }
        private int _score { get; set; }

        public HtmlElement(string name)
        {
            _name = name;
            _isCorrect = false;
            _score = 0;
        }

        public HtmlElement()
        {
            // TODO: Complete member initialization
        }
    }
}
