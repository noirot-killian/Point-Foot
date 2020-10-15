using System;
using System.Windows;
using System.Windows.Controls;

namespace Point_Foot
{
    /// <summary>
    /// Logique d'interaction pour PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        Random random = new Random();
        public PageAdmin()
        {
            InitializeComponent();
        }


        private void btnCréer_Click(object sender, RoutedEventArgs e)
        {
            Profil p = new Profil(0, tbxNom.Text, tbxPrenom.Text, tbxMail.Text, tbxPseudo.Text, Convert.ToDateTime(tbxDateNaiss.Text), Convert.ToInt32(tbxScore.Text), tbxNumLicence.Text);
            // on ajoute le nouveau profil en base de données
            AdoProfil.create(p);

            MessageBox.Show("Le mot de passe est", p.getMdp());
        }
    }
}
