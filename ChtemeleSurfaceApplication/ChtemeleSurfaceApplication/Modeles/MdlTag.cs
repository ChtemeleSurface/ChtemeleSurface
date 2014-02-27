using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Game_classes;
using ChtemeleSurfaceApplication.Carte_classes;
using ChtemeleSurfaceApplication.Fabriques;

namespace ChtemeleSurfaceApplication.Modeles
{
    //Classe qui gère le lien entre le tag, la carte et sa description.
    class CarteAssoc
    {
        // Constantes, enumérations         ======================================================================================================

        public static Dictionary<int, CarteAssoc> AssocTagCarte = new Dictionary<int, CarteAssoc>
            {
                // cartes addons
                {(int)MdlTag.TagCorrespondance.ANTIVIRUS,           new CarteAssoc((int)MdlTag.TagCorrespondance.ANTIVIRUS,             FabriqueCarte.CreateAntivirus(),        "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.BROWSER_UPDATE,      new CarteAssoc((int)MdlTag.TagCorrespondance.BROWSER_UPDATE,        FabriqueCarte.CreateBrowserUpdate(),    "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.CAFE,                new CarteAssoc((int)MdlTag.TagCorrespondance.CAFE,                  FabriqueCarte.CreateCafe(),             "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.CODE_INSPECTOR,      new CarteAssoc((int)MdlTag.TagCorrespondance.CODE_INSPECTOR,        FabriqueCarte.CreateCodeInspector(),    "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.CTRL_F5,             new CarteAssoc((int)MdlTag.TagCorrespondance.CTRL_F5,               FabriqueCarte.CreateCtrlF5(),           "ba", "ab")},
                // cartes attaques
                {(int)MdlTag.TagCorrespondance.CRASH_BROWSER,       new CarteAssoc((int)MdlTag.TagCorrespondance.CRASH_BROWSER,         FabriqueCarte.CreateCrashBrowser(),     "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ERROR_303,           new CarteAssoc((int)MdlTag.TagCorrespondance.ERROR_303,             FabriqueCarte.CreateError303(),         "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ERROR_403,           new CarteAssoc((int)MdlTag.TagCorrespondance.ERROR_403,             FabriqueCarte.CreateError403(),         "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ERROR_404,           new CarteAssoc((int)MdlTag.TagCorrespondance.ERROR_404,             FabriqueCarte.CreateError404(),         "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.FREEZE,              new CarteAssoc((int)MdlTag.TagCorrespondance.FREEZE,                FabriqueCarte.CreateFreeze(),           "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.MAN_IN_THE_MIDDLE,   new CarteAssoc((int)MdlTag.TagCorrespondance.MAN_IN_THE_MIDDLE,     FabriqueCarte.CreateManInTheMiddle(),   "ba", "ab")},
                // cartes ouvrantes
                {(int)MdlTag.TagCorrespondance.OPEN_H1,             new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_H1,               FabriqueCarte.CreateOpenH1(),           "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_H2,             new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_H2,               FabriqueCarte.CreateOpenH2(),           "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_P,              new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_P,                FabriqueCarte.CreateOpenP(),            "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_DIV,            new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_DIV,              FabriqueCarte.CreateOpenDIV(),          "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_BLOCKQUOTE,     new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_BLOCKQUOTE,       FabriqueCarte.CreateOpenBLOCKQUOTE(),   "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_HEADER,         new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_HEADER,           FabriqueCarte.CreateOpenHEADER(),       "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_FOOTER,         new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_FOOTER,           FabriqueCarte.CreateOpenFOOTER(),       "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_ASIDE,          new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_ASIDE,            FabriqueCarte.CreateOpenASIDE(),        "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_STRONG,         new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_STRONG,           FabriqueCarte.CreateOpenSTRONG(),       "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_EM,             new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_EM,               FabriqueCarte.CreateOpenEM(),           "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.OPEN_A,              new CarteAssoc((int)MdlTag.TagCorrespondance.OPEN_A,                FabriqueCarte.CreateOpenA(),            "ba", "ab")},
                // cartes fermantes
                {(int)MdlTag.TagCorrespondance.END_H1,              new CarteAssoc((int)MdlTag.TagCorrespondance.END_H1,                FabriqueCarte.CreateEndH1(),            "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_H2,              new CarteAssoc((int)MdlTag.TagCorrespondance.END_H2,                FabriqueCarte.CreateEndH2(),            "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_P,               new CarteAssoc((int)MdlTag.TagCorrespondance.END_P,                 FabriqueCarte.CreateEndP(),             "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_DIV,             new CarteAssoc((int)MdlTag.TagCorrespondance.END_DIV,               FabriqueCarte.CreateEndDIV(),           "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_BLOCKQUOTE,      new CarteAssoc((int)MdlTag.TagCorrespondance.END_BLOCKQUOTE,        FabriqueCarte.CreateEndBLOCKQUOTE(),    "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_HEADER,          new CarteAssoc((int)MdlTag.TagCorrespondance.END_HEADER,            FabriqueCarte.CreateEndHEADER(),        "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_FOOTER,          new CarteAssoc((int)MdlTag.TagCorrespondance.END_FOOTER,            FabriqueCarte.CreateEndFOOTER(),        "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_ASIDE,           new CarteAssoc((int)MdlTag.TagCorrespondance.END_ASIDE,             FabriqueCarte.CreateEndASIDE(),         "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_STRONG,          new CarteAssoc((int)MdlTag.TagCorrespondance.END_STRONG,            FabriqueCarte.CreateEndSTRONG(),        "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_EM,              new CarteAssoc((int)MdlTag.TagCorrespondance.END_EM,                FabriqueCarte.CreateEndEM(),            "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.END_A,               new CarteAssoc((int)MdlTag.TagCorrespondance.END_A,                 FabriqueCarte.CreateEndA(),             "ba", "ab")},
                // cartes simple
                {(int)MdlTag.TagCorrespondance.SINGLE_BR,           new CarteAssoc((int)MdlTag.TagCorrespondance.SINGLE_BR,             FabriqueCarte.CreateBR(),               "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.SINGLE_HR,           new CarteAssoc((int)MdlTag.TagCorrespondance.SINGLE_HR,             FabriqueCarte.CreateHR(),               "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.SINGLE_IMG,          new CarteAssoc((int)MdlTag.TagCorrespondance.SINGLE_IMG,            FabriqueCarte.CreateIMG(),              "ba", "ab")},
                // cartes attributs
                {(int)MdlTag.TagCorrespondance.ATTRIB_HREF,         new CarteAssoc((int)MdlTag.TagCorrespondance.ATTRIB_HREF,           FabriqueCarte.CreateHREF(),             "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ATTRIB_SRC,          new CarteAssoc((int)MdlTag.TagCorrespondance.ATTRIB_SRC,            FabriqueCarte.CreateSRC(),              "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ATTRIB_ALT,          new CarteAssoc((int)MdlTag.TagCorrespondance.ATTRIB_ALT,            FabriqueCarte.CreateALT(),              "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ATTRIB_CLASS,        new CarteAssoc((int)MdlTag.TagCorrespondance.ATTRIB_CLASS,          FabriqueCarte.CreateCLASS(),            "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ATTRIB_ID,           new CarteAssoc((int)MdlTag.TagCorrespondance.ATTRIB_ID,             FabriqueCarte.CreateID(),               "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ATTRIB_STYLE,        new CarteAssoc((int)MdlTag.TagCorrespondance.ATTRIB_STYLE,          FabriqueCarte.CreateSTYLE(),            "ba", "ab")},
                {(int)MdlTag.TagCorrespondance.ATTRIB_TITLE,        new CarteAssoc((int)MdlTag.TagCorrespondance.ATTRIB_TITLE,          FabriqueCarte.CreateTITLE(),            "ba", "ab")}
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
        public CarteAssoc(int t, Carte carte, string d, string k)
        {
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










    class MdlTag : Modele
    {
        // Constantes, enumérations         ======================================================================================================

        public enum TagCorrespondance
        {
            // Cartes Add-ons
            ANTIVIRUS           = 0x6D,
            BROWSER_UPDATE      = 0x67,
            CAFE                = 0x53,
            CODE_INSPECTOR      = 0x55,
            CTRL_F5             = 0x56,
            // Cartes Attaques
            CRASH_BROWSER       = 0x57,
            ERROR_303           = 0x59,
            ERROR_403           = 0x5B,
            ERROR_404           = 0x51,
            FREEZE              = 0x5E,
            MAN_IN_THE_MIDDLE   = 0x5F,
            // Cartes Balises Ouvrantes
            OPEN_H1             = 0x65,
            OPEN_H2             = 0x69,
            OPEN_P              = 0x6A,
            OPEN_DIV            = 0x6B,
            OPEN_BLOCKQUOTE     = 0x6F,
            OPEN_HEADER         = 0x73,
            OPEN_FOOTER         = 0x75,
            OPEN_ASIDE          = 0x76,
            OPEN_STRONG         = 0x77,
            OPEN_EM             = 0x79,
            OPEN_A              = 0x7A,
            // Cartes Balises Fermantes
            END_H1              = 0x7B,
            END_H2              = 0x7D,
            END_P               = 0x7E,
            END_DIV             = 0x7F,
            END_BLOCKQUOTE      = 0x9B,
            END_HEADER          = 0x9D,
            END_FOOTER          = 0x9E,
            END_ASIDE           = 0x9F,
            END_STRONG          = 0xB7,
            END_EM              = 0xB9,
            END_A               = 0xBB,
            // Cartes Balises Simples
            SINGLE_BR           = 0xBD,
            SINGLE_HR           = 0xBE,
            SINGLE_IMG          = 0xBF,
            // Cartes Attributs
            ATTRIB_HREF         = 0xD7,
            ATTRIB_SRC          = 0xD9,
            ATTRIB_ALT          = 0xDB,
            ATTRIB_CLASS        = 0xDD,
            ATTRIB_ID           = 0xDF,
            ATTRIB_STYLE        = 0xE5,
            ATTRIB_TITLE        = 0xE6
        }

        public class InfoMessage
        {
            public const string MULTICARD           = "Plusieurs cartes sur la table !";
            public const string PLAYED              = "Carte jouée, veuillez la défausser.";
            public const string GAME_NOT_STARTED    = "La partie n'est pas encore commencée.";
        }

        private static int nbCards = 0;

        // Variables membres                ======================================================================================================

        private int _tag;
        private Carte _card;
        private Carte.TypeCarte _typeCard;
        //private Player _activePlayer;     // On s'en sert pas, normalement, mais je le laisse au cas où j'me sois gourré.
        public Player targetPlayer;
        public string textContent;
        private bool _played = false;
        private bool _multicard = false;

        //Booldées d'affichage de widgets
        private bool _hasTextEdit = false;
        private bool _hasImageSelector = false;
        private bool _hasPlayerSelector = false;

        // Constructeurs                    ======================================================================================================

        public MdlTag(int tag)
            : base()
        {
            _tag = tag;
            newTag();
            computeMulticard();
        }

        // Accesseurs / Mutateurs           ======================================================================================================

        public bool isMulticard() { return _multicard; }
        public bool hasTextEdit() { return _hasTextEdit; }
        public bool hasImageSelector() { return _hasImageSelector; }
        public bool hasPlayerSelector() { return _hasPlayerSelector; }

        // Fonctionnalités                  ======================================================================================================

        // Nouveau tag détecté et validé (on est en droit de le poser et il est seul sur la table)
        public void onTag()
        {
            //On récupère la carte correspondante
            _card = CarteAssoc.AssocTagCarte[_tag].getCarte();

            //On détecte le type de la carte
            _typeCard = Carte.TypeCarte.CARD;
            if (_card is HTMLTagCarte) _typeCard = Carte.TypeCarte.HTML_TAG_CARD;
            else if (_card is HTMLAttributeCarte) _typeCard = Carte.TypeCarte.HTML_ATTRIB_CARD;
            else if (_card is AddonCarte) _typeCard = Carte.TypeCarte.ADDON_CARD;
            else if (_card is AttaqueCarte) _typeCard = Carte.TypeCarte.ATTACK_CARD;

            //On détermine le layout à afficher
            if ((_typeCard == Carte.TypeCarte.HTML_TAG_CARD && ((HTMLTagCarte)_card).getTagtype() == HTML_classes.HtmlTag.HTMLTagType.OPENTAG) || _typeCard == Carte.TypeCarte.HTML_ATTRIB_CARD)
                _hasTextEdit = true;
            if (_typeCard == Carte.TypeCarte.ATTACK_CARD)
                _hasPlayerSelector = true;
            if (_tag == (int)TagCorrespondance.ATTRIB_SRC)
                _hasImageSelector = true;
        }

        public void validerCarte()
        {
            if (!isPlayable()) return;

            //On configure la carte
            if (_typeCard == Carte.TypeCarte.ADDON_CARD || _typeCard == Carte.TypeCarte.ATTACK_CARD)
            {
                ((EventCarte)_card).target = targetPlayer;
            }
            else if (_typeCard == Carte.TypeCarte.HTML_TAG_CARD || _typeCard == Carte.TypeCarte.HTML_ATTRIB_CARD)
            {
                ((HTMLCarte)_card).textcontent = textContent;
            }
            else if (_tag == (int)TagCorrespondance.ATTRIB_SRC)
            {
                //obtenir le chemin de l'image
                ((HTMLAttributeCarte)_card).textcontent = textContent;
            }

            _card.onValid();
            _played = true;
        }

        public void computeMulticard()
        {
            _multicard = nbCards > 1;
        }

        public string getInfoMessage()
        {
            if (!_game.getGameStarted()) return InfoMessage.GAME_NOT_STARTED;
            else if (_multicard) return InfoMessage.MULTICARD;
            else if (_played) return InfoMessage.PLAYED;

            else return "";
        }

        public bool isPlayable()
        {
            return (!_played
                && !_multicard
                && _game.getGameStarted());
        }

        public void setTargetPlayer(int position)
        {
            switch (position)
            {
                case Game_classes.Player.NORD:
                    targetPlayer = _game.joueurN;
                    break;
                case Game_classes.Player.SUD:
                    targetPlayer = _game.joueurS;
                    break;
                case Game_classes.Player.EST:
                    targetPlayer = _game.joueurE;
                    break;
                case Game_classes.Player.OUEST:
                    targetPlayer = _game.joueurO;
                    break;
            }
        }

        public void newTag() { nbCards++; }
        public void loseTag() { nbCards--; }

    }
}
