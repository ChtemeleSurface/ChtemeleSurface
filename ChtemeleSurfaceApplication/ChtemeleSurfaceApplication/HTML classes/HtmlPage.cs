using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlPage
    {
        private HtmlElement _mainTag;

        public HtmlPage()
        {
            _mainTag = new HtmlElement("body");
            _mainTag.closeTag();

            HtmlElement _baliseH1 = new HtmlElement("h1");
                _baliseH1.addContent(new HtmlText("Ceci est un putain de titre !"));
                _baliseH1.closeTag();
                _mainTag.addContent(_baliseH1);

            HtmlElement _baliseH2 = new HtmlElement("h2");
                _baliseH2.addContent(new HtmlText("Et ça, c'est un péripatéticienne de sous-titre !"));
                _baliseH2.closeTag();
                _mainTag.addContent(_baliseH2);

            HtmlElement _baliseP = new HtmlElement("p");
                _baliseP.addContent(new HtmlText("Lorem Ipsum et de toute façon je met le texte que je veux tout le monde s'en calice !"));
                HtmlElement _baliseBR = new HtmlElement("br");
                    _baliseP.addContent(_baliseBR);
                _baliseP.addContent(new HtmlText("Voilà, d'abord !!"));
                _baliseP.closeTag();
                _mainTag.addContent(_baliseP);

            HtmlElement _baliseDIV1 = new HtmlElement("div");
                _baliseDIV1.closeTag();
                _mainTag.addContent(_baliseDIV1);

                HtmlElement _baliseDIV2 = new HtmlElement("div");
                    _baliseDIV2.closeTag();
                    _baliseDIV1.addContent(_baliseDIV2);

                HtmlElement _baliseH3 = new HtmlElement("h3");
                    _baliseH3.addContent(new HtmlText("Et ça, c'est un péripatéticienne de sous-sous-titre !"));
                    _baliseH3.closeTag();
                    _baliseDIV2.addContent(_baliseH3);


           /*
            //instantiation balises test
            HtmlElement _baliseH1 = new HtmlElement("H1");
            _baliseH1.tagContent.Add(new HtmlTag("h1", HtmlTag.HTMLTagType.OPENTAG));
            _baliseH1.tagContent.Add(new HtmlText("Ceci est un titre."));
            _baliseH1.tagContent.Add(new HtmlTag("h1", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseH2 = new HtmlElement("H2");
            _baliseH2.tagContent.Add(new HtmlTag("h2", HtmlTag.HTMLTagType.OPENTAG));
            _baliseH2.tagContent.Add(new HtmlText("Ceci est un sous-titre."));
            _baliseH2.tagContent.Add(new HtmlTag("h2", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseP = new HtmlElement("P");
            _baliseP.tagContent.Add(new HtmlTag("p", HtmlTag.HTMLTagType.OPENTAG));
            _baliseP.tagContent.Add(new HtmlText("Ceci est un paragraphe."));
            _baliseP.tagContent.Add(new HtmlTag("p", HtmlTag.HTMLTagType.ENDTAG));
            _baliseP.attributes.Add(new HtmlTagAttribute("class", "monparagraphe"));

            HtmlElement _baliseDIV = new HtmlElement("DIV");
            _baliseDIV.tagContent.Add(new HtmlTag("div", HtmlTag.HTMLTagType.OPENTAG));
            _baliseDIV.tagContent.Add(_baliseP);
            _baliseDIV.tagContent.Add(new HtmlTag("div", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseBLOCKQUOTE = new HtmlElement("BLOCKQUOTE");
            _baliseBLOCKQUOTE.tagContent.Add(new HtmlTag("blockquote", HtmlTag.HTMLTagType.OPENTAG));
            _baliseBLOCKQUOTE.tagContent.Add(new HtmlTag("blockquote", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseHEADER = new HtmlElement("HEADER");
            _baliseHEADER.tagContent.Add(new HtmlTag("header", HtmlTag.HTMLTagType.OPENTAG));
            _baliseHEADER.tagContent.Add(new HtmlTag("header", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseFOOTER = new HtmlElement("FOOTER");
            _baliseFOOTER.tagContent.Add(new HtmlTag("footer", HtmlTag.HTMLTagType.OPENTAG));
            _baliseFOOTER.tagContent.Add(new HtmlTag("footer", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseASIDE = new HtmlElement("ASIDE");
            _baliseASIDE.tagContent.Add(new HtmlTag("aside", HtmlTag.HTMLTagType.OPENTAG));
            _baliseASIDE.tagContent.Add(new HtmlTag("aside", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseSTRONG = new HtmlElement("STRONG");
            _baliseSTRONG.tagContent.Add(new HtmlTag("strong", HtmlTag.HTMLTagType.OPENTAG));
            _baliseSTRONG.tagContent.Add(new HtmlTag("strong", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseEM = new HtmlElement("EM");
            _baliseEM.tagContent.Add(new HtmlTag("em", HtmlTag.HTMLTagType.OPENTAG));
            _baliseEM.tagContent.Add(new HtmlTag("em", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseA = new HtmlElement("A");
            _baliseA.tagContent.Add(new HtmlTag("a", HtmlTag.HTMLTagType.OPENTAG));
            _baliseA.tagContent.Add(new HtmlTag("a", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseBR = new HtmlElement("BR");
            _baliseBR.tagContent.Add(new HtmlTag("br", HtmlTag.HTMLTagType.OPENTAG));
            _baliseBR.tagContent.Add(new HtmlTag("br", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseHR = new HtmlElement("HR");
            _baliseHR.tagContent.Add(new HtmlTag("hr", HtmlTag.HTMLTagType.OPENTAG));
            _baliseHR.tagContent.Add(new HtmlTag("hr", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseIMG = new HtmlElement("IMG");
            _baliseIMG.tagContent.Add(new HtmlTag("img", HtmlTag.HTMLTagType.OPENTAG));
            _baliseIMG.tagContent.Add(new HtmlTag("img", HtmlTag.HTMLTagType.ENDTAG));

            //body
            _mainTag = new HtmlElement("BODY");
            _mainTag.tagContent.Add(new HtmlTag("body", HtmlTag.HTMLTagType.OPENTAG));

            _mainTag.tagContent.Add(_baliseH1);
            _mainTag.tagContent.Add(_baliseH2);
            _mainTag.tagContent.Add(_baliseDIV);

            _mainTag.tagContent.Add(new HtmlTag("body", HtmlTag.HTMLTagType.ENDTAG));

            */



        }

        public string renderHTML(){
            string res = "";

            res += _mainTag.renderHTML();

            return res;
        }
    }
}
