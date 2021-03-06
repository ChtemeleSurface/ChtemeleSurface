﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Carte_classes
{
    public class HTMLTagCarte : HTMLCarte
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
        public string getTag() { return _tag; }

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
            Game_classes.Game.getInstance.getCurPlayer().lastCombo().addCard(this);
        }

        public override void onPlay() { }
        public override void onDelete() { }
    }
}