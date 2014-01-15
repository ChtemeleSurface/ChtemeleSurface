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
            _name = name;
            _isCorrect = false;
            _score = 0;

            //_tagContent.Add(new HtmlTag("body", HtmlTag.));
        }
    }
}
