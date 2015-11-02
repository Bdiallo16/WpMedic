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

        private void btnConsultation_click(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/gestionPatients.xaml", UriKind.Relative));
        }

        private void btnAgenda_click(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/agenda.xaml", UriKind.Relative));
        }

        private void btnCalcul_click(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/calculs.xaml", UriKind.Relative));
        }

        private void btnMessagerie_click(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/messagerie.xaml", UriKind.Relative));
        }
    }
}