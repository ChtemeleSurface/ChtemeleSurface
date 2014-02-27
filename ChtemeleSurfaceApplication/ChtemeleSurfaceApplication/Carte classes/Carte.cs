using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Fabriques;
using ChtemeleSurfaceApplication.Carte_classes.Addons;
using ChtemeleSurfaceApplication.Carte_classes.Attaques;
using ChtemeleSurfaceApplication.Carte_classes;
using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication
{
    //Classe qui gère le lien entre le tag, la carte et sa description.
    class CarteAssoc
    {
        // Constantes, enumérations         ======================================================================================================

        public static Dictionary<int, CarteAssoc> AssocTagCarte = new Dictionary<int, CarteAssoc>
            {
                // cartes addons
                {0x6D, new CarteAssoc(0x6D, FabriqueCarte.CreateAntivirus(), "ba", "ab")},
                {0x67, new CarteAssoc(0x67, FabriqueCarte.CreateBrowserUpdate(), "ba", "ab")},
                {0x53, new CarteAssoc(0x53, FabriqueCarte.CreateCafe(), "ba", "ab")},
                {0x55, new CarteAssoc(0x55, FabriqueCarte.CreateCodeInspector(), "ba", "ab")},
                {0x56, new CarteAssoc(0x56, FabriqueCarte.CreateCtrlF5(), "ba", "ab")},
                // cartes attaques
                {0x57, new CarteAssoc(0x57, FabriqueCarte.CreateCrashBrowser(), "ba", "ab")},
                {0x59, new CarteAssoc(0x59, FabriqueCarte.CreateError303(), "ba", "ab")},
                {0x5B, new CarteAssoc(0x5B, FabriqueCarte.CreateError403(), "ba", "ab")},
                {0x51, new CarteAssoc(0x51, FabriqueCarte.CreateError404(), "ba", "ab")},
                {0x5E, new CarteAssoc(0x5E, FabriqueCarte.CreateFreeze(), "ba", "ab")},
                {0x5F, new CarteAssoc(0x5F, FabriqueCarte.CreateManInTheMiddle(), "ba", "ab")},
                // cartes ouvrantes
                {0x65, new CarteAssoc(0x65, FabriqueCarte.CreateOpenH1(), "ba", "ab")},
                {0x69, new CarteAssoc(0x69, FabriqueCarte.CreateOpenH2(), "ba", "ab")},
                {0x6A, new CarteAssoc(0x6A, FabriqueCarte.CreateOpenP(), "ba", "ab")},
                {0x6B, new CarteAssoc(0x6B, FabriqueCarte.CreateOpenDIV(), "ba", "ab")},
                {0x6F, new CarteAssoc(0x6F, FabriqueCarte.CreateOpenBLOCKQUOTE(), "ba", "ab")},
                {0x73, new CarteAssoc(0x73, FabriqueCarte.CreateOpenHEADER(), "ba", "ab")},
                {0x75, new CarteAssoc(0x75, FabriqueCarte.CreateOpenFOOTER(), "ba", "ab")},
                {0x76, new CarteAssoc(0x76, FabriqueCarte.CreateOpenASIDE(), "ba", "ab")},
                {0x77, new CarteAssoc(0x77, FabriqueCarte.CreateOpenSTRONG(), "ba", "ab")},
                {0x79, new CarteAssoc(0x79, FabriqueCarte.CreateOpenEM(), "ba", "ab")},
                {0x7A, new CarteAssoc(0x7A, FabriqueCarte.CreateOpenA(), "ba", "ab")},
                // cartes fermantes
                {0x7B, new CarteAssoc(0x7B, FabriqueCarte.CreateEndH1(), "ba", "ab")},
                {0x7D, new CarteAssoc(0x7D, FabriqueCarte.CreateEndH2(), "ba", "ab")},
                {0x7E, new CarteAssoc(0x7E, FabriqueCarte.CreateEndP(), "ba", "ab")},
                {0x7F, new CarteAssoc(0x7F, FabriqueCarte.CreateEndDIV(), "ba", "ab")},
                {0x9B, new CarteAssoc(0x9B, FabriqueCarte.CreateEndBLOCKQUOTE(), "ba", "ab")},
                {0x9D, new CarteAssoc(0x9D, FabriqueCarte.CreateEndHEADER(), "ba", "ab")},
                {0x9E, new CarteAssoc(0x9E, FabriqueCarte.CreateEndFOOTER(), "ba", "ab")},
                {0x9F, new CarteAssoc(0x9F, FabriqueCarte.CreateEndASIDE(), "ba", "ab")},
                {0xB7, new CarteAssoc(0xB7, FabriqueCarte.CreateEndSTRONG(), "ba", "ab")},
                {0xB9, new CarteAssoc(0xB9, FabriqueCarte.CreateEndEM(), "ba", "ab")},
                {0xBB, new CarteAssoc(0xBB, FabriqueCarte.CreateEndA(), "ba", "ab")},
                // cartes simple
                {0xBD, new CarteAssoc(0xBD, FabriqueCarte.CreateBR(), "ba", "ab")},
                {0xBE, new CarteAssoc(0xBE, FabriqueCarte.CreateHR(), "ba", "ab")},
                {0xBF, new CarteAssoc(0xBF, FabriqueCarte.CreateIMG(), "ba", "ab")},
                // cartes attributs
                {0xD7, new CarteAssoc(0xD7, FabriqueCarte.CreateHREF(), "ba", "ab")},
                {0xD9, new CarteAssoc(0xD9, FabriqueCarte.CreateSRC(), "ba", "ab")},
                {0xDB, new CarteAssoc(0xDB, FabriqueCarte.CreateALT(), "ba", "ab")},
                {0xDD, new CarteAssoc(0xDD, FabriqueCarte.CreateCLASS(), "ba", "ab")},
                {0xDF, new CarteAssoc(0xDF, FabriqueCarte.CreateID(), "ba", "ab")},
                {0xE5, new CarteAssoc(0xE5, FabriqueCarte.CreateSTYLE(), "ba", "ab")},
                {0xE6, new CarteAssoc(0xE6, FabriqueCarte.CreateTITLE(), "ba", "ab")}
            };

        public delegate Carte generateCarte();


        // Variables membres                ======================================================================================================

        public int tag;
        public string descriptionFilename;
        public string keyword;
        public Carte card;

        // Constructeurs                    ======================================================================================================

        // Paramètres : t tag
        //              delegate de construction
        //              d uri du fichier de description
        //              k mot-clé de la carte
        public CarteAssoc(int t, Carte carte, string d, string k){
            tag = t;
            descriptionFilename = d;
            keyword = k;
            card = carte;
        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public Carte getCarte()
        {
            return card;
        }
    }








    abstract class Carte
    {
        // Constantes, enumérations         ======================================================================================================

        public enum TypeCarte
        {
            HTML_TAG_CARD,
            HTML_ATTRIB_CARD,
            ATTACK_CARD,
            ADDON_CARD,
            CARD    // Celui-ci est abstrait, il ne doit pas être utilisé hors de la classe Carte.
        }

        // Variables membres                ======================================================================================================

        protected string _description;
        protected bool _textEdit;
        protected bool _imageEdit;
        protected TypeCarte _type;

        // Constructeurs                    ======================================================================================================

        public Carte()
        {
            loadDescription();
            _textEdit = false;
            _imageEdit = false;
            _type = TypeCarte.CARD;
        }

        // Fonctionnalités                  ======================================================================================================

        public abstract void onPlay();
        public abstract void onValid();
        public abstract void onDelete();
        
        public void loadDescription()
        {

        }


        // Accesseurs / Mutateurs           ======================================================================================================
        public bool getTextEdit() { return _textEdit; }
        public bool getImageEdit() { return _imageEdit; }
    }
}
