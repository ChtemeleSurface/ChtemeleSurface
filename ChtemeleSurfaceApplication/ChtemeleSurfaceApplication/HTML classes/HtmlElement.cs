using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlElement : HtmlTagContent
    {
        private string _name;
        private bool _isCorrect;
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
            "body", "p", "div", "blockquote", "header", "footer", "aside", "hr", "img"
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


        //renvoie une string du rendu HTML de l'élément
        public override string renderHTML()
        {
            string res = "";

            //on détermine le type de balise
            bool multiline = multiLineTags.Exists(v => v == _tagname);
            bool monoline = monoLineTags.Exists(v => v == _tagname);
            bool inline = (!multiline && !monoline);

            //on détermine les caractères d'indentation
            //string indent = "";
            //if (!inline) indent = new String(' ', indentCount * indentSize);

            //chaine des attributs
            string resattr = "";
            if (attributes.Count > 0)
            {
                foreach (HtmlTagAttribute attr in attributes)
                {
                    resattr += " ";
                    resattr += attr.RenderHTML();
                }
            }
            
            //indentation avant les multilines (intent ='' pour les inlines)
            //if (!inline) res += indent;


            //OpenTag
            //if (multiline) res += '\n';
            res += _openTag.renderHTML(resattr);

            //retour à la ligne post-OpenTag multiline
            if (multiline) res += '\n';

            //content
            if (tagContent.Count > 0)
            {
                foreach (HtmlTagContent elem in tagContent)
                {
                    res += elem.renderHTML();
                }
            }

            //indentation avant les multilines (intent ='' pour les inlines)
            if (multiline) res += '\n';

            //EndTag
            if (isClosed())
                res += _endTag.renderHTML();

            //retour à la ligne post-non-inline
            if (!inline) res += '\n';

            return res;
        }


        public override string renderHTML(string attribs)
        {
            throw new NotImplementedException();
        }
    }
}
