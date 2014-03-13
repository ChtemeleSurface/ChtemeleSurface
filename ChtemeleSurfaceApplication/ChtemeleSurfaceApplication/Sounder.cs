using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

using ChtemeleSurfaceApplication.Game_classes;
using ChtemeleSurfaceApplication.Carte_classes;

namespace ChtemeleSurfaceApplication
{
    public static class Sounder
    {
        // Constantes, enumérations         ======================================================================================================

        public const string soundDir = "Resources/";

        public const string FX_FIREFOX =    soundDir + "firefox.wav";
        public const string FX_CHROME =     soundDir + "chrome.wav";
        public const string FX_OPERA =      soundDir + "opera.wav";
        public const string FX_SAFARI =     soundDir + "safari.wav";
        public const string FX_EXPLORER =   soundDir + "explorer.wav";

        public const string FX_BOOM =       soundDir + "boom.wav";
        public const string FX_POINTS =     soundDir + "points.wav";
        public const string FX_BONUS =      soundDir + "bonus.wav";
        public const string FX_MALUS =      soundDir + "malus.wav";
        public const string FX_OK =         soundDir + "ok.wav";
        public const string FX_ERROR =      soundDir + "error.wav";
        public const string FX_TAGOK =      soundDir + "cymbal.wav";

        // Variables membres                ======================================================================================================

        public static bool mute = false;

        // Constructeurs                    ======================================================================================================

        // Classe statique, on ne l'instancie pas.

        // Accesseurs / Mutateurs           ======================================================================================================



        // Fonctionnalités                  ======================================================================================================

        public static void playSound(string filename)
        {
            if (mute) return;
            using (SoundPlayer player = new SoundPlayer(filename))
            {
                player.Play();
            }
        }

        public static void playCurrentPlayerSound()
        {
            string snd;
            switch (SurfaceWindow1.getInstance.getMdl.getCurrentPlayer().browser)
            {
                case Player.FIREFOX: snd = Sounder.FX_FIREFOX; break;
                case Player.CHROME: snd = Sounder.FX_CHROME; break;
                case Player.OPERA: snd = Sounder.FX_OPERA; break;
                case Player.SAFARI: snd = Sounder.FX_SAFARI; break;
                case Player.IE: snd = Sounder.FX_EXPLORER; break;
                default: snd = Sounder.FX_BOOM; break;
            }
            Sounder.playSound(snd);
        }

        public static void playCardSound(Carte card)
        {
            if (card is HTMLTagCarte || card is HTMLAttributeCarte)
                Sounder.playSound(Sounder.FX_POINTS);
            else if (card is AttaqueCarte)
                Sounder.playSound(Sounder.FX_MALUS);
            else if (card is AddonCarte)
                Sounder.playSound(Sounder.FX_BONUS);
        }
    }
}
