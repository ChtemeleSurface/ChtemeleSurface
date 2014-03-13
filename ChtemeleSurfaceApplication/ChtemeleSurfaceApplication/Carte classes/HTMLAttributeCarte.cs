using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.Carte_classes
{
    public class HTMLAttributeCarte : HTMLCarte
    {
        public string key;
        //public string value;  //Stocké dans textContent

        public HTMLAttributeCarte(string k, string v, int s)
            : base(s)
        {
            key = k;
            textcontent = v;
        }

        public override void onValid()
        {
            if (HtmlElement._currentElement == null) return;

            //On ajoute l'attribut à la balise courante
            HtmlElement._currentElement.attributes.Add(new HtmlTagAttribute(key, textcontent));

            //On donne des points au joueur
            Game_classes.Game.getInstance.getCurPlayer().addPoint(_score);
            //On met à joour la combo du joueur
            Game_classes.Game.getInstance.getCurPlayer().lastCombo().addCard(this);

            //On met à jour l'affichage (TODO : ça ne se fait pas ici normalement)
            //SurfaceWindow1.getInstance.PageCode.ShowCode();
            //SurfaceWindow1.getInstance.PageRendu.update();
        }

        public override void onPlay() { }
        public override void onDelete() { }
    }
}
