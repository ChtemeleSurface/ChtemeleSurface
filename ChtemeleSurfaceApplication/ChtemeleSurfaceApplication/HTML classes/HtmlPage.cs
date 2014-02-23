using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlPage
    {
        // Constantes, enumérations         ======================================================================================================

        public const string defaultDoctype = "<!DOCTYPE html>";

        // Variables membres                ======================================================================================================

        private HtmlElement _bodyTag;       //Balise BODY
        private HtmlElement _mainTag;       //Balise HTML
        private HtmlElement _headTag;       //Balise HEAD
        private string _doctype;            //Balise DOCTYPE
        private string _title;              //Titre

        // Constructeurs                    ======================================================================================================

        public HtmlPage()
        {
            _mainTag = new HtmlElement("html");
            _mainTag.closeTag();

            _doctype = defaultDoctype;

            _title = "Bonjour, bienvenue, Hello world ! C'est tout !";
            _headTag = new HtmlElement("head");
            _headTag.closeTag();
            _headTag.addContent(titleTag());
            _mainTag.addContent(_headTag);

            _bodyTag = new HtmlElement("body");
            _bodyTag.attributes.Add(new HtmlTagAttribute("id", "Tamère"));
            _bodyTag.closeTag();
            _mainTag.addContent(_bodyTag);

            HtmlElement _baliseH1 = new HtmlElement("h1");
                _baliseH1.addContent(new HtmlText("Ceci est un putain de titre !"));
                _baliseH1.attributes.Add(new HtmlTagAttribute("class", "montitre"));
                _baliseH1.closeTag();
                _bodyTag.addContent(_baliseH1);

            HtmlElement _baliseH2 = new HtmlElement("h2");
                _baliseH2.addContent(new HtmlText("Et ça, c'est un péripatéticienne de sous-titre !"));
                _baliseH2.closeTag();
                _bodyTag.addContent(_baliseH2);

            HtmlElement _baliseP = new HtmlElement("p");
                _baliseP.addContent(new HtmlText("Lorem Ipsum et de toute façon je met le texte que je veux tout le monde s'en calice !"));
                HtmlElement _baliseBR = new HtmlElement("br");
                    _baliseP.addContent(_baliseBR);
                _baliseP.addContent(new HtmlText("Voilà, d'abord !!"));
                _baliseP.closeTag();
                _bodyTag.addContent(_baliseP);

            HtmlElement _baliseDIV1 = new HtmlElement("div");
            _baliseDIV1.attributes.Add(new HtmlTagAttribute("id", "DTC"));
                _baliseDIV1.closeTag();
                _bodyTag.addContent(_baliseDIV1);

                HtmlElement _baliseDIV2 = new HtmlElement("div");
                    _baliseDIV2.closeTag();
                    _baliseDIV1.addContent(_baliseDIV2);

                HtmlElement _baliseH3 = new HtmlElement("h3");
                    _baliseH3.addContent(new HtmlText("Et ça, c'est un péripatéticienne de sous-sous-titre !"));
                    _baliseH3.closeTag();
                    _baliseDIV2.addContent(_baliseH3);


        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public HtmlElement bodyTag() { return _bodyTag; }
        public HtmlElement mainTag() { return _mainTag; }
        public string doctype() { return _doctype; }
        public string title() { return _title; }

        public HtmlElement titleTag(){
            HtmlElement ret = new HtmlElement("title");
            ret.addContent(new HtmlText(_title));
            ret.closeTag();
            return ret;
        }
    }
}
