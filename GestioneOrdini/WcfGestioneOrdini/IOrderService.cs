using GestioneOrdini.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfGestioneOrdini
{
    //qui scrivo tutte le operzioni (servizi) che l'utente potrà usare
    [ServiceContract]
    public interface IOrderService
    {
        //Client
        [OperationContract]
        bool CreateClient(Client client);
        [OperationContract]
        bool DeleteClient(int id);
        [OperationContract]
        bool UpdateClient(Client client, int id);
        [OperationContract]
        string GetClientById(int id);

        //Order
        [OperationContract]
        bool CreateOrder(Order order, int idClient);
        [OperationContract]
        bool DeleteOrder(int id);
        [OperationContract]
        bool UpdateOrder(Order order, int id);
        [OperationContract]
        string GetOrderById(int id);
    }
}
