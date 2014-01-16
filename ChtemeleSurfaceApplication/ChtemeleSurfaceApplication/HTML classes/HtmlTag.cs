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

        private static int nbOpenTags = 0;
        private static int indentSize = 4;


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

            //On indente
            if (multiline && _type == HTMLTagType.OPENTAG) res += new String(' ', nbOpenTags * indentSize);
            else if (multiline && _type == HTMLTagType.ENDTAG) res += new String(' ', (nbOpenTags-1) * indentSize);
            else if (monoline && _type == HTMLTagType.OPENTAG) res += new String(' ', nbOpenTags * indentSize);

            //on insère la balise
            res += openSymbol[_type];
            res += _tagname;
            if (_type == HTMLTagType.OPENTAG) res += attribs;
            res += endSymbol;

            //on ajoute un retour à la ligne (des fois)
            if (multiline) res += "\n";
            if (_type == HTMLTagType.ENDTAG && monoline) res += "\n";

            //on met à jour l'indentation
            if (_type == HTMLTagType.OPENTAG) nbOpenTags++;
            else nbOpenTags--;
            
            return res;
        }
    }
}
