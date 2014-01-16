using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// include
using ChtemeleSurfaceApplication.Game_classes;

namespace ChtemeleSurfaceApplication.File_classes
{
    class FileReader
    {
        // URL absolu du fichier
        private string FileUrl;
        // entier le plus haut des parties (exemple dernière partie = game_85, DernierePArtie=85;)
        private int DernierePartie;
        // Nombre de tour effectué dans la partie 
        // Date de création de la partie
        // Nombre de joueur dans la partie
        //(variables défini en début de fichier :
        // <!-- DATE / NB_JOUEUR / NB_TOUR (effectué) --> )
        private int nbTourInFile;
        private string datePartie;  // variable stocké dans un fichier donc type string préféré
        private int nbJoueur;
        // Objet Game
        public Game classeGame;




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
            char[] delimitation = { '_' };

            string[] test = FileName.Split(delimitation, baseNameLength - 1);
            if (test[0] == baseName)
                return true;

            return false;
        }

        // Test si une partie est fini
        public bool testFinPartie(string FileName)
        {
            
            int nbSteps = classeGame.getActualnbSteps();

            // test en temps réel
            if(nbSteps < 10)
                return false;
            // test via le fichier (reprendre une partie)
            if (nbTourInFile < 10)
                return false;         

            return true;
        }


        // Permet de lire une ligne dans un fichier
        public string readLineFile(string FileName, int line)
        {
            // lis tout le fichier en enregistrant chaque ligne
            string[] lines = System.IO.File.ReadAllLines(FileName);
            // enregistre dans temp la ligne voulu
            string temp = lines[line];
            // retourne la ligne dans un string
            return temp;
        }

        // récupère le nombre de tour, date, nb_joueur
        //<!-- DATE / NB_JOUEUR / NB_TOUR (effectué) -->
        // (traitement de la premiere ligne du fichier game_XXX.html )
        public void getInfoPartie(string FileName)
        {
            // récupère la première ligne du fichier
            string firstLine = readLineFile(FileName, 0);
            // Caractères à supprimer
            char[] delimitation = { '<', '!','-','/', '>', ' '};
            // traitement de la premiere ligne, supprime et ne laisse qu'un tableau de taille 3
            string []temp = firstLine.Split(delimitation);
            // récupère les valeurs
            datePartie = temp[0];
            nbJoueur = int.Parse(temp[1]);      // conversion en int
            nbTourInFile = int.Parse(temp[2]);  // conversion en int

        }

    }
}
