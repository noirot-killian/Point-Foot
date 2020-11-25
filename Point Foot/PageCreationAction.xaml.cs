﻿using System;
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
    /// Logique d'interaction pour PageCreationAction.xaml
    /// </summary>
    public partial class PageCreationAction : Page
    {
        int jeune;
        public PageCreationAction()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbxJeune.IsChecked == true)
            {
                jeune = 1;
            }
            else if (cbxSenior.IsChecked == true)
            {
                jeune = 0;
            }
            else
            {
                Console.WriteLine("Veuillez choisir une case");
            }

            Action a = new Action(0, tbxNomAction.Text, Convert.ToInt32(tbxBareme.Text), jeune);
            AdoAction.createAction(a);
        }
    }
}
