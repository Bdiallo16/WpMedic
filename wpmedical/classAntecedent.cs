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
    //Classe Antécedent
    public class classAntecedent
    {
        //id un entier représentant l'identifiant du patient  
        public int id { get; set; }
        //libelle chaine de caractère représentant le libellé 
        public string libelle { get; set; }
        //anne entier représentant l'année
        public int annee { get; set; }
        //commentaire chaine de caractère représentant le commentaire
        public string commentaire { get; set; }
        //constructeur
        public classAntecedent(string libelleL, int anneeL, string commentaireL)
        {
            this.libelle = libelleL;
            this.annee = anneeL;
            this.commentaire = commentaireL;
        }

        public classAntecedent() { }
      
        //fonction qui retourne le libellé sous forme d'une chaine de caractère
        public override string ToString()
        {
            return (this.libelle);
        }
    }
}