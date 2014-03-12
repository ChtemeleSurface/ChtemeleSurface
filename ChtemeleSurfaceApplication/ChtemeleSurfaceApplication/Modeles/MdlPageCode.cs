using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    public class StrTypePair{

        public enum StrType                        // Toutes les sortes de chaines à styliser
        {
            DOCTYPE,

            USR_TAG,
            USR_OPEN_TAG,
            USR_END_TAG,
            USR_TAG_NAME,
            USR_TAG_ATTR_NAME,
            USR_TAG_ATTR_AFFECT,
            USR_TAG_ATTR_VALUE,
            USR_TEXT,

            AUTO_TAG,
            AUTO_OPEN_TAG,
            AUTO_END_TAG,
            AUTO_TAG_NAME,
            AUTO_TAG_ATTR_NAME,
            AUTO_TAG_ATTR_AFFECT,
            AUTO_TAG_ATTR_VALUE,
            AUTO_TEXT,

            COMMENT,
            LINE_BREAK

        }

        public string str = null;
        public StrType type;

        public StrTypePair(string s, StrType t) {
            str = s;
            type = t;
        }
    };

    public class MdlPageCode : Modele
    {
        // Constantes, enumérations         ======================================================================================================

        public static List<string> _htmlAutoTags = new List<string>
        {
            "html", "head", "title", "body", "link", "meta"
        };

        // Variables membres                ======================================================================================================

        private HtmlPage _page;     //Données du modèle
        private List<StrTypePair> _code;       //Code généré

        private int _indentLevel;
        private int indentSize = 4;
        private StrTypePair _currentLineBreak;
        private bool _isAutoTag = false;

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

            removeDoubleLineBreaks();
            autoIndent();
        }

        // Rendu d'un élément HTML
        public List<StrTypePair> renderHtmlElement(HtmlElement elem)
        {
            List<StrTypePair> res = new List<StrTypePair>();

            //on détermine le type de balise
            bool multiline = HtmlElement.multiLineTags.Exists(v => v == elem.getTagname());
            bool monoline = HtmlElement.monoLineTags.Exists(v => v == elem.getTagname());
            bool inline = (!multiline && !monoline);
            _isAutoTag = _htmlAutoTags.Exists(v => v == elem.getTagname());

            //chaine des attributs
            List<StrTypePair> resattr = new List<StrTypePair>();
            if (elem.attributes.Count > 0)
            {
                foreach (HtmlTagAttribute attr in elem.attributes)
                {
                    resattr.Add(new StrTypePair(" ", (_isAutoTag) ? StrTypePair.StrType.AUTO_TAG : StrTypePair.StrType.USR_TAG));
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

            _isAutoTag = _htmlAutoTags.Exists(v => v == tag.getTagName());

            //on insère la balise
            
            if(tag.getType() == HtmlTag.HTMLTagType.OPENTAG)
                res.Add(new StrTypePair(HtmlTag.openSymbol[tag.getType()], (_isAutoTag) ? StrTypePair.StrType.AUTO_OPEN_TAG : StrTypePair.StrType.USR_OPEN_TAG));
            else
                res.Add(new StrTypePair(HtmlTag.openSymbol[tag.getType()], (_isAutoTag) ? StrTypePair.StrType.AUTO_END_TAG : StrTypePair.StrType.USR_END_TAG));

            res.Add(new StrTypePair(tag.getTagName(), (_isAutoTag) ? StrTypePair.StrType.AUTO_TAG_NAME : StrTypePair.StrType.USR_TAG_NAME));

            if (tag.getType() == HtmlTag.HTMLTagType.OPENTAG && attribs != null) res.AddRange(attribs);

            res.Add(new StrTypePair(HtmlTag.endSymbol, (_isAutoTag) ? StrTypePair.StrType.AUTO_TAG : StrTypePair.StrType.USR_TAG));

            return res;
        }


        public StrTypePair renderHtmlText(HtmlText txt)
        {
            return new StrTypePair(txt.getText(), (_isAutoTag) ? StrTypePair.StrType.AUTO_TEXT : StrTypePair.StrType.USR_TEXT);
        }

        public List<StrTypePair> renderHtmlTagAttribute(HtmlTagAttribute attr)
        {
            List<StrTypePair> res = new List<StrTypePair>();

            res.Add(new StrTypePair(attr.getKey(), (_isAutoTag) ? StrTypePair.StrType.AUTO_TAG_ATTR_NAME : StrTypePair.StrType.USR_TAG_ATTR_NAME));
            res.Add(new StrTypePair("=", (_isAutoTag) ? StrTypePair.StrType.AUTO_TAG_ATTR_AFFECT : StrTypePair.StrType.USR_TAG_ATTR_AFFECT));

            string value = "\"" + attr.getValue() +"\"";
            res.Add(new StrTypePair(value, (_isAutoTag) ? StrTypePair.StrType.AUTO_TAG_ATTR_VALUE : StrTypePair.StrType.USR_TAG_ATTR_VALUE));

            return res;
        }

        public void autoIndent()
        {
            _indentLevel = 0;

            //On parcourt tous les éléments du dictionnaire
            foreach (StrTypePair elem in _code)
            {
                indentItem(elem);
            }
        }

        private void indentItem(StrTypePair elem)
        {

            switch (elem.type)
            {
                case StrTypePair.StrType.USR_OPEN_TAG:
                case StrTypePair.StrType.AUTO_OPEN_TAG:
                    _indentLevel++;
                    break;
                case StrTypePair.StrType.USR_TAG_NAME:
                case StrTypePair.StrType.AUTO_TAG_NAME:
                    if (HtmlElement.singleTags.Exists(v => v == elem.str))
                    {    // si ce n'est pas une balise simple, on annule la précédente auto-indentation
                        _indentLevel--;
                        _currentLineBreak.str = '\n' + new string(' ', indentSize * (_indentLevel));
                    }
                    break;
                case StrTypePair.StrType.USR_END_TAG:
                case StrTypePair.StrType.AUTO_END_TAG:
                    _indentLevel--;
                    _currentLineBreak.str = '\n' + new string(' ', indentSize * (_indentLevel));
                    break;
                case StrTypePair.StrType.LINE_BREAK:
                    indentLine(elem);
                    break;
            }


        }

        private void indentLine(StrTypePair elem)
        {
            // On stocke le retour à la ligne, s'il faut la modifier par la suite
            _currentLineBreak = elem;

            if (_indentLevel < 0) _indentLevel = 0;

            _currentLineBreak.str = '\n' + new string(' ', indentSize * _indentLevel);

        }

        public void removeDoubleLineBreaks()
        {
            bool linebreak = false;
            for (int i = 0; i < _code.Count; ++i)
            {
                if (_code[i].type == StrTypePair.StrType.LINE_BREAK)
                {
                    if (linebreak)
                    {
                        _code.RemoveAt(i);
                    }
                    else
                    {
                        linebreak = true;
                    }
                }
                else
                    linebreak = false;
            }
        }

        public void saveHTML(string filepath)
        {
            MdlRenduHtml mdlRendu = new MdlRenduHtml();
            mdlRendu.renderPage();
            string toSave = mdlRendu.getCode();
            System.IO.StreamWriter file = new System.IO.StreamWriter(filepath);
            file.WriteLine(toSave);
            file.Close();
        }
    }
}
