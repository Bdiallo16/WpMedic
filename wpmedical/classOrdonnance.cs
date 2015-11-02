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
    public class classOrdonnance
    {
        public string medic { get; set; }
        public string idordo { get; set; }
        public int quantite { get; set; }
        public string formGalenique { get; set; }
        public string duree { get; set; }
        public string idpatient { get; set; }
        public string momentprise { get; set; }
        public string idmedecin { get; set; }


        public classOrdonnance() { }
        public classOrdonnance(string pidordo, int pquantite, string pformGalenique, string pduree, string pidpatient, string pmomentprise, string pidmedecin)
        {
            this.idordo = pidordo;
            this.quantite = pquantite;
            this.formGalenique = pformGalenique;
            this.formGalenique = pformGalenique;
            this.duree = pduree;
            this.idpatient = pidpatient;
            this.idmedecin = pidmedecin;
        }

        public override string  ToString()
        {
 	            return ( this.medic );
        }
    }
}

