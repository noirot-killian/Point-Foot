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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Profil p;
        List<Profil> profils;
        public MainWindow()
        {

            InitializeComponent();
            foreach (Control i in menu.Items)
            {
                i.Visibility = Visibility.Hidden;
            }
            menu.Visibility = Visibility.Hidden;
            imgBackground.Visibility = Visibility.Visible;
            tbxPseudo.Focus();
            lblCache.Visibility = Visibility.Hidden;
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {

            menuItemRecruteur.Visibility = Visibility.Collapsed;
            menuItemEntraineur.Visibility = Visibility.Collapsed;
            menuItemJoueur.Visibility = Visibility.Collapsed;
            lblCache.Visibility = Visibility.Visible;


            Profil p = AdoProfil.unProfil(tbxPseudo.Text, pbxMdp.Password);
            if (p != null)
            {
                lblNom.Content = "Bienvenue" + " " + p.getNom() + " " + p.getPrenom();
                menu.Visibility = Visibility.Visible;
                gridConnexion.Visibility = Visibility.Hidden;

                foreach (Role r in p.getRoles())
                {
                    if (r.getLibelle().Equals("Admin"))
                    {

                        menuItemRecruteur.Visibility = Visibility.Visible;
                    }
                    if (r.getLibelle().Equals("Educateur"))
                    {

                        menuItemEntraineur.Visibility = Visibility.Visible;
                    }
                    if (r.getLibelle().Equals("Joueur"))
                    {

                        menuItemJoueur.Visibility = Visibility.Visible;
                    }

                }
            }
            else
            {
                MessageBox.Show("Pseudo ou mot de passe incorrect");

            }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            testFrame.Content = new PageAdmin();
            lblNom.Visibility = Visibility.Hidden;

        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            testFrame.Content = new PageEducateur();
            lblNom.Visibility = Visibility.Hidden;

        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            testFrame.Content = new PageJoueur();
            lblNom.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            testFrame.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Collapsed;
            gridConnexion.Visibility = Visibility.Visible;
            imgBackground.Visibility = Visibility.Visible;
            p = null;
            tbxPseudo.Text = "";
            pbxMdp.Password = "";
            tbxPseudo.Focus();
        }

        private void gridConnexion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnConnexion_Click(null, null);
            }
        }

        
    }
}
