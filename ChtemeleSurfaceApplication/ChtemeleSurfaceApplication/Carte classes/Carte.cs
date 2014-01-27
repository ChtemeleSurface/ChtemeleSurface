using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Fabriques;

namespace ChtemeleSurfaceApplication
{
    class CarteAssoc
    {
        public delegate Carte generateCarte();

        public int tag;
        public string descriptionFilename;
        public string keyword;
        public generateCarte myFunc;

        public CarteAssoc(int t, generateCarte g, string d, string k){
            tag = t;
            myFunc = g;
            descriptionFilename = d;
            keyword = k;
        }

        //association des tags avec les cartes
        public static Dictionary<int, generateCarte> AssocTagCarte = new Dictionary<int, generateCarte>
        {
            // cartes addons
            {0x6D, FabriqueCarte.CreateAntivirus},
            {0x67, FabriqueCarte.CreateBrowserUpdate},
            {0x53, FabriqueCarte.CreateCafe},
            {0x55, FabriqueCarte.CreateCodeInspector},
            {0x56, FabriqueCarte.CreateCtrlF5},
            // cartes attaques
            {0x57, FabriqueCarte.CreateCrashBrowser},
            {0x59, FabriqueCarte.CreateError303},
            {0x5B, FabriqueCarte.CreateError403},
            {0x51, FabriqueCarte.CreateError404},
            {0x5E, FabriqueCarte.CreateFreeze},
            {0x5F, FabriqueCarte.CreateManInTheMiddle},
            // cartes ouvrantes
            {0x65, FabriqueCarte.CreateOpenH1},
            {0x69, FabriqueCarte.CreateOpenH2},
            {0x6A, FabriqueCarte.CreateOpenP},
            {0x6B, FabriqueCarte.CreateOpenDIV},
            {0x6F, FabriqueCarte.CreateOpenBLOCKQUOTE},
            {0x73, FabriqueCarte.CreateOpenHEADER},
            {0x75, FabriqueCarte.CreateOpenFOOTER},
            {0x76, FabriqueCarte.CreateOpenASIDE},
            {0x77, FabriqueCarte.CreateOpenSTRONG},
            {0x79, FabriqueCarte.CreateOpenEM},
            {0x7A, FabriqueCarte.CreateOpenA},
            // cartes fermantes
            {0x7B, FabriqueCarte.CreateEndH1},
            {0x7D, FabriqueCarte.CreateEndH2},
            {0x7E, FabriqueCarte.CreateEndP},
            {0x7F, FabriqueCarte.CreateEndDIV},
            {0x9B, FabriqueCarte.CreateEndBLOCKQUOTE},
            {0x9D, FabriqueCarte.CreateEndHEADER},
            {0x9E, FabriqueCarte.CreateEndFOOTER},
            {0x9F, FabriqueCarte.CreateEndASIDE},
            {0xB7, FabriqueCarte.CreateEndSTRONG},
            {0xB9, FabriqueCarte.CreateEndEM},
            {0xBB, FabriqueCarte.CreateEndA},
            // cartes simple
            {0xBD, FabriqueCarte.CreateBR},
            {0xBE, FabriqueCarte.CreateHR},
            {0xBF, FabriqueCarte.CreateIMG},
            // cartes attributs
            {0xD7, FabriqueCarte.CreateHREF},
            {0xD9, FabriqueCarte.CreateSRC},
            {0xDB, FabriqueCarte.CreateALT},
            {0xDD, FabriqueCarte.CreateCLASS},
            {0xDF, FabriqueCarte.CreateID},
            {0xE5, FabriqueCarte.CreateSTYLE},
            {0xE6, FabriqueCarte.CreateTITLE}
        };

    }

    abstract class Carte
    {

        public abstract void onPlay();
        public abstract void onValid();
        public abstract void onDelete();

        private string _description;


        //pointeur fonction
        

        

        public Carte()
        {
            loadDescription();
        }

        public void loadDescription()
        {

        }
    }
}
