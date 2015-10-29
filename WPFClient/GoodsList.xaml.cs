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
using System.Configuration;
using System.Data;
using System.Data.Common;

using GUI.WCFStoreServiceManager ;
using DataManager.Abstract;
using DataManager.Concrete;
using DataManager.DMModel;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            List<Good> goods = new List<Good>();

            WCFStoreServiceManager.StoreServiceClient client = new StoreServiceClient();
            goods = client.Goods().ToList<Good>();
            //WCFClient wcfc = new WCFClient();
            //goods = wcfc.Goods().ToList<Good>();

            dg_goods.ItemsSource = goods;
        }


        private void b_Add_Click(object sender, RoutedEventArgs e)
        {
            CreateEdit CEWindow = new CreateEdit();
            CEWindow.IsEdit = EWStatus.Create;
            CEWindow.ShowDialog();
        }

        private void b_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (dg_goods.SelectedItems.Count == 0) {
                MessageBox.Show("Позиция не выбрана", "Внимание!"); 
                return; 
            }

            Good item = (Good)dg_goods.SelectedValue;

            CreateEdit CEWindow = new CreateEdit();
            CEWindow.IsEdit = EWStatus.Edit;
            CEWindow.GoodToEdit = item;

            CEWindow.ShowDialog();
        }

        private void b_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dg_goods.SelectedItems.Count == 0)
            {
                MessageBox.Show("Позиция не выбрана", "Внимание!");
                return;
            }

            Good item = (Good)dg_goods.SelectedValue;

            WCFStoreServiceManager.StoreServiceClient client = new StoreServiceClient();
            client.DeleteGood(item);
            //WCFClient wcfc = new WCFClient();
            //wcfc.DeleteGood(item);

            MessageBox.Show("Позиция удалена", "Внимание!");

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            List<Good> goods = new List<Good>();

            WCFStoreServiceManager.StoreServiceClient client = new StoreServiceClient();
            goods = client.Goods().ToList<Good>();
            //WCFClient wcfc = new WCFClient();
//goods = wcfc.Goods().ToList<Good>();


            dg_goods.ItemsSource = goods;
        }

    }
}
