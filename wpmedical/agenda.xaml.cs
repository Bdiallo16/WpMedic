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
    public partial class class_agenda : PhoneApplicationPage
    {
        public class_agenda()
        {
            InitializeComponent();
    //web service permettant de recuperer des fonctions disponible dans altimed.fr 
            WebClient client = new WebClient();
            //opération de transfert asynchrone
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
            client.Headers["content-type"] = "text/xml; charset=utf-8";
            //encodage utf8
            client.Encoding = Encoding.UTF8;
            client.UploadStringAsync(new Uri("http://www.altimed.fr/wspoitiers/claude.php")
                                        , "POST"
                                        , WebServiceClaude.agendaCons(0, int.Parse((Application.Current as App).medecinGlobal.id)));
        }

        public void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapReponse = XElement.Parse(e.Result);
            string resultRep = soapReponse.Descendants("result").First().Value.ToString();
            XElement saop = XElement.Parse(resultRep);

            if (saop != null)
            {
                /*requete permettant de recuperer la date prévue,date de début, date de fin, urgence et le libelle
                 */ 
                var query = from consult in saop.Descendants("agenda")
                            select new classAgenda
                            {
                                dateprevue = consult.Element("dateprevue").Value.ToString(),
                                datedebut = consult.Element("datedebut").Value.ToString(),
                                datefin = consult.Element("datefin").Value.ToString(),
                                urgence = consult.Element("urgence").Value.ToString(),
                                libelle = consult.Element("libelle").Value.ToString(),
                            };
                this.lstJours.ItemsSource = query.ToList();
            }
        }

        private void lstJours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}