using GestioneOrdini.Entities;
using GestioneOrdini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneOrdini.EF.EFRepository
{
    //implemento le operazioni CRUD dell'interfaccia IRepositoryOrder
    public class RepositoryOrderEF : IRepositoryOrder
    {
        //context
        private readonly GestioneOrdiniContext ctx;
        public RepositoryOrderEF() : this(new GestioneOrdiniContext()) { }
        public RepositoryOrderEF(GestioneOrdiniContext context)
        {
            this.ctx = context;
        }

        //CRUD
        public bool Create(Order item)
        {
            try
            {
                //controllo che non sia nullo
                if (item == null)
                {
                    return false;
                }
                //lo aggiungo
                ctx.Orders.Add(item);

                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                //se non esiste ritorno false
                if (ctx.Orders.Find(id) == null)
                {
                    return false;
                }
                //altrimenti lo recupero
                var order = ctx.Orders.Find(id);

                //lo cancello
                ctx.Orders.Remove(order);

                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Order GetById(int id)
        {
            try
            {
                //controllo che l'id sia valido
                if (id < 0)
                {
                    return null;
                }
                //restituisco
                return ctx.Orders.FirstOrDefault(c => c.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Order item, int id)
        {
            try
            {
                //controllo non sia nullo e che esista
                if (item == null || ctx.Orders.Find(item.ID) == null)
                {
                    return false;
                }
                //trovo il vecchio 
                var order = ctx.Orders.Find(id);

                //lo cambio
                order.Amount = item.Amount;
                order.OrderCode = item.OrderCode;
                order.OrderDate = item.OrderDate;
                order.ProductCode = item.ProductCode;

                //lo aggiorno
                ctx.Orders.Update(order);

                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
