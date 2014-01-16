using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.File_classes
{
    class FileReader
    {
        private string FileUrl;
        private int DernierePartie;

        // faudra qu'on discute demain Val pour savoir comment on va s'y prendre pour la gestion des fichiers
        // parce qu'il nous faut absolument un truc commun


        // du genre :

        /* quand on arrive sur le menu de demarrage choix -> voir ancienne partie OU commencer OU reprendre (avec fichier c'est possible j'explique pourquoi après)
         * 
         * 
         * Visionner on pourra utiliser la fonction de listage
         * Commencer une partie, il faudra savoir quel est le numéro de la derniere partie et l'incrementer
         * Reprendre de même (listage) + effectuer d'autres test pour savoir si la partie est terminé
         * 
         * 
         * 
         * comment on nomme les fichiers ? Les fichiers seront sauvegardé dans Resources/Savegame/game_1.html
         * on peut imaginer le début du fichier de la sorte :
         *  <!-- DATE / NB_JOUEUR / NB_TOUR (effectué) -->
         *  Code ...
         * 
         * On saura le numéro à choisir pour le prochain fichier grâce à ce petit code
         * 
         * 
         * 
         * 
         */

        // Permet de récuperer tous les noms des fichiers dans un dossier précis dans la boucle
        public void ListageFichier()
        {
            string temp = System.IO.Directory.GetCurrentDirectory();
            temp = temp + "\\Resources\\Documentation";
            String[] files = System.IO.Directory.GetFiles(temp);

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo F = new FileInfo(files[i]);
                string test = Path.GetFileNameWithoutExtension(F.Name); // retourne le nom du fichier sans extension
            } 
        }

        // Test du plus grand fichier dans le listage
        public void plusGrand(string FileName)
        {
            if (testNom(FileName))
            {
                // si fichier + petit on sort
                string baseName = "game_";
                int baseNameLength = baseName.Length;
                char[] delimitation = { '_' };

                string[] test = FileName.Split(delimitation, baseNameLength - 1);

                int valeur = int.Parse(test[1]);
                if (DernierePartie == null)
                {
                    DernierePartie = 0;
                }
                else
                {
                    if (valeur > DernierePartie)
                        DernierePartie = valeur;
                }
            }
        }

        // Sert à tester la base du nom, s'il n'est pas commun à celui désigner pour retourne faux
        public bool testNom(string FileName)
        {
            string baseName = "game_";
            int baseNameLength = baseName.Length;
            char[] delimitation = {'_'};

            string[] test = FileName.Split(delimitation, baseNameLength-1);
            if (test[0] == baseName)
                return true;

            return false;
        }

        // Test si une partie est fini
        public bool testFinPartie(string FileName)
        {
            /* TODO le code */
            return true;
        }

    }
}
