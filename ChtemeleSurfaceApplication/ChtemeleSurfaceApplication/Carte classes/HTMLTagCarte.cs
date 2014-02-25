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

        public HTMLTagCarte(string tag, HtmlTag.HTMLTagType type, int score, bool textEdit)
        {
            _tag = tag;
            _type = type;
            _score = score;
            _textEdit = textEdit;

            _type = HtmlTag.HTMLTagType.OPENTAG;
        }

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