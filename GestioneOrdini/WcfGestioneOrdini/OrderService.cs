using GestioneOrdini.EF.EFRepository;
using GestioneOrdini.Entities;
using GestioneOrdini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfGestioneOrdini
{
    //implemeto le funzioni dell'interfaccia IOrderService richiamando i metodi nel Repository EF
    public class OrderService : IOrderService
    {
        //Repository
        IRepositoryClient repositoryClient = new RepositoryClientEF();
        IRepositoryOrder repositoryOrder = new RepositoryOrderEF();


        //Create
        public bool CreateClient(Client client)
        {
            return repositoryClient.Create(client);
        }

        public bool CreateOrder(Order order, int idClient)
        {
            var ok = repositoryClient.GetById(idClient);
            if(ok == null)
            {
                return false;
            }
            order.IDCustomer = idClient;
            return repositoryOrder.Create(order);
        }


        //Delete
        public bool DeleteClient(int id)
        {
            return repositoryClient.Delete(id);
        }

        public bool DeleteOrder(int id)
        {
            return repositoryOrder.Delete(id);
        }


        //get by id
        public string GetClientById(int id)
        {
            var client = repositoryClient.GetById(id);
            if(client == null)
            {
                return "Cliente non trovato";
            }
            return $"{client.ClientCode}) {client.FirstName} {client.LastName}";
        }

        public string GetOrderById(int id)
        {
            var order = repositoryOrder.GetById(id);
            if(order == null)
            {
                return "Ordine non trovato";
            }
            if(order.Customer == null)
            {
                return $"{order.OrderCode}) Del prodotto {order.OrderCode}, in data {order.OrderDate}, con importo {order.Amount} euro";
            }
            return $"{order.OrderCode}) Del prodotto {order.OrderCode}, in data {order.OrderDate}, con importo {order.Amount} euro, al cliente: {order.Customer.FirstName} {order.Customer.LastName}";
        }


        //update
        public bool UpdateClient(Client client, int id)
        {
            return repositoryClient.Update(client, id);
        }

        public bool UpdateOrder(Order order, int id)
        {
            return repositoryOrder.Update(order, id);
        }
    }
}
