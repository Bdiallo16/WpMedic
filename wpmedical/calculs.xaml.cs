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
using wsmedical;

namespace wpmedical
{
    public partial class calculs : PhoneApplicationPage
    {
        public double poids { get; set; }
        public double taille { get; set; }
        public double resultat { get; set; }
        private ScoreESC ecs = new ScoreESC();
        private int sexe;
        private int fumeur;

        public calculs()
        {
            InitializeComponent();
            this.textBlock1.Visibility = System.Windows.Visibility.Collapsed;
            this.textBlock2.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btnCalculerGrossesse_Click(object sender, RoutedEventArgs e)
        {
            if ((this.txtDateRegles.Text != ""))
            {
                DateTime dtTmp;
                if (DateTime.TryParse(this.txtDateRegles.Text, out dtTmp))
                {
                    DateTime dateRegles = DateTime.Parse(this.txtDateRegles.Text);
                    this.textBlock1.Visibility = System.Windows.Visibility.Visible;
                    this.textBlock2.Visibility = System.Windows.Visibility.Visible;
                    //Afichage de la date de conception sous 01/01/1979
                    this.txtConception.Text = dateRegles.AddDays(14).ToString("dd/MM/yy");
                    this.txtAccouchement.Text = dateRegles.AddDays(280).ToString("dd/MM/yy");
                }
                else
                {
                    MessageBox.Show("Date au mauvais format. Merci d'insérer une date de format JJ/MM/AAAA.");
                }
            }
            else
            {
                //message d'alerte indiquant q'aucune date n'a été rentré
                MessageBox.Show("Aucune date n'a été entrée.");
            }

        }
        //calcul de l'imc
        private void btnImc_Click(object sender, RoutedEventArgs e)
        {   //vérifie si les champs de textes poids et taille sont vides
            if (this.txtPoids.Text == "" || this.txtTaille.Text == "")
            {
                MessageBox.Show("veuiller remplir les champs vides");
                return;
            }

            if (this.txtPoids.Text != "" && this.txtTaille.Text != "")
            {
                poids = double.Parse(txtPoids.Text);
                taille = double.Parse(txtTaille.Text);
                this.taille = this.taille / 100;
                //résultat du calcul IMC
                resultat = (poids / (taille * taille));
                //affichage du resultat (format deux chiffres après la virgule)
                this.txtBlockImc.Text = this.resultat.ToString("00.00");
            }
        }
       
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            int resulecs;
            //Gère si homme ou femme est coché
            if (rbF.IsChecked == true || rbM.IsChecked == true)
            {
                if (rbTabacNon.IsChecked == true || rbTabacOui.IsChecked == true)//Gère si le patient est fumeur ou non
                {
                    //teste si le patient est dans l'âge requis
                    if (txtAge.Text.Length > 0 && (int.Parse(txtAge.Text.ToString()) > 40 && int.Parse(txtAge.Text.ToString()) <= 65))
                    {
                        //teste si le patient a une tension existante
                        if (txtTension.Text.Length > 0 && (int.Parse(txtTension.Text.ToString()) > 0))
                        {
                            //teste si le patient a un taux de cholestérol élèvé
                            if (txtChol.Text.Length > 0 && (int.Parse(txtChol.Text.ToString()) > 0))
                            {
                                if (rbF.IsChecked == false)
                                {
                                    sexe = 0;
                                }
                                sexe = 1;
                                if (rbTabacNon.IsChecked == true)
                                {
                                    fumeur = 0;
                                }
                                fumeur = 1;
                                //Appel de la fonction calculateScoreCVD grace au web services
                                resulecs = ecs.calculateScoreCVD(sexe, fumeur, int.Parse(txtAge.Text.ToString()), int.Parse(txtTension.Text.ToString()), int.Parse(txtChol.Text.ToString()));
                                if (resulecs >= 0)
                                {
                                    txtResCardio.Text = resulecs.ToString();
                                }
                            }
                            else
                            {
                                //Message d'alerte affichant le taux de cholesterol
                                MessageBox.Show("Problème avec le cholestérol du patient");
                                return;
                            }
                        }
                        else
                        {

                            //Message d'alerte affichant la tension du patient
                            MessageBox.Show("Problème avec la tension du patient ");
                            return;
                        }
                    }
                    else
                    {
                        //Message d'alerte affichant la limite d'age
                        MessageBox.Show("Le patient n'est pas dans la limite d'âge (40-65 ans)");
                        return;
                    }
                }
                else
                {
                    //Message d'alerte demandant si le patient est fumeur ou non
                    MessageBox.Show("Veuillez renseigner si le patient est fumeur ou non");
                    return;
                }
            }
            else
            {
                //Message d'alerte selon le choix du sexe du patient
                MessageBox.Show("Veuillez renseigner si le patient est un homme ou une femme");
                return;
            }
        }
    }
}