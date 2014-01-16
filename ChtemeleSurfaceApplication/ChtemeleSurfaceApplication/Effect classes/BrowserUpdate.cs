using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 
 * Au prochain tour vous piocherez jusqu’à avoir 2 cartes de plus. (12 au lieu de 10, 8 au lieu de 10.)
 * 
 * */

// include
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Effect_classes
{
    class BrowserUpdate
    {
        public Player player;

        // Constructeur
        public BrowserUpdate()
        {
            // Calcul le nombre de carte actuel et ajoute 2
            int addCardTOactualNbCards = player.getPlayerMAxNbCard() + 2;
            // renvoie la valeur modifié du nombre de carte actuel (Maximum de carte)
            player.setPlayerMAxNbCard(addCardTOactualNbCards);
        }
    }
}
