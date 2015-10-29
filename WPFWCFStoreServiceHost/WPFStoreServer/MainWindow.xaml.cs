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
using System.ServiceModel;

namespace WPFStoreServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost service = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void b_Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (service == null)
                {
                    service = new ServiceHost(typeof(WCFStoreSErviceLib.StoreService));
                    service.Open();
                    tb_messages.Text += "Server started..." + DateTime.Now + Environment.NewLine;
                    foreach (System.ServiceModel.Description.ServiceEndpoint se in service.Description.Endpoints)
                    {
                        tb_messages.Text += se.Binding + Environment.NewLine;
                        tb_messages.Text += se.Address + Environment.NewLine;
                        tb_messages.Text += se.Contract.Name + Environment.NewLine;

                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void b_Stop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (service != null)
                {
                    service.Close();
                    service = null;
                    tb_messages.Text += "Server stoped" + DateTime.Now + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
