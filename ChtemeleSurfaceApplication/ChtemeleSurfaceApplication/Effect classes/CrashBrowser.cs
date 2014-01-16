using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 
 * Au prochain tour, le joueur ciblé ne piochera que jusqu’à avoir 4 cartes de moins. (6 au lieu de 10, 8 au lieu de 12.)
 * 
 * */

// include
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Effect_classes
{
    class CrashBrowser
    {
        public Player player;

        // Constructeur
        public CrashBrowser()
        {
            // nombre actuel de cartes que le joueur peut piocher
            //int actualMAXNbCards = 
            int actualNbcards = player.getNbCartesJoueur();
            // le joueur peut piocher :
            //nombre de carte max - son nombre de carte actuel - 4
            player.setPlayerCanTake( (player.getPlayerMAxNbCard() - actualNbcards) - 4 );
        }
    }
}
