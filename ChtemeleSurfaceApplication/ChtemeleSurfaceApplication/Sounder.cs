using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication
{
    public class Sounder
    {
        // Constantes, enumérations         ======================================================================================================

        public const string soundDir = "Resources/";

        public const string FX_FIREFOX =    soundDir + "firefox.wav";
        public const string FX_CHROME =     soundDir + "chrome.wav";
        public const string FX_OPERA =      soundDir + "opera.wav";
        public const string FX_SAFARI =     soundDir + "safari.wav";
        public const string FX_EXPLORER =   soundDir + "explorer.wav";

        public const string FX_BOOM =       soundDir + "boom.wav";

        // Variables membres                ======================================================================================================



        // Constructeurs                    ======================================================================================================

        private Sounder()   // Classe statique, on ne l'instancie pas.
        {

        }

        // Accesseurs / Mutateurs           ======================================================================================================



        // Fonctionnalités                  ======================================================================================================

        public static void playSound(string filename)
        {
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
    }
}
