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
using GUI.WCFStoreServiceManager;

using DataManager.DMModel;

namespace GUI
{
    /// <summary>
    /// Interaction logic for CreateEdit.xaml
    /// </summary>
    public partial class CreateEdit : Window
    {
        public EWStatus IsEdit { get; set; }
        public Good GoodToEdit { get; set; }
        public CreateEdit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (IsEdit) { 
                case EWStatus.Create:{
                    int Amount; 
                    try {
                        Amount = Convert.ToInt32(tb_Amount.Text);
                    }
                    catch(Exception ex){
                        MessageBox.Show("Amount value incorrect", "Attention!"); 
                        return;
                    }

                    Good item = new Good(0, tb_Title.Text.ToString(), Convert.ToDateTime(null), Amount);
                    //WCFStoreServiceManager.StoreServiceClient client = new StoreServiceClient();
                    //client.SaveGood(item);
                    WCFClient wcfc = new WCFClient();
                    wcfc.SaveGood(item);
                    this.Close();
                    break;
                }
                    
                

                case EWStatus.Edit:{
                    int Amount; 
                    try {
                        Amount = Convert.ToInt32(tb_Amount.Text);
                    }
                    catch(Exception ex){
                        MessageBox.Show("Amount value incorrect","Attention!"); 
                        return;
                    }

                    Good item = new Good(GoodToEdit.Id, tb_Title.Text.ToString(), Convert.ToDateTime(null), Amount);
                    //WCFStoreServiceManager.StoreServiceClient client = new StoreServiceClient();
                    //client.SaveGood(item);
                    WCFClient wcfc = new WCFClient();
                    wcfc.SaveGood(item);
                    this.Close();
                    break;
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            switch (IsEdit){
                case EWStatus.Edit:{
                    tb_Title.Text = GoodToEdit.Title;
                    tb_Amount.Text = GoodToEdit.Amount.ToString();
                    break;
                }
            }

        }
    }
}
