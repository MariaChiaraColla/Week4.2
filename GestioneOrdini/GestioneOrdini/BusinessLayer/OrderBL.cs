using GestioneOrdini.Entities;
using GestioneOrdini.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.BusinessLayer
{
    //implementa i metodi dell'interfaccia IOrderBL, e crea un unico repository per entrambe le classi
    public class OrderBL : IOrderBL
    {
        //richiamo i repositori
        private readonly IRepositoryClient repoClient;
        private readonly IRepositoryOrder repoOrder;

        //creo un repository unico
        public OrderBL(IRepositoryClient repoClient, IRepositoryOrder repoOrder)
        {
            this.repoClient = repoClient;
            this.repoOrder = repoOrder;
        }


        //create
        public bool CreateClient(Client client)
        {
            return repoClient.Create(client);
        }

        public bool CreateOrder(Order order)
        {
            return repoOrder.Create(order);
        }


        //delete
        public bool DeleteClient(int id)
        {
            return repoClient.Delete(id);
        }

        public bool DeleteOrder(int id)
        {
            return repoOrder.Delete(id);
        }


        //get by id
        public Client GetClient(int id)
        {
            return repoClient.GetById(id);
        }

        public Order GetOrder(int id)
        {
            return repoOrder.GetById(id);
        }


        //update
        public bool UpdateClient(Client client, int id)
        {
            return repoClient.Update(client,id);
        }

        public bool UpdateOrder(Order order, int id)
        {
            return repoOrder.Update(order,id);
        }
    }
}
