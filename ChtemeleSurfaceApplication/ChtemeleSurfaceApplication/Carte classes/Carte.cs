using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Fabriques;

namespace ChtemeleSurfaceApplication
{
    abstract class Carte
    {

        public abstract void onPlay();
        public abstract void onValid();

        //pointeur fonction
        public delegate Carte generateCarte();

        public static Dictionary<int, generateCarte> AssocTagCarte;

        public Carte()
        {
            //association des tags avec les cartes
            AssocTagCarte = new Dictionary<int, generateCarte>();
            // cartes addons
            AssocTagCarte.Add(0x6D, FabriqueCarte.CreateAntivirus);
            AssocTagCarte.Add(0x67, FabriqueCarte.CreateBrowserUpdate);
            AssocTagCarte.Add(0x53, FabriqueCarte.CreateCafe);
            AssocTagCarte.Add(0x55, FabriqueCarte.CreateCodeInspector);
            AssocTagCarte.Add(0x56, FabriqueCarte.CreateCtrlF5);
            // cartes attaques
            AssocTagCarte.Add(0x57, FabriqueCarte.CreateCrashBrowser);
            AssocTagCarte.Add(0x59, FabriqueCarte.CreateError303);
            AssocTagCarte.Add(0x5B, FabriqueCarte.CreateError403);
            AssocTagCarte.Add(0x5D, FabriqueCarte.CreateError404);
            AssocTagCarte.Add(0x5E, FabriqueCarte.CreateFreeze);
            AssocTagCarte.Add(0x5F, FabriqueCarte.CreateManInTheMiddle);
            // cartes ouvrantes
            AssocTagCarte.Add(0x65, FabriqueCarte.CreateOpenH1);
            AssocTagCarte.Add(0x69, FabriqueCarte.CreateOpenH2);
            AssocTagCarte.Add(0x6A, FabriqueCarte.CreateOpenP);
            AssocTagCarte.Add(0x6B, FabriqueCarte.CreateOpenDIV);
            AssocTagCarte.Add(0x6F, FabriqueCarte.CreateOpenBLOCKQUOTE);
            AssocTagCarte.Add(0x73, FabriqueCarte.CreateOpenHEADER);
            AssocTagCarte.Add(0x75, FabriqueCarte.CreateOpenFOOTER);
            AssocTagCarte.Add(0x76, FabriqueCarte.CreateOpenASIDE);
            AssocTagCarte.Add(0x77, FabriqueCarte.CreateOpenSTRONG);
            AssocTagCarte.Add(0x79, FabriqueCarte.CreateOpenEM);
            AssocTagCarte.Add(0x7A, FabriqueCarte.CreateOpenA);
            // cartes fermantes
            AssocTagCarte.Add(0x7B, FabriqueCarte.CreateEndH1);
            AssocTagCarte.Add(0x7D, FabriqueCarte.CreateEndH2);
            AssocTagCarte.Add(0x7E, FabriqueCarte.CreateEndP);
            AssocTagCarte.Add(0x7F, FabriqueCarte.CreateEndDIV);
            AssocTagCarte.Add(0x9B, FabriqueCarte.CreateEndBLOCKQUOTE);
            AssocTagCarte.Add(0x9D, FabriqueCarte.CreateEndHEADER);
            AssocTagCarte.Add(0x9E, FabriqueCarte.CreateEndFOOTER);
            AssocTagCarte.Add(0x9F, FabriqueCarte.CreateEndASIDE);
            AssocTagCarte.Add(0xB7, FabriqueCarte.CreateEndSTRONG);
            AssocTagCarte.Add(0xB9, FabriqueCarte.CreateEndEM);
            AssocTagCarte.Add(0xBB, FabriqueCarte.CreateEndA);
            // cartes simple
            AssocTagCarte.Add(0xBD, FabriqueCarte.CreateBR);
            AssocTagCarte.Add(0xBE, FabriqueCarte.CreateHR);
            AssocTagCarte.Add(0xBF, FabriqueCarte.CreateIMG);
            // cartes attributs
            AssocTagCarte.Add(0xD7, FabriqueCarte.CreateHREF);
            AssocTagCarte.Add(0xD9, FabriqueCarte.CreateSRC);
            AssocTagCarte.Add(0xDB, FabriqueCarte.CreateALT);
            AssocTagCarte.Add(0xDD, FabriqueCarte.CreateCLASS);
            AssocTagCarte.Add(0xDF, FabriqueCarte.CreateID);
            AssocTagCarte.Add(0xE5, FabriqueCarte.CreateSTYLE);
            AssocTagCarte.Add(0xE6, FabriqueCarte.CreateTITLE);
        }

    }
}
