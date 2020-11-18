using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Point_Foot
{
    /// <summary>
    /// Logique d'interaction pour VoirJoueur.xaml
    /// </summary>
    public partial class VoirJoueur : Page
    {
        public VoirJoueur()
        {
            InitializeComponent();
            dgVoirJoueur.ItemsSource = AdoProfil.All();
        }

        private void dgVoirJoueur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Profil p = (Profil)(dgVoirJoueur.CurrentItem);
        }
    }
}
