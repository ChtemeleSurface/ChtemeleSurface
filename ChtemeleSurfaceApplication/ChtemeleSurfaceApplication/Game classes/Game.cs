using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChtemeleSurfaceApplication.HTML_classes;
using ChtemeleSurfaceApplication.Modeles;

namespace ChtemeleSurfaceApplication.Game_classes
{
    class Game
    {
        //Singleton
        private static Game instance = null;
        public static Game getInstance{
            get{
                if (instance == null)
                    instance = new Game();
                return instance;
            }
        }

        // Tour actuel
        private int step;
        // Nombre de tour total
        private int nbSteps;
        // variables joueurs
        private Player joueurS, joueurN, joueurE, joueurO;

        public void setJoueurS(Player P) { joueurS = P; }
        public void setJoueurN(Player P) { joueurN = P; }
        public void setJoueurE(Player P) { joueurE = P; }
        public void setJoueurO(Player P) { joueurO = P; }

        public Player getJoueurS() { return joueurS; }
        public Player getJoueurN() { return joueurN; }
        public Player getJoueurE() { return joueurE; }
        public Player getJoueurO() { return joueurO; }

        private Player _curPlayer;

        public HtmlPage _page;

        public Dictionary<int, int> LocationNav = new Dictionary<int, int>
        {
            {CartesJoueurs.FIREFOX, 0},
            {CartesJoueurs.CHROME, 0},
            {CartesJoueurs.IE, 0},
            {CartesJoueurs.SAFARI, 0},
            {CartesJoueurs.OPERA, 0}
        };

        protected Game()
        {
            _page = new HtmlPage();
            //SurfaceWindow1.instance.PageCode.ShowCode(getRawHTML());
        }


        // SET - GET
        // variable -> step;
        public int getActualStep()
        {
            return step;
        }
        public void setActualStep(int a)
        {
            step = a;
        }

        // SET - GET
        // variable -> nbSteps;
        public int getActualnbSteps()
        {
            return nbSteps;
        }

        public void setActualnbSteps(int a)
        {
            nbSteps = a;
        }

        public string getRawHTML()
        {
            string ret = _page.renderHTML();
            return ret;
        }

    }
}
