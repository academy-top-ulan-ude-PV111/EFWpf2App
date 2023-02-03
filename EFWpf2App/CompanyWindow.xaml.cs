using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace EFWpf2App
{
    /// <summary>
    /// Логика взаимодействия для CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        public Company Company { set; get; }

        AppContext context = new AppContext();
        public CompanyWindow(Company company)
        {
            InitializeComponent();

            this.Loaded += CompanyWindow_Loaded;

            Company = company;
            this.DataContext = Company;
        }

        void CompanyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            context.Countries.Load();
            var countries = context.Countries.ToList();
            countriesList.ItemsSource = countries;
        }

        private void CountySave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
