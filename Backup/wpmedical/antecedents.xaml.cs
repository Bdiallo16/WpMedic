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
    public partial class antecedents : PhoneApplicationPage
    {

        public classAntecedent A = new classAntecedent();

        public antecedents()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // ICI : si l'idée est transféré en paramètre depuis la gestion client, alors 
            // on affiche les résultats dans les textbox et on affiche les boutons supprimer et enregistrer et annuler
            // sinon on affiche des cases vides + bouton ajouter et annuler
            if ((Application.Current as App).antecedentEnCours != null)
            {
                this.txtLibelle.Text = (Application.Current as App).antecedentEnCours.libelle;
                this.txtAnnee.Text = (Application.Current as App).antecedentEnCours.annee.ToString();
                this.txtCommentaire.Text = (Application.Current as App).antecedentEnCours.commentaire;
                this.btnAjouter.Visibility = System.Windows.Visibility.Collapsed;

            }
            else
            {
                this.btnAjouter.Visibility = System.Windows.Visibility.Visible;
                this.btnEnregistrer.Visibility = System.Windows.Visibility.Collapsed;
                this.btnSupprimer.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            this.txtAnnee.Text = "";
            this.txtCommentaire.Text = "";
            this.txtLibelle.Text = "";
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            //on recupere les information des zone de texte 
            A.libelle = this.txtLibelle.Text;
            A.annee = int.Parse(this.txtAnnee.Text);
            A.commentaire = this.txtCommentaire.Text;

            WebClient client2 = new WebClient();
            client2.UploadStringCompleted += new UploadStringCompletedEventHandler(antecedents_UploadStringCompleted2);
            client2.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client2.Encoding = Encoding.UTF8;
            client2.UploadStringAsync(new Uri("http://altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.ajoutAntecedents((Application.Current as App).patientGlobal.idPatient,
                                A.libelle, A.annee, A.commentaire));
        }

        private void antecedents_UploadStringCompleted2(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);
            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();
            MessageBox.Show(" Antécédent enregistré ! ");

            NavigationService.GoBack();
        }

        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            //on recupere les information des zone de texte 
            A.libelle = this.txtLibelle.Text;
            A.annee = int.Parse(this.txtAnnee.Text);
            A.commentaire = this.txtCommentaire.Text;

            WebClient client2 = new WebClient();
            client2.UploadStringCompleted += new UploadStringCompletedEventHandler(MAJantecedents_UploadStringCompleted2);
            client2.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client2.Encoding = Encoding.UTF8;
            client2.UploadStringAsync(new Uri("http://altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.MAJAntecedents((Application.Current as App).antecedentEnCours.id, (Application.Current as App).patientGlobal.idPatient,
                                A.libelle, A.annee, A.commentaire));
        }

        private void MAJantecedents_UploadStringCompleted2(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);
            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();
            MessageBox.Show(" Antécédent modifié ! ");

            NavigationService.GoBack();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            WebClient client3 = new WebClient();
            client3.UploadStringCompleted += new UploadStringCompletedEventHandler(supprimerAntecedents_UploadStringCompleted);
            client3.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client3.Encoding = Encoding.UTF8;
            client3.UploadStringAsync(new Uri("http://altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.supprimerajoutAntecedents((Application.Current as App).antecedentEnCours.id));
        }

        private void supprimerAntecedents_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);
            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();
            MessageBox.Show(" Antécédent supprimé ! ");

            NavigationService.GoBack();
        }

    }
}