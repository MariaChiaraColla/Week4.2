using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GestioneOrdini.Entities
{
    [DataContract]
    public class Order
    {
        //proprietà
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public string OrderCode { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        public Client Customer { get; set; }
        public int IDCustomer { get; set; }
    }
}
