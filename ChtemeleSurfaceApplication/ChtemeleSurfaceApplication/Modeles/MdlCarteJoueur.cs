using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    class MdlCarteJoueur : Modele
    {
        // Constantes, enumérations         ======================================================================================================



        // Variables membres                ======================================================================================================

        private Player _player;     //Données du modèle

        // Constructeurs                    ======================================================================================================

        public MdlCarteJoueur(Player p)
            : base()
        {
            _player = p;
        }

        // Fonctionnalités                  ======================================================================================================

        public Player getPlayer() { return _player; }
        public string getPlayerName() { return _player.name; }
        public void setPlayerName(string n) { _player.name = n; }
        public int getPlayerScore() { return _player.score; }

    }
}