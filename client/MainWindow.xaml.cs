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
using System.Net;
using System.Net.Sockets;
using client.ViewModels;
using System.Threading;
using client.Models;
using System.Data.Entity;
using System.Collections.ObjectModel;


namespace client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BaseContext _context;

        public MainWindow()
        {
            ConfigViewModel config = new ConfigViewModel(9944, true);
            Thread thread = new Thread(new ThreadStart(config.ListenerUDP));
            thread.Start();
            config.SendBroadcastUDP("test");
            InitializeComponent();

            _context = new BaseContext();
            _context.Options.Load();
            this.DataContext = _context.Options.Local.ToBindingList();

        }

    }
}
