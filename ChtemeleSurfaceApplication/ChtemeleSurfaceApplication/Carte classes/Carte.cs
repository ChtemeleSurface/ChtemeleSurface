using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Fabriques;
using ChtemeleSurfaceApplication.Carte_classes.Addons;
using ChtemeleSurfaceApplication.Carte_classes.Attaques;
using ChtemeleSurfaceApplication.Carte_classes;
using ChtemeleSurfaceApplication.HTML_classes;
using ChtemeleSurfaceApplication.Modeles;

namespace ChtemeleSurfaceApplication
{
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
