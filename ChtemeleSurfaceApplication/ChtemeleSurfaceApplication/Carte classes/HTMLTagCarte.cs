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
        private HtmlTag.HTMLTagType _tagtype;

        public HTMLTagCarte(string tag, HtmlTag.HTMLTagType type, int score, bool textEdit)
            : base(score)
        {
            _tag = tag;
            _tagtype = type;
            _textEdit = textEdit;
        }

        public HtmlTag.HTMLTagType getTagtype() { return _tagtype; }

        public override void onPlay()
        {
            throw new NotImplementedException();
        }

        public override void onValid()
        {

            if (_tagtype == HtmlTag.HTMLTagType.OPENTAG)
            {
                HtmlElement._currentElement = new HtmlElement(_tag);
                HtmlElement._currentElement.addContent(new HtmlText(textcontent));
                Game_classes.Game.getInstance.getPage().bodyTag().addContent(HtmlElement._currentElement);
            }
            else 
            {
                if (HtmlElement._currentElement == null) return;
                if (HtmlElement._currentElement.getTagname() == _tag)
                    HtmlElement._currentElement.closeTag();

            }

            Game_classes.Game.getInstance.getCurPlayer().addPoint(_score);

            SurfaceWindow1.getInstance.PageCode.ShowCode();
            SurfaceWindow1.getInstance.PageRendu.update();
        }

        public override void onDelete()
        {
            throw new NotImplementedException();
        }
    }
}