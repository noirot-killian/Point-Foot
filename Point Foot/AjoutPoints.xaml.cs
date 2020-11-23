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
        List<Action> actions;
        public AjoutPoints()
        {
            InitializeComponent();
            this.profils = AdoProfil.All();
            cbxListeJoueurs.ItemsSource = null;
            cbxListeJoueurs.ItemsSource = this.profils;


            this.actions = AdoAction.All();
            cbxListeActions.ItemsSource = null;
            cbxListeActions.ItemsSource = this.actions;
        }

        private void cbxListeJoueurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxListeJoueurs.SelectedIndex != -1)
            {
                Profil p = (Profil)(cbxListeJoueurs.SelectedItem);
                lblNbPoints.Content = Convert.ToString(p.Score);
            }
        }

        private void cbxListeActions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxListeActions.SelectedIndex != -1)
            {
                Action a = (Action)(cbxListeActions.SelectedItem);
                tbxBareme.Text = Convert.ToString(a.Bareme);
            }
        }
    }
}
