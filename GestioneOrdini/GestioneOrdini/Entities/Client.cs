using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GestioneOrdini.Entities
{
    [DataContract]
    public class Client
    {
        //propretietà
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ClientCode { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        public ICollection<Order> ClientOrders { get; set; } = new List<Order>();
    }
}
