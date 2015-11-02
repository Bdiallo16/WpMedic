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
                MessageBox.Show("Aucune date n'a été entrée.");
            }

        }
        //calcul de l'imc
        private void btnImc_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtPoids.Text == "" || this.txtTaille.Text == "")
            {
                MessageBox.Show("veuiller remplir les champs");
                return;
            }

            if (this.txtPoids.Text != "" && this.txtTaille.Text != "")
            {
                poids = double.Parse(txtPoids.Text);
                taille = double.Parse(txtTaille.Text);
                this.taille = this.taille / 100;
                resultat = (poids / (taille * taille));
                this.txtBlockImc.Text = this.resultat.ToString("00.00");
            }
        }
        //Calcul cardio
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            int resulecs;
            if (rbF.IsChecked == true || rbM.IsChecked == true)//Gère si homme ou femme est coché
            {
                if (rbTabacNon.IsChecked == true || rbTabacOui.IsChecked == true)//Gère si le patient est fumeur ou non
                {
                    if (txtAge.Text.Length > 0 && (int.Parse(txtAge.Text.ToString()) > 40 && int.Parse(txtAge.Text.ToString()) <= 65))//Gère si le patient est dans l'âge requis
                    {
                        if (txtTension.Text.Length > 0 && (int.Parse(txtTension.Text.ToString()) > 0))//Gère si le patient a une tension existante
                        {
                            if (txtChol.Text.Length > 0 && (int.Parse(txtChol.Text.ToString()) > 0))//Gère si le patient a un taux de cholestérol
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
                                resulecs = ecs.calculateScoreCVD(sexe, fumeur, int.Parse(txtAge.Text.ToString()), int.Parse(txtTension.Text.ToString()), int.Parse(txtChol.Text.ToString()));
                                if (resulecs >= 0)
                                {
                                    txtResCardio.Text = resulecs.ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Problème avec le cholestérol du patient (Ultra sportif ou va mourrir)");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Problème avec la tension du patient (Stone ou mort?)");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le patient n'est pas dans la limite d'âge (40-65 ans)");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez renseigner si le patient est fumeur ou non");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Veuillez renseigner si le patient est un homme ou une femme");
                return;
            }
        }
    }
}