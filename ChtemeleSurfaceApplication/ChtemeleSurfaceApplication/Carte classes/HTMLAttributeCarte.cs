using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Carte_classes
{
    class HTMLAttributeCarte : HTMLCarte
    {
        public string key;
        //public string value;  //Stocké dans textContent

        public HTMLAttributeCarte(string k, string v, int s)
            : base(s)
        {
            key = k;
            textcontent = v;
        }

        public override void onPlay()
        {
            throw new NotImplementedException();
        }

        public override void onValid()
        {
            if (HtmlElement._currentElement == null) return;

            Game_classes.Game.getInstance.getCurPlayer().addPoint(_score);

            HtmlElement._currentElement.attributes.Add(new HtmlTagAttribute(key, textcontent));

            SurfaceWindow1.getInstance.PageCode.ShowCode();
            SurfaceWindow1.getInstance.PageRendu.update();
        }

        public override void onDelete()
        {
            throw new NotImplementedException();
        }
    }
}
