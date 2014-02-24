using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Carte_classes
{
    class HTMLTagCarte : HTMLCarte
    {
        private string _tag;
        private HtmlTag.HTMLTagType _type;
        private int _score;

        public static Dictionary<AvailableTags, int> ValeurTags;

        public HTMLTagCarte(string tag, HtmlTag.HTMLTagType type, int score)
        {
            _tag = tag;
            _type = type;
            _score = score;

            //valeur balises ouvrantes
            ValeurTags = new Dictionary<AvailableTags, int>();
            ValeurTags.Add(AvailableTags.O_H1,          2);
            ValeurTags.Add(AvailableTags.O_H2,          2);
            ValeurTags.Add(AvailableTags.O_P,           2);
            ValeurTags.Add(AvailableTags.O_DIV,         2);
            ValeurTags.Add(AvailableTags.O_BLOCKQUOTE,  2);
            ValeurTags.Add(AvailableTags.O_HEADER,      4);
            ValeurTags.Add(AvailableTags.O_FOOTER,      4);
            ValeurTags.Add(AvailableTags.O_ASIDE,       4);
            ValeurTags.Add(AvailableTags.O_STRONG,      6);
            ValeurTags.Add(AvailableTags.O_EM,          6);
            ValeurTags.Add(AvailableTags.O_A,           8);
            //valeur balises fermantes
            ValeurTags.Add(AvailableTags.E_H1,          2);
            ValeurTags.Add(AvailableTags.E_H2,          2);
            ValeurTags.Add(AvailableTags.E_P,           2);
            ValeurTags.Add(AvailableTags.E_DIV,         2);
            ValeurTags.Add(AvailableTags.E_BLOCKQUOTE,  2);
            ValeurTags.Add(AvailableTags.E_HEADER,      4);
            ValeurTags.Add(AvailableTags.E_FOOTER,      4);
            ValeurTags.Add(AvailableTags.E_ASIDE,       4);
            ValeurTags.Add(AvailableTags.E_STRONG,      6);
            ValeurTags.Add(AvailableTags.E_EM,          6);
            ValeurTags.Add(AvailableTags.E_A,           8);
            //valeur balises simples
            ValeurTags.Add(AvailableTags.S_BR,          4);
            ValeurTags.Add(AvailableTags.S_HR,          6);
            ValeurTags.Add(AvailableTags.S_IMG,         8);

            _type = HtmlTag.HTMLTagType.OPENTAG; 
        }

        public enum AvailableTags
        {
            //balises ouvrantes
            O_H1,
            O_H2,
            O_P,
            O_DIV,
            O_BLOCKQUOTE,
            O_HEADER,
            O_FOOTER,
            O_ASIDE,
            O_STRONG,
            O_EM,
            O_A,
            //balises fermantes
            E_H1,
            E_H2,
            E_P,
            E_DIV,
            E_BLOCKQUOTE,
            E_HEADER,
            E_FOOTER,
            E_ASIDE,
            E_STRONG,
            E_EM,
            E_A,
            //balises simples
            S_BR,
            S_HR,
            S_IMG

        };


        public override void onPlay()
        {
            throw new NotImplementedException();
        }

        public override void onValid()
        {
            Game_classes.Game.getInstance.getCurPlayer().addPoint(_score);
        }

        public override void onDelete()
        {
            throw new NotImplementedException();
        }
    }
}