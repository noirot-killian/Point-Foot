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
    /// Logique d'interaction pour AjoutPoints.xaml
    /// </summary>
    public partial class AjoutPoints : Page
    {
        List<Profil> profils;
        public AjoutPoints()
        {
            InitializeComponent();
            this.profils = AdoProfil.All();
            cbxListeJoueurs.ItemsSource = null;
            cbxListeJoueurs.ItemsSource = this.profils;
        }

        private void cbxListeJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxListeJoueurs.SelectedIndex != -1)
            {
                // comme pour le datagrid on récupère le fighter sélectionné
                Profil p = (Profil)(cbxListeJoueurs.SelectedItem);
            }
        }
    }
}
