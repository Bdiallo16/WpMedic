using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace wpmedical
{
    public class classMedecin
    {
        //identiant du medecin et les getteurs et setteurs
        public string id { get; set; }
        //nom du medecin
        public string nom { get; set; }
        //prenom du medecin
        public string prenom { get; set; }
        //login pour s'dentifier
        public string login { get; set; }
        //mot de passe
        public string password { get; set; }

        public classMedecin() { }
        //fonctiion qui retourne le prénom et le nom
        public override string ToString()
        {
            return this.prenom + " " + this.nom;
        }
    }
}
