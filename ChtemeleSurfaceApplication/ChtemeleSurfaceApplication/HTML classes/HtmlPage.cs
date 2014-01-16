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
           
            //instantiation balises test
            HtmlElement _baliseH1 = new HtmlElement();
            _baliseH1.tagContent.Add(new HtmlTag("h1", HtmlTag.HTMLTagType.OPENTAG));
            _baliseH1.tagContent.Add(new HtmlTag("h1", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseH2 = new HtmlElement();
            _baliseH2.tagContent.Add(new HtmlTag("h2", HtmlTag.HTMLTagType.OPENTAG));
            _baliseH2.tagContent.Add(new HtmlTag("h2", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseP = new HtmlElement();
            _baliseP.tagContent.Add(new HtmlTag("p", HtmlTag.HTMLTagType.OPENTAG));
            _baliseP.tagContent.Add(new HtmlTag("p", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseDIV = new HtmlElement();
            _baliseDIV.tagContent.Add(new HtmlTag("div", HtmlTag.HTMLTagType.OPENTAG));
            _baliseDIV.tagContent.Add(_baliseP);
            _baliseDIV.tagContent.Add(new HtmlTag("div", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseBLOCKQUOTE = new HtmlElement();
            _baliseBLOCKQUOTE.tagContent.Add(new HtmlTag("blockquote", HtmlTag.HTMLTagType.OPENTAG));
            _baliseBLOCKQUOTE.tagContent.Add(new HtmlTag("blockquote", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseHEADER = new HtmlElement();
            _baliseHEADER.tagContent.Add(new HtmlTag("header", HtmlTag.HTMLTagType.OPENTAG));
            _baliseHEADER.tagContent.Add(new HtmlTag("header", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseFOOTER = new HtmlElement();
            _baliseFOOTER.tagContent.Add(new HtmlTag("footer", HtmlTag.HTMLTagType.OPENTAG));
            _baliseFOOTER.tagContent.Add(new HtmlTag("footer", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseASIDE = new HtmlElement();
            _baliseASIDE.tagContent.Add(new HtmlTag("aside", HtmlTag.HTMLTagType.OPENTAG));
            _baliseASIDE.tagContent.Add(new HtmlTag("aside", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseSTRONG = new HtmlElement();
            _baliseSTRONG.tagContent.Add(new HtmlTag("strong", HtmlTag.HTMLTagType.OPENTAG));
            _baliseSTRONG.tagContent.Add(new HtmlTag("strong", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseEM = new HtmlElement();
            _baliseEM.tagContent.Add(new HtmlTag("em", HtmlTag.HTMLTagType.OPENTAG));
            _baliseEM.tagContent.Add(new HtmlTag("em", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseA = new HtmlElement();
            _baliseA.tagContent.Add(new HtmlTag("a", HtmlTag.HTMLTagType.OPENTAG));
            _baliseA.tagContent.Add(new HtmlTag("a", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseBR = new HtmlElement();
            _baliseBR.tagContent.Add(new HtmlTag("br", HtmlTag.HTMLTagType.OPENTAG));
            _baliseBR.tagContent.Add(new HtmlTag("br", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseHR = new HtmlElement();
            _baliseHR.tagContent.Add(new HtmlTag("hr", HtmlTag.HTMLTagType.OPENTAG));
            _baliseHR.tagContent.Add(new HtmlTag("hr", HtmlTag.HTMLTagType.ENDTAG));

            HtmlElement _baliseIMG = new HtmlElement();
            _baliseIMG.tagContent.Add(new HtmlTag("img", HtmlTag.HTMLTagType.OPENTAG));
            _baliseIMG.tagContent.Add(new HtmlTag("img", HtmlTag.HTMLTagType.ENDTAG));

            //body
            _mainTag = new HtmlElement();
            _mainTag.tagContent.Add(new HtmlTag("body", HtmlTag.HTMLTagType.OPENTAG));

            _mainTag.tagContent.Add(_baliseH1);
            _mainTag.tagContent.Add(_baliseH2);
            _mainTag.tagContent.Add(_baliseDIV);


            _mainTag.tagContent.Add(new HtmlTag("body", HtmlTag.HTMLTagType.ENDTAG));

        }

        public string renderHTML(){
            string res = "";

            res += _mainTag.renderHTML();

            return res;
        }
    }
}
