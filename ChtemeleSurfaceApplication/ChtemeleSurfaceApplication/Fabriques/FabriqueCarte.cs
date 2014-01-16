using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.Carte_classes.Addons;
using ChtemeleSurfaceApplication.Carte_classes.Attaques;
using ChtemeleSurfaceApplication.Carte_classes;
using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Fabriques
{
    class FabriqueCarte
    {
        /*---- Cartes Addons ----*/
        //Antivirus
        public static Antivirus CreateAntivirus()
        {
            return new Antivirus();
        }

        //BrowserUpdate
        public static BrowserUpdate CreateBrowserUpdate()
        {
            return new BrowserUpdate();
        }

        //Cafe
        public static Cafe CreateCafe()
        {
            return new Cafe();
        }

        //CodeInspector
        public static CodeInspector CreateCodeInspector()
        {
            return new CodeInspector();
        }

        //CtrlF5
        public static CtrlF5 CreateCtrlF5()
        {
            return new CtrlF5();
        }

        /*---- Cartes Attaques ----*/
        //CrashBrowser
        public static CrashBrowser CreateCrashBrowser()
        {
            return new CrashBrowser();
        }

        //Error303
        public static Error303 CreateError303()
        {
            return new Error303();
        }

        //Error403
        public static Error403 CreateError403()
        {
            return new Error403();
        }

        //Error404
        public static Error404 CreateError404()
        {
            return new Error404();
        }

        //Freeze
        public static Freeze CreateFreeze()
        {
            return new Freeze();
        }

        //ManInTheMiddle
        public static ManInTheMiddle CreateManInTheMiddle()
        {
            return new ManInTheMiddle();
        }

        /*---- Cartes HTML ----*/
        //Balises ouvrante
        public static HTMLTagCarte CreateOpenH1()
        {
            return new HTMLTagCarte("h1", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenH2()
        {
            return new HTMLTagCarte("h2", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenP()
        {
            return new HTMLTagCarte("p", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenDIV()
        {
            return new HTMLTagCarte("div", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenBLOCKQUOTE()
        {
            return new HTMLTagCarte("blockquote", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenHEADER()
        {
            return new HTMLTagCarte("header", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenFOOTER()
        {
            return new HTMLTagCarte("footer", HtmlTag.HTMLTagType.OPENTAG);
        }
        public static HTMLTagCarte CreateOpenASIDE()
        {
            return new HTMLTagCarte("aside", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenSTRONG()
        {
            return new HTMLTagCarte("strong", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenEM()
        {
            return new HTMLTagCarte("em", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateOpenA()
        {
            return new HTMLTagCarte("a", HtmlTag.HTMLTagType.OPENTAG);
        }

        //Balises fermante
        public static HTMLTagCarte CreateEndH1()
        {
            return new HTMLTagCarte("h1", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndH2()
        {
            return new HTMLTagCarte("h2", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndP()
        {
            return new HTMLTagCarte("p", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndDIV()
        {
            return new HTMLTagCarte("div", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndBLOCKQUOTE()
        {
            return new HTMLTagCarte("blockquote", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndHEADER()
        {
            return new HTMLTagCarte("header", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndFOOTER()
        {
            return new HTMLTagCarte("footer", HtmlTag.HTMLTagType.ENDTAG);
        }
        public static HTMLTagCarte CreateEndASIDE()
        {
            return new HTMLTagCarte("aside", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndSTRONG()
        {
            return new HTMLTagCarte("strong", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndEM()
        {
            return new HTMLTagCarte("em", HtmlTag.HTMLTagType.ENDTAG);
        }

        public static HTMLTagCarte CreateEndA()
        {
            return new HTMLTagCarte("a", HtmlTag.HTMLTagType.ENDTAG);
        }

        //Balises simples
        public static HTMLTagCarte CreateBR()
        {
            return new HTMLTagCarte("br", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateHR()
        {
            return new HTMLTagCarte("hr", HtmlTag.HTMLTagType.OPENTAG);
        }

        public static HTMLTagCarte CreateIMG()
        {
            return new HTMLTagCarte("img", HtmlTag.HTMLTagType.OPENTAG);
        }

        /*---- Cartes Attributs ----*/
        // Href pour <a>
        public static HTMLAttributeCarte CreateHREF()
        {
            return new HTMLAttributeCarte("href", "");
        }

        // Src pour <img>
        public static HTMLAttributeCarte CreateSRC()
        {
            return new HTMLAttributeCarte("src", "");
        }

        // alt pour <img>
        public static HTMLAttributeCarte CreateALT()
        {
            return new HTMLAttributeCarte("alt", "");
        }

        // class
        public static HTMLAttributeCarte CreateCLASS()
        {
            return new HTMLAttributeCarte("alt", "");
        }

        // id
        public static HTMLAttributeCarte CreateID()
        {
            return new HTMLAttributeCarte("id", "");
        }

        // style
        public static HTMLAttributeCarte CreateSTYLE()
        {
            return new HTMLAttributeCarte("style", "");
        }

        // title
        public static HTMLAttributeCarte CreateTITLE()
        {
            return new HTMLAttributeCarte("title", "");
        }
    }
}
