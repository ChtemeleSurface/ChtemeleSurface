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
        private Player _curPlayer;

        public HtmlPage _page;

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
