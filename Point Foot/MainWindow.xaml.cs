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
        public MainWindow()
        {
            InitializeComponent();
            foreach (Control i in menu.Items)
            {
                i.Visibility = Visibility.Hidden;
            }
            menu.Visibility = Visibility.Hidden;
            lblIdentifiant.Visibility = Visibility.Hidden;
            lblMdp.Visibility = Visibility.Hidden;
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            Profil p = AdoProfil.unProfil(tbxPseudo.Text, pbxMdp.Password);
            if (p != null)
            {
                menu.Visibility = Visibility.Visible;
                gridConnection.Visibility = Visibility.Hidden;
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

        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            testFrame.Content = new PageEducateur();
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            testFrame.Content = new PageJoueur();

        }
    }
}
