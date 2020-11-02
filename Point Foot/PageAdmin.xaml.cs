using Org.BouncyCastle.Asn1.X509;
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
    /// Logique d'interaction pour PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        Random random = new Random();
        List<Role> roles;
        public PageAdmin()
        {
            InitializeComponent();
            this.roles = AdoRole.All();
            l.ItemsSource = null;
            l.ItemsSource = this.roles;
        }
       
        

        private void btnCréer_Click(object sender, RoutedEventArgs e)
        {
            
            Profil p = new Profil(0, tbxNom.Text, tbxPrenom.Text, tbxMail.Text, tbxPseudo.Text, Convert.ToDateTime(tbxDateNaiss.Text), Convert.ToInt32(tbxScore.Text), tbxNumLicence.Text, 0);
            // on ajoute le nouveau profil en base de données
           p= AdoProfil.create(p);
            
            System.Collections.IList roles = l.SelectedItems;
            foreach (Role role in roles)
            {
                AdoProfil.createProfil(p, role);
            }

   
            MessageBox.Show("Le mot de passe est" + " " + p.Mdp);
        }

        

       

        
    }
}
