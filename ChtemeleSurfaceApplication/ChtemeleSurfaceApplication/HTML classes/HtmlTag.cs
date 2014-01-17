using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    

    class HtmlTag : HtmlTagContent
    {
        public enum HTMLTagType {OPENTAG, ENDTAG};

        private string _tagname;
        private HTMLTagType _type;

        //options de génération HTML
        private static Dictionary<HTMLTagType, string> openSymbol = new Dictionary<HTMLTagType,string>
        {
            {HTMLTagType.OPENTAG , "<"},
            {HTMLTagType.ENDTAG , "</"}
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


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="type"></param>
        public HtmlTag(string tag, HTMLTagType type)
        {
            _tagname = tag;
            _type = type;
        }

        public override string renderHTML()
        {
            return renderHTML("");
        }

        public override string renderHTML(string attribs)
        {
            string res = "";
            //on détermine le type de balise
            bool multiline = multiLineTags.Exists(v => v == _tagname);
            bool monoline = monoLineTags.Exists(v => v == _tagname);
            bool inline = (!multiline && !monoline);

            //on détermine les caractères d'indentation
            string indent = "";
            if (multiline && _type == HTMLTagType.OPENTAG) indent = new String(' ', HtmlTagContent.indentCount * HtmlTagContent.indentSize);
            else if (multiline && _type == HTMLTagType.ENDTAG) indent = new String(' ', (HtmlTagContent.indentCount - 1) * HtmlTagContent.indentSize);
            else if (monoline && _type == HTMLTagType.OPENTAG) indent = new String(' ', HtmlTagContent.indentCount * HtmlTagContent.indentSize);

            //on commence à une ligne nouvelle si on est une balise block.

            //on indente (seulement si on est une balise block)
            if(!inline) res += indent;

            //on insère la balise
            res += openSymbol[_type];
            res += _tagname;
            if (_type == HTMLTagType.OPENTAG) res += attribs;
            res += endSymbol;

            //on ajoute un retour à la ligne (des fois)
            if (multiline)
            {
                res += "\n";
            }
            if (_type == HTMLTagType.ENDTAG && monoline) res += "\n";

            //on met à jour l'indentation
            if (_type == HTMLTagType.OPENTAG) HtmlTagContent.indentCount++;
            else HtmlTagContent.indentCount--;
            
            return res;
        }
    }
}
