using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    class StrTypePair{

        public enum StrType                        // Toutes les sortes de chaines à styliser
        {
            DOCTYPE,

            USR_TAG,
            USR_TAG_ATTR_NAME,
            USR_TAG_ATTR_AFFECT,
            USR_TAG_ATTR_VALUE,
            USR_TEXT,

            AUTO_TAG,
            AUTO_TAG_ATTR_NAME,
            AUTO_TAG_ATTR_AFFECT,
            AUTO_TAG_ATTR_VALUE,
            AUTO_TEXT,

            COMMENT,
            LINE_BREAK

        }

        public string str;
        public StrType type;

        public StrTypePair(string s, StrType t) {
            str = s;
            type = t;
        }
    };

    class MdlPageCode : Modele
    {
        // Constantes, enumérations         ======================================================================================================

        

        // Variables membres                ======================================================================================================

        private HtmlPage _page;     //Données du modèle
        private List<StrTypePair> _code;       //Code généré

        private int _indentLevel;
        private int indentSize = 4;
        private int computedIndentChanges = 0;

        // Constructeurs                    ======================================================================================================

        public MdlPageCode()
            : base()
        {
            _page = _game.getPage();
            _code = new List<StrTypePair>();

            _indentLevel = 0;
        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public List<StrTypePair> getCode() { return _code; }

        // Fonctionnalités                  ======================================================================================================

        // Rendu d'une page HTML
        public void renderPage()
        {
            _code.Clear();
            _code.Add(new StrTypePair(_page.doctype(), StrTypePair.StrType.DOCTYPE));
            _code.Add(new StrTypePair("\n", StrTypePair.StrType.LINE_BREAK));

            _code.AddRange(renderHtmlElement(_page.mainTag()));

            //autoIndent();
        }

        // Rendu d'un élément HTML
        public List<StrTypePair> renderHtmlElement(HtmlElement elem)
        {
            List<StrTypePair> res = new List<StrTypePair>();

            //on détermine le type de balise
            bool multiline = HtmlElement.multiLineTags.Exists(v => v == elem.getTagname());
            bool monoline = HtmlElement.monoLineTags.Exists(v => v == elem.getTagname());
            bool inline = (!multiline && !monoline);

            //chaine des attributs
            List<StrTypePair> resattr = new List<StrTypePair>();
            if (elem.attributes.Count > 0)
            {
                foreach (HtmlTagAttribute attr in elem.attributes)
                {
                    resattr.Add(new StrTypePair(" ", StrTypePair.StrType.USR_TAG));
                    resattr.AddRange(renderHtmlTagAttribute(attr));
                }
            }

            //OpenTag
            //if (multiline) res += '\n';
            res.AddRange(renderHtmlTag(elem.getOpenTag(), resattr));

            //retour à la ligne post-OpenTag multiline
            if (multiline) res.Add(new StrTypePair("\n", StrTypePair.StrType.LINE_BREAK));

            //content
            if (elem.tagContent.Count > 0)
            {
                foreach (HtmlTagContent e in elem.tagContent)
                {
                    if(e is HtmlElement)
                        res.AddRange(renderHtmlElement(e as HtmlElement));
                    else if(e is HtmlText)
                        res.Add(renderHtmlText(e as HtmlText));
                }
            }

            //indentation avant les multilines (intent ='' pour les inlines)
            if (multiline) res.Add(new StrTypePair("\n", StrTypePair.StrType.LINE_BREAK));

            //EndTag
            if (elem.isClosed())
                res.AddRange(renderHtmlTag(elem.getEndTag()));

            //retour à la ligne post-non-inline
            if (!inline) res.Add(new StrTypePair("\n", StrTypePair.StrType.LINE_BREAK));

            return res;
        }

        // Rendu d'une balise HTML ouvrante ou fermante
        public List<StrTypePair> renderHtmlTag(HtmlTag tag, List<StrTypePair> attribs = null)
        {
            List<StrTypePair> res = new List<StrTypePair>();
            string strtag = "";

            //on insère la balise
            
            strtag += HtmlTag.openSymbol[tag.getType()];
            strtag += tag.getTagName();
            res.Add(new StrTypePair(strtag, StrTypePair.StrType.USR_TAG));

            if (tag.getType() == HtmlTag.HTMLTagType.OPENTAG && attribs != null) res.AddRange(attribs);

            res.Add(new StrTypePair(HtmlTag.endSymbol, StrTypePair.StrType.USR_TAG));

            return res;
        }


        public StrTypePair renderHtmlText(HtmlText txt)
        {
            return new StrTypePair(txt.getText(), StrTypePair.StrType.USR_TEXT);
        }

        public List<StrTypePair> renderHtmlTagAttribute(HtmlTagAttribute attr)
        {
            List<StrTypePair> res = new List<StrTypePair>();

            res.Add(new StrTypePair(attr.getKey(), StrTypePair.StrType.USR_TAG_ATTR_NAME));
            res.Add(new StrTypePair("=", StrTypePair.StrType.USR_TAG_ATTR_AFFECT));

            string value = "\"" + attr.getValue() +"\"";
            res.Add(new StrTypePair(value, StrTypePair.StrType.USR_TAG_ATTR_VALUE));

            return res;
        }

        /*public void autoIndent()
        {
            _indentLevel = 0;
            string res = "";

            //On parcout toutes les balises et les retours à la ligne de la séquence.


            MatchEvaluator evalLine = new MatchEvaluator(fetchLine);

            string linePattern = @"\n+(?<line>.*)";

            try
            {
                res = Regex.Replace(_code, linePattern, evalLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            _code = res;
        }

        private string fetchIndentItem(Match item)
        {
            string s = item.ToString();

            if (Regex.IsMatch(s, @"^<!.+>$"))                       //Doctype
            {
                //nothing
            }

            else if (Regex.IsMatch(s, @"^<(\w+)(\s[^>]*)?>$"))       //balise ouvrante
            {
                if (HtmlElement.singleTags.Exists(v => v == item.Groups["tagname"].ToString()))
                {
                    //balise simple
                }
                else
                    computedIndentChanges++;
            }
            else //if (Regex.IsMatch(s, @"^</\w+>$"))       //balise fermante seule
            {
                computedIndentChanges--;
            }

            return s;
        }

        private string fetchLine(Match item)
        {
            computedIndentChanges = 0;
            string s = item.ToString();

            string pattern = @"</?(?<tagname>\w+)(\s[^>]*)?>";
            MatchEvaluator evalElem = new MatchEvaluator(fetchIndentItem);

            try
            {
                s = Regex.Replace(s, pattern, evalElem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (computedIndentChanges < 0)
            {
                _indentLevel += computedIndentChanges;
                if (_indentLevel < 0) _indentLevel = 0;
            }
            string res = '\n' + new string(' ', indentSize * _indentLevel) + item.Groups["line"].ToString();
            if (computedIndentChanges > 0) _indentLevel += computedIndentChanges;
            return res;
        }*/
    }
}
