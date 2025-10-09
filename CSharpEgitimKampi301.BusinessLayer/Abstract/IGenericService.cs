using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {//business layer with "T" in front of method name
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
        List<T> TGetAll();
        T TGetById(int id);
    }
}
