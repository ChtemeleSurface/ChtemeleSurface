using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlElement : HtmlTagContent
    {
        public static HtmlElement _currentElement = null;

        private string _name;
        private bool _isCorrect;    // non implémenté
        private string _tagname;
        public List<HtmlTagAttribute> attributes;
        public List<HtmlTagContent> tagContent;
        private int _score;


        private HtmlTag _openTag;
        private HtmlTag _endTag;

        private bool _closed = false;
        public bool isClosed() { return _closed; }


        //options de génération HTML
        private static Dictionary<HtmlTag.HTMLTagType, string> openSymbol = new Dictionary<HtmlTag.HTMLTagType, string>
        {
            {HtmlTag.HTMLTagType.OPENTAG , "<"},
            {HtmlTag.HTMLTagType.ENDTAG , "</"}
        };
        private static string endSymbol = ">";

        public static List<string> multiLineTags = new List<string>
        {
            "html", "head", "body", "p", "div", "blockquote", "header", "footer", "aside", "hr", "img"
        };

        public static List<string> monoLineTags = new List<string>
        {
            "h1", "h2", "h3", "h4", "h5", "h6", "br"
        };

        public static List<string> singleTags = new List<string>
        {
            "br", "hr", "img"
        };



        public HtmlElement(string name)
            : base()
        {
            _name = name;
            _isCorrect = false;
            _score = 0;
            _tagname = name;
            attributes = new List<HtmlTagAttribute>();
            tagContent = new List<HtmlTagContent>();
            openTag();

        }

        public string getTagname() { return _tagname; }
        public HtmlTag getOpenTag() { return _openTag; }
        public HtmlTag getEndTag() { return _endTag; }

        public void closeTag()
        {
            _endTag = new HtmlTag(_tagname, HtmlTag.HTMLTagType.ENDTAG);
            _closed = true;
        }

        public void openTag()
        {
            _openTag = new HtmlTag(_tagname, HtmlTag.HTMLTagType.OPENTAG);
            _closed = false;
        }

        public void addContent(HtmlTagContent c)
        {
            tagContent.Add(c);
        }

    }
}
