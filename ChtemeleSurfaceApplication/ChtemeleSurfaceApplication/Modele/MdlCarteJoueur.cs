using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    class MdlCarteJoueur : Modele
    {
        private Player _player;

        public MdlCarteJoueur(Player p)
            : base()
        {
            _player = p;
        }

        public string getPlayerName()
        {
            return "Fichtre faut faire un accesseur dans Player !";
        }
    }
}