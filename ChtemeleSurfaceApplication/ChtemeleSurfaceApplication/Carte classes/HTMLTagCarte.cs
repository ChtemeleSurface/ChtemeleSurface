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
        }

        public override void onPlay()
        {
            throw new NotImplementedException();
        }

        public override void onValid()
        {
            Game_classes.Game.getInstance.getCurPlayer().addPoint(_score);

            if(_type == HtmlTag.HTMLTagType.OPENTAG)
            {
                HtmlElement._currentElement = new HtmlElement(_tag);
                HtmlElement._currentElement.addContent(new HtmlText(_text));
                Game_classes.Game.getInstance.getPage().bodyTag().addContent(HtmlElement._currentElement);
            }
            else 
            {
                if (HtmlElement._currentElement == null) return;
                if (HtmlElement._currentElement.getTagname() == _tag)
                    HtmlElement._currentElement.closeTag();

            }
            SurfaceWindow1.getInstance.PageCode.ShowCode();
            SurfaceWindow1.getInstance.PageRendu.update();
        }

        public override void onDelete()
        {
            throw new NotImplementedException();
        }
    }
}