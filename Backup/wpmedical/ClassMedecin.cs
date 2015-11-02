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
        public string id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public classMedecin() { }
        public override string ToString()
        {
            return this.prenom + " " + this.nom;
        }
    }
}
