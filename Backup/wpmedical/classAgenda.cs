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
    public class classAgenda
    {
        public int idMedecin { get; set; }
        public int idPatient { get; set; }
        public string dateprevue { get; set; }
        public string datedebut { get; set; }
        public string datefin { get; set; }
        public string urgence { get; set; }
        public string libelle { get; set; }

        public classAgenda() {}
        public override string ToString()
        {
            return (dateprevue);
        }
    }
}
