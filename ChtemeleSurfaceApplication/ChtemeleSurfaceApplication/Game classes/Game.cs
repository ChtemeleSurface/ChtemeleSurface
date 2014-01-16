using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChtemeleSurfaceApplication.Game_classes
{
    class Game
    {
        // Tour actuel
        private int step;
        // Nombre de tour total
        private int nbSteps;
        // variables joueurs
        private Player joueurS, joueurN, joueurE, joueurO;

        public Game()
        {
            // Définition joueurS

            // Définition joueurN

            // Définition joueurE

            // Définition joueurO

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

    }
}
