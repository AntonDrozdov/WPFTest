using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using WCFStoreSErviceLib;
using DataManager.DMModel;

namespace GUI
{
    public class WCFClient
    {
        private Uri address;
        private BasicHttpBinding binding; 
        private EndpointAddress endpoint;
        private IStoreService chanel;
        private ChannelFactory<IStoreService> client;

        public WCFClient() {
            address = new Uri("http://127.0.0.1:5000/IStoreService");
            binding = new BasicHttpBinding();
            endpoint = new EndpointAddress(address);

            client = new ChannelFactory<IStoreService>(binding, endpoint);
            IStoreService chanel = client.CreateChannel();
        }

        public IEnumerable<Good> Goods() {
            List<Good> goods = new List<Good>();
            goods= chanel.Goods().ToList<Good>();
            return goods;
        }

        public Good GetGood(int Id) {
            return chanel.GetGood(Id);
        }

        public void SaveGood(Good item) {
            chanel.SaveGood(item);
        }

        public void DeleteGood(Good item) {
            chanel.DeleteGood(item);
        }


    }
}
