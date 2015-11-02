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
    public class classAntecedent
    {
        public int id { get; set; }
        public string libelle { get; set; }
        public int annee { get; set; }
        public string commentaire { get; set; }

        public classAntecedent(string libelleL, int anneeL, string commentaireL)
        {
            this.libelle = libelleL;
            this.annee = anneeL;
            this.commentaire = commentaireL;
        }

        public classAntecedent() { }

        public override string ToString()
        {
            return (this.libelle);
        }
    }
}