using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Game_classes;
using ChtemeleSurfaceApplication.Carte_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
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
            if (_typeCard == Carte.TypeCarte.HTML_TAG_CARD || _typeCard == Carte.TypeCarte.HTML_TAG_CARD)
                _hasTextEdit = true;
            if (_typeCard == Carte.TypeCarte.ATTACK_CARD)
                _hasPlayerSelector = true;
            if (_tag == (int)TagCorrespondance.ATTRIB_SRC)
                _hasImageSelector = true;
        }

        public void validerCarte()
        {
            if (!isPlayable()) return;

            _card.onValid();
            _played = true;
        }

        public void computeMulticard()
        {
            _multicard = nbCards > 1;
        }

        public string getInfoMessage()
        {
            if (_multicard) return InfoMessage.MULTICARD;
            else if (_played) return InfoMessage.PLAYED;

            else return "";
        }

        public bool isPlayable()
        {
            return (!_played
                && !_multicard
                && _game.getGameStarted());
        }

        public void newTag() { nbCards++; }
        public void loseTag() { nbCards--; }

    }
}
