using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.Modeles
{
    public class MdlCarteJoueur : Modele
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

        //a partir de la classe Player
        public Player getPlayer() { return _player; }
        public string getPlayerName() { return _player.name; }
        public void setPlayerName(string n) { _player.name = n; }
        public int getPlayerScore() { return _player.score; }

        //a partir de la classe Combo
        public Combo getCombo() { return _player.lastCombo(); }
        public string getComboCode() { return _player.lastCombo().code; }

        public bool hasBrowserUpdate()
        {
            foreach (Effect effect in _player.effects())
            {
                if (effect.getTypeEffect() == Effect.EffectType.BROWSERUPDATE)
                    return true;
            }
            return false;
        }

        public bool hasCrashBrowser()
        {
            foreach (Effect effect in _player.effects())
            {
                if (effect.getTypeEffect() == Effect.EffectType.CRASHBROWSER)
                    return true;
            }
            return false;
        }

        public bool hasFreeze()
        {
            foreach (Effect effect in _player.effects())
            {
                if (effect.getTypeEffect() == Effect.EffectType.FREEZE)
                    return true;
            }
            return false;
        }

    }
}