using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Surface.Presentation.Controls;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour RenduHTML.xaml
    /// </summary>
    public partial class RenduHTML : ScatterViewItem
    {
        // Variable contenant l'URL ou URI du fichier
        private string fileURL;

        // Constructeur
        public RenduHTML()
        {
            InitializeComponent();
            
            // Envoie l'URL par méthode SET -> utilisé lors du chargement d'un nouveau fichier
            // Le site doit ABSOLULENT avoir un affichage adaptatif selon la résolution !

            //Uri uri = new Uri(@"index.html", UriKind.Relative);
           //Uri uri = new Uri("Ressources/Documentation/index.html", UriKind.Relative);
            //string temp = uri.ToString(); //uri.OriginalString
           // string temp2 = uri.OriginalString;


            //setFileUrl(temp);  // http://www.lukew.com/ff/entry.asp?933  // F:/DUT INFORMATIQUE/2ND/TUT/ChtemeleSurface/ChtemeleSurfaceApplication/Documentation/index.html
            //"/<ApplicationName>;component/Icons/folder.png"
            // Envoie la source (page web) a afficher
            //WebRenderer();


            System.Uri uri1 = new Uri(@"F:/DUT INFORMATIQUE/2ND/TUT/ChtemeleSurface/ChtemeleSurfaceApplication/Documentation/");
            System.Uri uri2 = new Uri(@"F:/DUT INFORMATIQUE/2ND/TUT/ChtemeleSurface/ChtemeleSurfaceApplication/Documentation/index.html");

            Uri relativeUri = uri2.MakeRelativeUri(uri1);

            Console.WriteLine(relativeUri.ToString());

            Uri muri = new Uri(@".\\Resources\\Documentation\\index.html", UriKind.Relative);
            Uri muri2 = new Uri(@"index.html", UriKind.Relative);
            //WB1.Navigate(muri2);
        }

        
        // GET & SET
        public string getFileUrl()
        {
            return fileURL;
        }
        public void setFileUrl(string fileUrl)
        {
            fileURL = fileUrl;
        }

        // Initialise la source de la page à afficher
        private void WebRenderer()
        {
            WB1.Navigate(new Uri(getFileUrl()));

            //Uri uri = new Uri(@"Images\Backgrounds\Background1.png", UriKind.Relative);
            //string temp = uri.ToString(); //uri.OriginalString
        }
    }
}
