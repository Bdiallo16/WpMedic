using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Text;
using System.Xml.Linq;

namespace wpmedical
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();
        }

        // Déclenchement lors du clic sur "Ok"
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (this.txtIdentifiant.Text == "" || this.txtPassword.ToString() == "")
            {
                MessageBox.Show("L'identifiant et le mot de passe sont obligatoires. Merci de les renseigner.");
                return;
            }

            if ((this.txtIdentifiant.Text != "") && (this.txtPassword.ToString() != ""))
            {
                WebClient client = new WebClient();
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(finWebService);
                client.Headers["content-type"] = "text/xml; charset=utf-8";
                client.Encoding = Encoding.UTF8;
                client.UploadStringAsync(new Uri("http://www.altimed.fr/wspoitiers/claude.php")
                                            , "POST"
                                            , WebServiceClaude.medecinlogin(this.txtIdentifiant.Text, this.txtPassword.Password));
            }
        }
        // Fonction de retour du webservice
        private void finWebService(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapReponse = XElement.Parse(e.Result);
            string szResult = soapReponse.Descendants("result").First().Value.ToString();

            if (szResult.Contains("<medecin>"))
            {
                XElement xmlMedecin = XElement.Parse(szResult);
                var query = from item in xmlMedecin.Descendants("medecin")
                            select new classMedecin
                            {
                                id = item.Element("id").Value.ToString(),
                                nom = item.Element("nom").Value.ToString(),
                                prenom = item.Element("prenom").Value.ToString(),
                                login = item.Element("login").Value.ToString(),
                                password = item.Element("password").Value.ToString(),
                            };
               
                // Connection  réussie
                // Ecran d'accueil

                NavigationService.Navigate(new Uri("/accueil.xaml", UriKind.Relative));

                (Application.Current as App).medecinGlobal = query.First();

                //MessageBox.Show((Application.Current as App).medecinGlobal.id);
            }
            else
            {
                MessageBox.Show("erreur de connexion");
            }
        }
    }
}