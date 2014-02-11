using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ChtemeleSurfaceApplication.HTML_classes
{
    class HtmlPage
    {
        private HtmlElement _mainTag;

        //paramètres de génération HTML
        public static int indentLevel = 0;
        public static int indentSize = 4;
        public static int computedIndentChanges = 0;

        public HtmlPage()
        {
            _mainTag = new HtmlElement("body");
            _mainTag.closeTag();

            HtmlElement _baliseH1 = new HtmlElement("h1");
                _baliseH1.addContent(new HtmlText("Ceci est un putain de titre !"));
                _baliseH1.attributes.Add(new HtmlTagAttribute("class", "montitre"));
                _baliseH1.closeTag();
                _mainTag.addContent(_baliseH1);

            HtmlElement _baliseH2 = new HtmlElement("h2");
                _baliseH2.addContent(new HtmlText("Et ça, c'est un péripatéticienne de sous-titre !"));
                _baliseH2.closeTag();
                _mainTag.addContent(_baliseH2);

            HtmlElement _baliseP = new HtmlElement("p");
                _baliseP.addContent(new HtmlText("Lorem Ipsum et de toute façon je met le texte que je veux tout le monde s'en calice !"));
                HtmlElement _baliseBR = new HtmlElement("br");
                    _baliseP.addContent(_baliseBR);
                _baliseP.addContent(new HtmlText("Voilà, d'abord !!"));
                _baliseP.closeTag();
                _mainTag.addContent(_baliseP);

            HtmlElement _baliseDIV1 = new HtmlElement("div");
            _baliseDIV1.attributes.Add(new HtmlTagAttribute("id", "DTC"));
                _baliseDIV1.closeTag();
                _mainTag.addContent(_baliseDIV1);

                HtmlElement _baliseDIV2 = new HtmlElement("div");
                    _baliseDIV2.closeTag();
                    _baliseDIV1.addContent(_baliseDIV2);

                HtmlElement _baliseH3 = new HtmlElement("h3");
                    _baliseH3.addContent(new HtmlText("Et ça, c'est un péripatéticienne de sous-sous-titre !"));
                    _baliseH3.closeTag();
                    _baliseDIV2.addContent(_baliseH3);


        }

        public string renderHTML(){
            string res = "";

            res += _mainTag.renderHTML();

            res = autoIndent(res);

            return res;
        }

        public string autoIndent(string res)
        {
            indentLevel = 1;

            //On parcout toutes les balises et les retours à la ligne de la séquence.


            MatchEvaluator evalLine = new MatchEvaluator(fetchLine);

            string linePattern = @"\n+(?<line>.*)";

            try
            {
                res = Regex.Replace(res, linePattern, evalLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Match m = Regex. (res, @"^</?(\w+)");

            /*
            string[] lines = res.Split('\n');

            //on parcours toutes les lignes du code HTML
            for (int i = 0; i < lines.Length; ++i)
            {
                lines[i] = new String(' ', indentSize * indentLevel) + lines[i];

                indentCount = 0;
                if (lines[i].Length == 0) continue;
                //on doit d'abord déterminer si la ligne commence par un tag.
                Match m = Regex.Match(lines[i], @"^</?(\w+)");
                if (m.Success)
                {
                    
                    string tag = m.Value.Substring(1);
                    Console.Write(tag);
                    if (!HtmlElement.multiLineTags.Exists(v => v == tag) && !HtmlElement.singleTags.Exists(v => v == tag))
                    {
                        if (tag.ElementAt(0) == '/')
                            indentCount--;
                        else
                            indentCount++;
                    }
                }
                
                indentLevel += indentCount;
                
            }

            res = String.Join("\n", lines);
            */


            return res;
        }

        private static string fetchIndentItem(Match item)
        {
            string s = item.ToString();

            if (Regex.IsMatch(s, @"^<(\w+)(\s[^>]*)?>$"))       //balise ouvrante
            {
                if(HtmlElement.singleTags.Exists(v => v == item.Groups["tagname"].ToString())){
                    //balise simple
                }
                else
                    computedIndentChanges++;
            }
            else //if (Regex.IsMatch(s, @"^</\w+>$"))       //balise fermante seule
            {
                computedIndentChanges--;
            }

            return s;
        }

        private static string fetchLine(Match item)
        {
            computedIndentChanges = 0;
            string s = item.ToString();

            string pattern = @"</?(?<tagname>\w+)(\s[^>]*)?>";
            MatchEvaluator evalElem = new MatchEvaluator(fetchIndentItem);
            
            try
            {
                s = Regex.Replace(s, pattern, evalElem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (computedIndentChanges < 0)
            {
                indentLevel += computedIndentChanges;
                if (indentLevel < 0) indentLevel = 0;
            }
            string res = '\n' + new string(' ', indentSize * indentLevel) + item.Groups["line"].ToString();
            if (computedIndentChanges > 0) indentLevel += computedIndentChanges;
            return res;
        }
    }
}
