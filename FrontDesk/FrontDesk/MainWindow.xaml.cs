using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Web_app_customer;
using Web_app_customer.Models;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly Oblig4Context _context =
            new Oblig4Context();

        private CollectionViewSource roomViewSource;
        public MainWindow()
        {
        
            Trace.WriteLine("heiM");
            InitializeComponent();
            roomViewSource =
               (CollectionViewSource)FindResource(nameof(roomViewSource));



        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            Trace.WriteLine("heiW");
            _context.Database.EnsureCreated();

            // load the entities into EF Core
            _context.rooms.Load();

            // bind to the source
            roomViewSource.Source =
                _context.rooms.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            List<Room> rooms = _context.rooms.ToList();
            rooms.Count();
            Trace.WriteLine(sender.ToString());
            Trace.WriteLine(e.GetType().ToString());
            Trace.WriteLine("Antall romm " + rooms.Count());
            foreach (Room room in rooms)
            {
                Console.WriteLine(room);
            }


            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            roomsDataGrid.Items.Refresh();
            reservationsDataGrid.Items.Refresh();
            taskDataGrid.Items.Refresh();

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            _context.Dispose();
            base.OnClosing(e);
        }

        private void roomsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
