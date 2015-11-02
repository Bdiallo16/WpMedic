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
    //identifiant du patient, les getteurs et les setteurs pour obtenir et définir l'id du patient
    public class classPatient
    {
       //nom du patient
        public string nomPatient { get; set; }
        //adresse du patient
        public string adressePatient { get; set; }
        //identifiant patient
        public int idPatient {get; set;}
        public string telephone { get; set; }
        public string prenom { get; set; }
        public string codepostal { get; set; }
        public string ville { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string datenaissance { get; set; }
        public string sexe { get; set; }
    }
}

