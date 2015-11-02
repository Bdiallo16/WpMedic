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
using System;

namespace wpmedical
{
    
    public partial class accueil : PhoneApplicationPage
    {
        public accueil()
        {
            InitializeComponent();
        }

        // gère l'évènemnt au clik du bouton Consultation .
       
        private void btnConsultation_click(object sender, GestureEventArgs e)
        {
            //redirection vers la page  gestionPatients
            NavigationService.Navigate(new Uri("/gestionPatients.xaml", UriKind.Relative));
        }

     
        // gère l'évènemnt au clik du bouton agenda .       
        
        private void btnAgenda_click(object sender, GestureEventArgs e)
        {
           //redirection vers la page agenda.xaml
            NavigationService.Navigate(new Uri("/agenda.xaml", UriKind.Relative));
        }
        // gère l'évènemnt au clik du bouton calcul IMC .
       
        private void btnCalcul_click(object sender, GestureEventArgs e)
        {
            //redirection vers la page calcul IMC
            NavigationService.Navigate(new Uri("/calculs.xaml", UriKind.Relative));
        }
        // gère l'évènemnt au clik du bouton messagerie 
        private void btnMessagerie_click(object sender, GestureEventArgs e)
        {
            //redirection vers la page messagerie (pas encore finie)
            NavigationService.Navigate(new Uri("/messagerie.xaml", UriKind.Relative));
        }
    }
}