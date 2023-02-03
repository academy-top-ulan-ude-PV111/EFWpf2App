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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFWpf2App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext context = new AppContext();
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            context.Companies.Include(c => c.Country).Load();
            this.DataContext = context.Companies.Local.ToObservableCollection();
        }

        void Create_Click(object sender, RoutedEventArgs e)
        {
            CompanyWindow companyWindow = new CompanyWindow(new Company());
            if (companyWindow.ShowDialog() == true)
            {
                Company company = companyWindow.Company;
                context.Companies.Add(company);
                context.SaveChanges();
            }
        }
    }
}
