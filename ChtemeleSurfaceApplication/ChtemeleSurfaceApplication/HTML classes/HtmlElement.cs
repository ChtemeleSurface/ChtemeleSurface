using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlElement : HtmlTagContent
    {
        private string name;
        private bool isCorrect;
        private List<HtmlTagAttribute> attributes;
        private List<HtmlTagContent> tagContent;
        private int score;
    }
}
