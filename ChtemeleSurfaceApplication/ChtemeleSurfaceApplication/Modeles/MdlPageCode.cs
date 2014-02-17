using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    class MdlPageCode : Modele
    {
        // Constantes, enumérations         ======================================================================================================



        // Variables membres                ======================================================================================================

        private HtmlPage _page;     //Données du modèle
        private string _code;       //Code généré

        private int _indentLevel;
        private int indentSize = 4;
        private int computedIndentChanges = 0;

        // Constructeurs                    ======================================================================================================

        public MdlPageCode()
            : base()
        {
            _page = _game.getPage();
            _code = "";

            _indentLevel = 0;
        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public string getCode() { return _code; }

        // Fonctionnalités                  ======================================================================================================

        // Rendu d'une page HTML
        public void renderPage()
        {
            _code = "";
            _code += renderHtmlElement(_page.mainTag());
            autoIndent();
        }

        // Rendu d'un élément HTML
        public string renderHtmlElement(HtmlElement elem)
        {
            string res = "";

            //on détermine le type de balise
            bool multiline = HtmlElement.multiLineTags.Exists(v => v == elem.getTagname());
            bool monoline = HtmlElement.monoLineTags.Exists(v => v == elem.getTagname());
            bool inline = (!multiline && !monoline);

            //chaine des attributs
            string resattr = "";
            if (elem.attributes.Count > 0)
            {
                foreach (HtmlTagAttribute attr in elem.attributes)
                {
                    resattr += " ";
                    resattr += renderHtmlTagAttribute(attr);
                }
            }

            //OpenTag
            //if (multiline) res += '\n';
            res += renderHtmlTag(elem.getOpenTag(), resattr);

            //retour à la ligne post-OpenTag multiline
            if (multiline) res += '\n';

            //content
            if (elem.tagContent.Count > 0)
            {
                foreach (HtmlTagContent e in elem.tagContent)
                {
                    if(e is HtmlElement)
                        res += renderHtmlElement(e as HtmlElement);
                    else if(e is HtmlText)
                        res += renderHtmlText(e as HtmlText);
                }
            }

            //indentation avant les multilines (intent ='' pour les inlines)
            if (multiline) res += '\n';

            //EndTag
            if (elem.isClosed())
                res += renderHtmlTag(elem.getEndTag());

            //retour à la ligne post-non-inline
            if (!inline) res += '\n';

            return res;
        }

        // Rendu d'une balise HTML ouvrante ou fermante
        public string renderHtmlTag(HtmlTag tag, string attribs = ""){
            string res = "";

            //on insère la balise
            res += HtmlTag.openSymbol[tag.getType()];
            res += tag.getTagName();
            if (tag.getType() == HtmlTag.HTMLTagType.OPENTAG) res += attribs;
            res += HtmlTag.endSymbol;

            //on met à jour l'indentation
            if (HtmlElement.singleTags.Exists(v => v == tag.getTagName()))
            {
                if (tag.getType() == HtmlTag.HTMLTagType.OPENTAG) _indentLevel++;
                else _indentLevel--;
            }

            return res;
        }


        public string renderHtmlText(HtmlText txt)
        {
            string ret = "";
            ret += txt.getText();

            return ret;
        }

        public string renderHtmlTagAttribute(HtmlTagAttribute attr)
        {
            string res = " ";
            res += attr.getKey();
            res += "=\"";
            res += attr.getValue();
            res += "\"";

            return res;
        }

        public void autoIndent()
        {
            _indentLevel = 1;
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

            if (Regex.IsMatch(s, @"^<(\w+)(\s[^>]*)?>$"))       //balise ouvrante
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
        }
    }
}
