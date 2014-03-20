using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;



namespace ChtemeleSurfaceApplication.HTML_classes
{
    public class HtmlPage
    {
        // Constantes, enumérations         ======================================================================================================

        public const string defaultDoctype = "<!DOCTYPE html>";
        public const string cssDirectory = "Resources/css/";

        // Variables membres                ======================================================================================================

        private HtmlElement _bodyTag;       //Balise BODY
        private HtmlElement _mainTag;       //Balise HTML
        private HtmlElement _headTag;       //Balise HEAD
        private string _doctype;            //Balise DOCTYPE
        private string _title;              //Titre
        private HtmlElement _cssTag;        //Balise LINK
        private HtmlElement _encodingTag;        //Balise LINK
        public string cssFile = cssDirectory + "chtemele.css";

        // Constructeurs                    ======================================================================================================

        public HtmlPage()
        {
            //Page exemple
            /*_mainTag = new HtmlElement("html");
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

            _cssTag = new HtmlElement("link");
            _cssTag.attributes.Add(new HtmlTagAttribute("type", "text/css"));
            _cssTag.attributes.Add(new HtmlTagAttribute("rel", "stylesheet"));
            _cssTag.attributes.Add(new HtmlTagAttribute("href", cssFile));
            _headTag.addContent(_cssTag);

            _encodingTag = new HtmlElement("meta");
            _encodingTag.attributes.Add(new HtmlTagAttribute("charset", "UTF-8"));
            _headTag.addContent(_encodingTag);

            HtmlElement _baliseH1 = new HtmlElement("h1");
                _baliseH1.addContent(new HtmlText("Ceci est un magnifique titre !"));
                _baliseH1.attributes.Add(new HtmlTagAttribute("class", "montitre"));
                _baliseH1.closeTag();
                _bodyTag.addContent(_baliseH1);

            HtmlElement _baliseH2 = new HtmlElement("h2");
                _baliseH2.addContent(new HtmlText("Et ça, c'est un impressionnant sous-titre !"));
                _baliseH2.closeTag();
                _bodyTag.addContent(_baliseH2);

            HtmlElement _baliseP = new HtmlElement("p");
                _baliseP.addContent(new HtmlText("Lorem Ipsum et de toute façon je met le texte que je veux ce sera beautiful !"));
                HtmlElement _baliseBR = new HtmlElement("br");
                    _baliseP.addContent(_baliseBR);
                _baliseP.addContent(new HtmlText("N'est-ce pas ?"));
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
                    _baliseH3.addContent(new HtmlText("Et ça, c'est un scintillant sous-sous-titre !"));
                    _baliseH3.closeTag();
                    _baliseDIV2.addContent(_baliseH3);

                HtmlElement _baliseP2 = new HtmlElement("p");
                _baliseP2.addContent(new HtmlText("Barquette !! Barquette !!! J'aimerais mon niveau deux, s'il vous plait."));
                HtmlElement _baliseBR2 = new HtmlElement("br");
                _baliseP2.addContent(_baliseBR2);
                _baliseP2.addContent(new HtmlText("Je veux juste faire une longue phrase qui servira à tester le retour à la ligne non-automatique du TextBox."));
                _baliseP2.closeTag();
                _baliseDIV2.addContent(_baliseP2);*/
            

            _mainTag = new HtmlElement("html");
            _mainTag.closeTag();

            _doctype = defaultDoctype;

            _title = "Vous jouez actuellement à cHTeMeLe !";
            _headTag = new HtmlElement("head");
            _headTag.closeTag();
            _headTag.addContent(titleTag());
            _mainTag.addContent(_headTag);

            _bodyTag = new HtmlElement("body");
            //_bodyTag.attributes.Add(new HtmlTagAttribute("id", "Tamère"));
            _bodyTag.closeTag();
            _mainTag.addContent(_bodyTag);

            _cssTag = new HtmlElement("link");
            _cssTag.attributes.Add(new HtmlTagAttribute("type", "text/css"));
            _cssTag.attributes.Add(new HtmlTagAttribute("rel", "stylesheet"));
            _cssTag.attributes.Add(new HtmlTagAttribute("href", cssFile));
            _headTag.addContent(_cssTag);

            _encodingTag = new HtmlElement("meta");
            _encodingTag.attributes.Add(new HtmlTagAttribute("charset", "UTF-8"));
            _headTag.addContent(_encodingTag);
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

        public void changeCSS(string f)
        {
            cssFile = cssDirectory + f + ".css";
            _cssTag.attributes.Clear();
            _cssTag.attributes.Add(new HtmlTagAttribute("type", "text/css"));
            _cssTag.attributes.Add(new HtmlTagAttribute("rel", "stylesheet"));
            _cssTag.attributes.Add(new HtmlTagAttribute("href", cssFile));
        }
    }
}
