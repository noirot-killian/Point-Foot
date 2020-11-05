using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            gridPremiereCo.Visibility = Visibility.Hidden;
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {

            menuItemRecruteur.Visibility = Visibility.Collapsed;
            menuItemEntraineur.Visibility = Visibility.Collapsed;
            menuItemJoueur.Visibility = Visibility.Collapsed;
            lblCache.Visibility = Visibility.Visible;
            
           
             this.p = AdoProfil.unProfil(tbxPseudo.Text, pbxMdp.Password);
            { 
                if (p != null && p.PremiereCo == 1)
                {
                    lblNom.Visibility = Visibility.Visible;
                    lblNom.Content = "Bienvenue" + " " + p.Nom +" " + p.Prenom;
     
                    menu.Visibility = Visibility.Visible;
                    gridConnexion.Visibility = Visibility.Hidden;



                    foreach (Role r in p.Roles)
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
                else if (p !=null && p.PremiereCo == 0)
                {
                    gridConnexion.Visibility = Visibility.Hidden;
                    gridPremiereCo.Visibility = Visibility.Visible;
                    
                }
                else
                {
                    MessageBox.Show("Pseudo ou mot de passe incorrect");
                }
        
            
}


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            testFrame.Visibility = Visibility.Visible;
            testFrame.Content = new PageAdmin();
            lblNom.Visibility = Visibility.Hidden;
            

        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            testFrame.Visibility = Visibility.Visible;
            testFrame.Content = new PageEducateur();
            lblNom.Visibility = Visibility.Hidden;

        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            testFrame.Visibility = Visibility.Visible;
            testFrame.Content = new PageJoueur();
            lblNom.Visibility = Visibility.Hidden;

        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            testFrame.Visibility = Visibility.Visible;
            testFrame.Content = new VoirJoueur();
            lblNom.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            testFrame.Visibility = Visibility.Collapsed;
            menu.Visibility = Visibility.Collapsed;
            gridConnexion.Visibility = Visibility.Visible;
            imgBackground.Visibility = Visibility.Visible;
            lblCache.Visibility = Visibility.Hidden;
            lblNom.Visibility = Visibility.Hidden;
            p = null;
            tbxPseudo.Text = "";
            pbxMdp.Password = "";
            tbxPseudo.Focus();
            gridPremiereCo.Visibility = Visibility.Hidden;
        }

        private void gridConnexion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnConnexion_Click(null, null);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            AdoProfil.update(tbxNewMdp.Text, this.p.IdProfil );
            if(tbxNewMdp.Text != tbxConfirmationMdp.Text)
            {
                MessageBox.Show("Erreur, les mots de passse sont différents");
            }
            AdoProfil.updatePremiereCo(1, this.p.IdProfil);

            
            

        }
    }
}
