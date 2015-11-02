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
            
            if ((Application.Current as App).antecedentEnCours != null)
            {
                // on affiche les résultats dans les textbox et on affiche les boutons supprimer, enregistrer et annuler
               
                this.txtLibelle.Text = (Application.Current as App).antecedentEnCours.libelle;
                this.txtAnnee.Text = (Application.Current as App).antecedentEnCours.annee.ToString();
                this.txtCommentaire.Text = (Application.Current as App).antecedentEnCours.commentaire;
                this.btnAjouter.Visibility = System.Windows.Visibility.Collapsed;

            }
            else
            {
                
                //rendre visible le bouton ajouter et masquer les boutons enregistrer et supprimer
                this.btnAjouter.Visibility = System.Windows.Visibility.Visible;
                this.btnEnregistrer.Visibility = System.Windows.Visibility.Collapsed;
                this.btnSupprimer.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        //fonction pour annuler l'operation
        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            //permet de vider les champs de saisies
            this.txtAnnee.Text = "";
            this.txtCommentaire.Text = "";
            this.txtLibelle.Text = "";
        }
        //fonction pour enregistrer les valeurs saisies dans les zones de texte
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {

            //on recupère  la valeur saisie dans la zone zone de texte libellé
            A.libelle = this.txtLibelle.Text;
            //on recupère  la valeur saisie dans la zone zone de texte année
            A.annee = int.Parse(this.txtAnnee.Text);
            // on recupère  la valeur saisie dans la zone zone de texte commentaire
            A.commentaire = this.txtCommentaire.Text;
            //la classe WebClient Fournit des méthodes communes pour l'envoi de données à une ressource identifiée par un URI ou pour la réception de données en provenance de cette ressource
            WebClient client2 = new WebClient();
            client2.UploadStringCompleted += new UploadStringCompletedEventHandler(antecedents_UploadStringCompleted2);
            //encodage utf8
            client2.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            //encodage utf8
            client2.Encoding = Encoding.UTF8;
            client2.UploadStringAsync(new Uri("http://altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.ajoutAntecedents((Application.Current as App).patientGlobal.idPatient,
                                A.libelle, A.annee, A.commentaire));
        }
        //opération asynchrone de transfert de chaînes
        private void antecedents_UploadStringCompleted2(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);
            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();
            //Message d'alerteindiquant que l'antécédent a été enregistré
            MessageBox.Show(" Antécédent enregistré ! ");
            //navigation jusqu'à l'entrée la plus récente dans l'historique de navigation arrière
            NavigationService.GoBack();
        }
        //fonction pour ajouter les valeurs saisies dans les zones de texte
        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            //on recupère  la valeur saisie dans la zone zone de texte libellé
            A.libelle = this.txtLibelle.Text;
            //on recupère  la valeur saisie dans la zone zone de texte année
            A.annee = int.Parse(this.txtAnnee.Text);
            // on recupère  la valeur saisie dans la zone zone de texte commentaire
            A.commentaire = this.txtCommentaire.Text;

            WebClient client2 = new WebClient();
            client2.UploadStringCompleted += new UploadStringCompletedEventHandler(MAJantecedents_UploadStringCompleted2);
            client2.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client2.Encoding = Encoding.UTF8;
            client2.UploadStringAsync(new Uri("http://altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.MAJAntecedents((Application.Current as App).antecedentEnCours.id, (Application.Current as App).patientGlobal.idPatient,
                                A.libelle, A.annee, A.commentaire));
        }
        //fonction permettant de mettre à jour un antécedent
        private void MAJantecedents_UploadStringCompleted2(object sender, UploadStringCompletedEventArgs e)
        {
            //Initialise une nouvelle instance de la classe XElement
            XElement soapResponseBrut = XElement.Parse(e.Result);
            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();
            MessageBox.Show(" Antécédent modifié ! ");

            NavigationService.GoBack();
        }

        //fonction pour supprimer un antécedent
        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            WebClient client3 = new WebClient();
            client3.UploadStringCompleted += new UploadStringCompletedEventHandler(supprimerAntecedents_UploadStringCompleted);
            //Encodage utf-8
            client3.Headers["Content-Type"] = "Text/xml; charset=utf-8";
            client3.Encoding = Encoding.UTF8;
            client3.UploadStringAsync(new Uri("http://altimed.fr/wspoitiers/claude.php"), "POST", WebServiceClaude.supprimerajoutAntecedents((Application.Current as App).antecedentEnCours.id));
        }

        //fonction pour supprimer un antécedent
        private void supprimerAntecedents_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            XElement soapResponseBrut = XElement.Parse(e.Result);
            string resultrep = soapResponseBrut.Descendants("result").First().Value.ToString();
            //affichage message d'alerte indiquant que l'antécédent a été supprimé
            MessageBox.Show(" Antécédent supprimé ! ");

            NavigationService.GoBack();
        }

    }
}