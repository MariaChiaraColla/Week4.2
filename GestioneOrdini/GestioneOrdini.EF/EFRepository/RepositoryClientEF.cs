using GestioneOrdini.Entities;
using GestioneOrdini.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneOrdini.EF.EFRepository
{
    //implemento le operazioni dell'interfaccia IRepositoryClient
    public class RepositoryClientEF : IRepositoryClient
    {
        //context
        private readonly GestioneOrdiniContext ctx;
        public RepositoryClientEF() : this(new GestioneOrdiniContext()) { }
        public RepositoryClientEF(GestioneOrdiniContext context)
        {
            this.ctx = context;
        }

        //CRUD
        public bool Create(Client item)
        {
            try
            {
                //controllo che non sia nullo
                if(item == null)
                {
                    return false;
                }
                //lo aggiungo
                ctx.Clients.Add(item);

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
                //se non esiste un client con quell'id ritorno false
                if(ctx.Clients.Find(id) == null)
                {
                    return false;
                }
                //altrimenti recupero il client con quell'id
                var client = ctx.Clients.Find(id);

                //lo cancello
                ctx.Clients.Remove(client);

                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Client GetById(int id)
        {
            try
            {
                //controllo che l'id passato sia valido
                if (id < 0)
                {
                    return null;
                }
                //restituisco il clinet con quell'id o se non esiste un nullo
                return ctx.Clients.FirstOrDefault(c => c.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Client item, int id)
        {
            try
            {
                //controllo non sia nullo e che esista
                if(item == null || ctx.Clients.Find(item.ID) == null)
                {
                    return false;
                }

                var client = ctx.Clients.Find(id);

                //lo aggiorno
                client.ClientCode = item.ClientCode;
                client.FirstName = item.FirstName;
                client.LastName = item.LastName;

                //lo aggiorno
                ctx.Clients.Update(client);

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
