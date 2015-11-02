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
    public partial class gestionPatients : PhoneApplicationPage
    {
        //instanciation de la classe patient(p est un objet de type classPatient)
        private classPatient p = new classPatient();
        private XElement soapResponseParsed;

        public gestionPatients()
        {
            InitializeComponent();
        }

        private void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);

            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();

            soapResponseParsed = XElement.Parse(resultrep);

            var query = from cepatient in soapResponseParsed.Descendants("patient")
                        select new classPatient
                        {
                            idPatient = int.Parse(cepatient.Element("id").Value.ToString()),
                            nomPatient = cepatient.Element("nom").Value.ToString(),
                            prenom = cepatient.Element("prenom").Value.ToString(),
                            adressePatient = cepatient.Element("adresse").Value.ToString(),
                            codepostal = cepatient.Element("codepostal").Value.ToString(),
                            ville = cepatient.Element("ville").Value.ToString(),
                            mobile = cepatient.Element("mobile").Value.ToString(),
                            email = cepatient.Element("email").Value.ToString(),
                            datenaissance = cepatient.Element("datenaissance").Value.ToString(),
                            sexe = cepatient.Element("sexe").Value.ToString(),
                            telephone = cepatient.Element("telephone").Value.ToString()
                        };
            this.lstPatient.ItemsSource = query.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length > 2)
            {
                p.nomPatient = txtSearch.Text.ToString();

                WebClient client = new WebClient();
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
                client.Headers["Content-Type"] = "Text/xml; charset=utf-8";
                client.Encoding = Encoding.UTF8;
                client.UploadStringAsync(new Uri("http://www.altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.patient(p.nomPatient));
            }
            else
            {
                p.nomPatient = "";
            }
        }

        private void lstPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstPatient.SelectedItem != null)
            {
                p = (classPatient)lstPatient.SelectedItem;

                if (lstPatient.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    NavigationService.Navigate(new Uri("/patient.xaml", UriKind.Relative));
                    //MessageBox.Show("" + p.idPatient);
                    (Application.Current as App).patientGlobal = p;
                    //p.idPatient = -1;
                }
            }
        }
    }
}