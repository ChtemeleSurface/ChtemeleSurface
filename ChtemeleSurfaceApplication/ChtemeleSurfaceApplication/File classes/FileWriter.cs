using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChtemeleSurfaceApplication.File_classes
{
    class FileWriter
    {
        
        // Variable contenant le code basic d'une page HTML5
        public string basicHTML5code =
            "<!DOCTYPE html><html><head><meta charset='UTF-8'><title>Title of the document</title></head><body>Content of the document......</body></html>";



        // Ecrit un string après  UN ou DES caractères de délimitation
        // FileUrl -> chemin local absolu vers le fichier
        // string[] textToWrite -> permet d'enregistrer plusieurs lignes
        public void writeInFile(string FileUrl, string textToWrite, string delimitation)
        {
            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(FileUrl, true);  // Writer
            string[] lines = System.IO.File.ReadAllLines(FileUrl);                          // Reader

            // lire le fichier jusqu'à rencontrer la délimitation
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == delimitation)
                {
                    // écrit le texte demandé à la ligne
                    fileWriter.WriteLine(textToWrite);
                }
            }            
        }


        public void writeBasicHTML5Code(string fileUrl)
        {
            string delimitation = "";
            writeInFile(fileUrl, basicHTML5code,delimitation);
        }


    }
}
