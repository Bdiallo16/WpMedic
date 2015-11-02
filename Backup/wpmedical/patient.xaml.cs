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
using System.Xml.Linq;
using System.Text;

namespace wpmedical
{
    public partial class patient : PhoneApplicationPage
    {
        public classConsultation p = new classConsultation();
        public classPatient A = new classPatient();
        public classOrdonnance Ordo = new classOrdonnance();

        public patient()
        {
            InitializeComponent();
            chargement_ListBox();
            chargement_ListBoxMedic();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // on vide la liste box 
            if (this.lstAntecedents.Items.Count() != -1)
            {
                this.lstAntecedents.ItemsSource = null;
            }
            // et on recharger la listBox
            ListBoxAntecedents();
        }


        public void ListBoxAntecedents()
        {
            WebClient clientA = new WebClient();
            clientA.UploadStringCompleted += new UploadStringCompletedEventHandler(clientA_UploadStringCompleted);
            clientA.Headers["content-type"] = "text/xml; charset=utf-8";
            clientA.Encoding = Encoding.UTF8;
            clientA.UploadStringAsync(new Uri("http://altimed.fr/wspoitiers/claude.php")
                                        , "POST"
                                        , WebServiceClaude.antecedents(0, (Application.Current as App).patientGlobal.idPatient));
        }

        public void clientA_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapReponse = XElement.Parse(e.Result);
            string resultRep = soapReponse.Descendants("result").First().Value.ToString();
            XElement saop = XElement.Parse(resultRep);

            if (saop != null)
            {
                // Anamnèse
                var queryAntecedents = from antecedent in saop.Descendants("atcd")
                                       select new classAntecedent
                                       {
                                           id = int.Parse(antecedent.Element("id").Value.ToString()),
                                           libelle = antecedent.Element("libelle").Value.ToString(),
                                           annee = int.Parse(antecedent.Element("annee").Value.ToString()),
                                           commentaire = antecedent.Element("commentaire").Value.ToString()
                                       };
                this.lstAntecedents.ItemsSource = queryAntecedents;

                // -------------

                // Infos patient

                this.txtAdresse.Text = (Application.Current as App).patientGlobal.adressePatient.ToString();
                this.txtNom.Text = (Application.Current as App).patientGlobal.nomPatient;
                this.txtTelephone.Text = (Application.Current as App).patientGlobal.telephone.ToString();

                // -------------
            }
        }

        private void btnNouveau_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).antecedentEnCours = null;
            NavigationService.Navigate(new Uri("/antecedents.xaml", UriKind.Relative));
        }

        private void detailAntecedents_click(object sender, SelectionChangedEventArgs e)
        {
            if (this.lstAntecedents.SelectedItem == null) return;

            (Application.Current as App).antecedentEnCours = (classAntecedent)this.lstAntecedents.SelectedItem;

            NavigationService.Navigate(new Uri("/antecedents.xaml", UriKind.Relative));
        }

        private void btnEnregistrerInfos_click(object sender, RoutedEventArgs e)
        {
            //on recupère les information des zone de texte 
            A.nomPatient = this.txtNom.Text;
            A.prenom = this.txtPrenom.Text;
            A.adressePatient = this.txtAdresse.Text;
            A.codepostal = this.txtCodePostal.Text;
            A.ville = this.txtVille.Text;
            A.telephone = this.txtTelephone.Text;
            A.mobile = this.txtMobile.Text;
            A.email = this.txtEmail.Text;
            A.datenaissance = this.txtDateNaissance.Text;
            A.sexe = this.txtSexe.Text;

            WebClient client2 = new WebClient();
            client2.UploadStringCompleted += new UploadStringCompletedEventHandler(MAJinfos_UploadStringCompleted2);
            client2.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client2.Encoding = Encoding.UTF8;
            client2.UploadStringAsync(new Uri("http://altimed.fr/wspoitiers/claude.php"), "POST",
                WebServiceClaude.MAJInfos(
                (Application.Current as App).patientGlobal.idPatient, A.nomPatient, A.prenom, A.adressePatient, A.codepostal,
                                A.ville, A.telephone, A.mobile, A.email, A.datenaissance, A.sexe));
        }

        private void MAJinfos_UploadStringCompleted2(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);
            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();
            MessageBox.Show(" Informations modifiées ! ");
        }

        public void chargement_ListBox()
        {
            WebClient client = new WebClient();
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
            client.Headers["content-type"] = "text/xml; charset=utf-8";
            client.Encoding = Encoding.UTF8;
            client.UploadStringAsync(new Uri("http://www.altimed.fr/wspoitiers/claude.php")
                                        , "POST"
                                        , WebServiceClaude.consultations(0, (Application.Current as App).patientGlobal.idPatient));
        }

        public void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        { 
            XElement soapReponse = XElement.Parse(e.Result);
            string resultRep = soapReponse.Descendants("result").First().Value.ToString();
            XElement saop = XElement.Parse(resultRep);

            if (saop != null)
            {
                var query = from consult in saop.Descendants("consultation")
                            select new classConsultation
                            {
                                id = int.Parse(consult.Element("id").Value),
                                dateconsultation = consult.Element("dateconsultation").Value.ToString(),
                                libelle = consult.Element("libelle").Value.ToString(),
                                motif = int.Parse(consult.Element("motif").Value),
                                poids = int.Parse(consult.Element("poids").Value),
                                taille = int.Parse(consult.Element("taille").Value),
                                tas = int.Parse(consult.Element("tas").Value),
                                tad = int.Parse(consult.Element("tad").Value),
                                detail = consult.Element("detail").Value.ToString(),
                                devenir = consult.Element("devenir").Value.ToString(),
                                idmedecin = int.Parse(consult.Element("idmedecin").Value),
                            };
                this.lstConsultation.ItemsSource = query.ToList();
            }
        }

        private void lstConsultation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            classConsultation cons =  null ;
            if (lstConsultation.SelectedItem != null)
            {
                cons = (classConsultation)lstConsultation.SelectedItem;

                MessageBox.Show(" Le : " + cons.dateconsultation.ToString() + "\n " + cons.libelle.ToString() + "\n pour : " + cons.motif.ToString()
                    + "\n poid : " + cons.poids.ToString() + "\n taille  : " + cons.taille.ToString() + "\n tas : " + cons.tas.ToString()
                    + "\n tad : " + cons.tad.ToString() + "\n detail : " + cons.detail.ToString() + "\n devenir : " + cons.devenir.ToString()
                    );
            }
        }

        //Validation d'une nouvelle consultation 
        public void btnValider_Click(object sender, RoutedEventArgs e)
        {
            //on recupere les information des zone de texte 
            p.libelle = txtLibelle.Text.ToString();
            p.imc = int.Parse(txtImc.Text);
            p.taille = int.Parse(txtTaille.Text);
            p.poids = int.Parse(txtPoid.Text);
            p.tas = int.Parse(txtTas.Text);
            p.tad = int.Parse(txtTad.Text);
            p.detail = txtDetail.Text.ToString();
            p.devenir = txtDevenirPatient.Text.ToString();

            WebClient client2 = new WebClient();
            client2.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted2);
            client2.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client2.Encoding = Encoding.UTF8;
            client2.UploadStringAsync(new Uri("http://www.altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.ajoutConsultations((Application.Current as App).patientGlobal.idPatient,
                                DateTime.Today.ToString("yyyy-mm-dd hh-MM-SS"), p.libelle, 0, p.taille, p.imc, p.poids, p.tas, p.tad, p.detail, p.devenir, int.Parse((Application.Current as App).medecinGlobal.id)));  
        }

        private void client_UploadStringCompleted2(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);

            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();

            MessageBox.Show(" Consultation enregistrer ");
            // on vide la liste box 
            if (this.lstConsultation.Items.Count() != -1)
            {
                this.lstConsultation.ItemsSource = null;
            }
            // et on recharger la listBox
            chargement_ListBox();

            //on vide les zone de texte
            txtLibelle.Text = " " ;
            txtImc.Text = " ";
            txtTaille.Text = " ";
            txtPoid.Text = " ";
            txtTas.Text = " ";
            txtTad.Text = " ";
            txtDetail.Text = " ";
            txtDevenirPatient.Text = " ";
        }


        public void chargement_ListBoxMedic()
        {
            WebClient client = new WebClient();
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted3);
            client.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client.Encoding = Encoding.UTF8;
            client.UploadStringAsync(new Uri("http://www.altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.medic(0, (Application.Current as App).patientGlobal.idPatient));
        }

         
        //Validation d'une nouvelle consultation
        private void client_UploadStringCompleted3(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);

            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();

            XElement soapResponseParsed = XElement.Parse(resultrep);

            var query = from cemedoc in soapResponseParsed.Descendants("prescription")
                        select new classOrdonnance()
                        {
                            medic = cemedoc.Element("medic").Value.ToString()
                        };
            this.lstMedic.ItemsSource = query.ToList();
        }

        private void btnAjouterMedoc_Click(object sender, RoutedEventArgs e)
        {
            Ordo.medic = txtNomMedoc.Text.ToString();
            Ordo.quantite = int.Parse(txtQuantite.Text.ToString());
            Ordo.formGalenique = txtFomeGalenique.Text.ToString();
            Ordo.momentprise = txtMomentsprises.Text.ToString();
            Ordo.duree = txtDuree.Text.ToString();
        }
        private void Ajouter_ordo()
        {
            WebClient client2 = new WebClient();
            client2.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted5);
            client2.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client2.Encoding = Encoding.UTF8;
            client2.UploadStringAsync(new Uri("http://www.altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.ajoutConsultations(19,
                                DateTime.Today.ToString(), p.libelle, 0, p.taille, p.imc, p.poids, p.tas, p.tad, p.detail, p.devenir, 1));
        }
        private void client_UploadStringCompleted5(object sender, UploadStringCompletedEventArgs e)
        {
            XElement ajoutOrdo = XElement.Parse(e.Result);
            string resultAjoutOrdo = ajoutOrdo.Descendants("result").First().Value.ToString();
        }
    }
}