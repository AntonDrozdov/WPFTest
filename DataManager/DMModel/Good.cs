using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace DataManager.DMModel
{
    [DataContract] 
    public class Good
    {
        [DataMember] 
        public int Id { get; set; }

        [DataMember] 
        public string Title { get; set; }
        [DataMember] 
        public DateTime RegistrationDate { get; set; }
        [DataMember] 
        public int Amount { get; set; }

        public Good(int _Id, string _Title, DateTime _RegistrationDate, int _Amount) {
            Id = _Id;
            Title = _Title;
            RegistrationDate = _RegistrationDate;
            Amount = _Amount;
        }
    }
}
