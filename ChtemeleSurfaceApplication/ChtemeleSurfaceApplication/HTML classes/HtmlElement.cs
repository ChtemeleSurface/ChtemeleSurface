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

        private static List<string> multiLineTags = new List<string>
        {
            "body", "p", "div", "blockquote", "header", "footer", "aside", "hr"
        };

        private static List<string> monoLineTags = new List<string>
        {
            "h1", "h2", "br"
        };

        public static int indentCount = 0;
        public static int indentSize = 4;



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
            if (tagContent.Count == 0) return res;

            //on détermine le type de balise
            bool multiline = multiLineTags.Exists(v => v == _tagname);
            bool monoline = monoLineTags.Exists(v => v == _tagname);
            bool inline = (!multiline && !monoline);

            //on détermine les caractères d'indentation
            string indent = "";
            if (!inline) indent = new String(' ', indentCount * indentSize);

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
            res += indent;


            //OpenTag
            res += _openTag.renderHTML(resattr);

            //content
            foreach (HtmlTagContent elem in tagContent)
            {
                res += elem.renderHTML();
            }

            //EndTag
            res += _endTag.renderHTML();

            //retour à la ligne post-multiline
            if (!inline) res += '\n';

            return res;
        }


        public override string renderHTML(string attribs)
        {
            throw new NotImplementedException();
        }
    }
}
