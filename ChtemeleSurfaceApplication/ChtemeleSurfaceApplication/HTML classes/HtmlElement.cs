using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlElement : HtmlTagContent
    {
        private string _name;
        private bool _isCorrect;
        public List<HtmlTagAttribute> attributes;
        public List<HtmlTagContent> tagContent;
        private int _score;

        public HtmlElement(string name)
        {
            _name = name;
            _isCorrect = false;
            _score = 0;
            attributes = new List<HtmlTagAttribute>();
            tagContent = new List<HtmlTagContent>();
        }

        public HtmlElement()
        {
            // TODO: Complete member initialization
        }


        //renvoie une string du rendu HTML de l'élément
        public override string renderHTML()
        {
            string res = "";
            string resattr = "";
            if (tagContent.Count == 0) return res;

            //attributs
            if (attributes.Count > 0)
            {
                foreach (HtmlTagAttribute attr in attributes)
                {
                    resattr += " ";
                    resattr += attr.RenderHTML();
                }
            }

            //balise ouvrante
            //string opentag = tagContent.ElementAt(0).renderHTML(resattr);

            foreach (HtmlTagContent elem in tagContent)
            {
                res += elem.renderHTML();
            }

            return res;
        }


        public override string renderHTML(string attribs)
        {
            throw new NotImplementedException();
        }
    }
}
