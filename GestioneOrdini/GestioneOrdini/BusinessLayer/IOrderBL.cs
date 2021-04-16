using GestioneOrdini.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.BusinessLayer
{
    //scrivo i metodi che voglio che siano visibili all'utente nella webapp
    public interface IOrderBL
    {
        //CRUD di Clinet
        bool CreateClient(Client client);
        bool DeleteClient(int id);
        bool UpdateClient(Client client, int id );
        Client GetClient(int id);

        //CRUD di Order
        bool CreateOrder(Order order);
        bool DeleteOrder(int id);
        bool UpdateOrder(Order order, int id);
        Order GetOrder(int id);
    }
}
