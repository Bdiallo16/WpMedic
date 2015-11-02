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
    public class classConsultation
    {
        public int id { get; set; }
        public string dateconsultation { get; set; }
        public string libelle { get; set; }
        public int motif { get; set; }
        public int poids { get; set; }
        public int taille { get; set; }
        public int imc { get; set; }
        public int tas { get; set; }
        public int tad { get; set; }
        public string detail { get; set; }
        public string devenir { get; set; }
        public int idmedecin { get; set; }

          public classConsultation( int id,string dateconsultation, string libelle, int motif, int poids, int taille,
                                   int imc, int tas, int tad, string detail, string devenir, int idmedecin)
            {
              this.id = id;
              this.dateconsultation = dateconsultation;        
              this.libelle = libelle ;
              this.motif = motif;
              this.poids = poids;
              this.taille = taille;
              this.imc = imc;
              this.tas = tas;
              this.tad = tad;
              this.detail = detail;
              this.devenir = devenir;
              this.idmedecin = idmedecin; 
           }
           public classConsultation() { }

           public override string ToString()
           {
               return ("Le : " + dateconsultation + " pour : "+ libelle );
           }
    }
}
