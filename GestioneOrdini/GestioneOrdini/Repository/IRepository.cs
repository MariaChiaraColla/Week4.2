using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.Repository
{
    public interface IRepository<T>
    {
        //CRUD
        bool Create(T item);
        T GetById(int id);
        bool Update(T item, int id);
        bool Delete(int id);        
    }
}
