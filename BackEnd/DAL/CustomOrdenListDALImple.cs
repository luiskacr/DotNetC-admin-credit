using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    internal class CustomOrdenListDALImple : ICustomOrdenListDAL
    {
        ProyectoCreditosContext context;

        public CustomOrdenListDALImple() {
            context = new ProyectoCreditosContext();
        }

        public bool Add(CustomOrderList entity)
        {
            try {
                using (UnidadDeTrabajo<CustomOrderList> unidad = new UnidadDeTrabajo<CustomOrderList>(context)) { 
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }catch (Exception ex) {
                return false; 
            }
        }

        public void AddRange(IEnumerable<CustomOrderList> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomOrderList> Find(Expression<Func<CustomOrderList, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CustomOrderList Get(int id)
        {
            try
            {
                CustomOrderList customOrderList;
                using (UnidadDeTrabajo<CustomOrderList> unidad = new UnidadDeTrabajo<CustomOrderList>(context)) {
                    customOrderList = unidad.genericDAL.Get(id);
                }
                return customOrderList;
            }
            catch (Exception ex) {
                throw;
            }
        }

        public IEnumerable<CustomOrderList> GetAll()
        {
            try
            {
                IEnumerable<CustomOrderList> customOrderLists;
                using (UnidadDeTrabajo<CustomOrderList> unidad = new UnidadDeTrabajo<CustomOrderList>(context)) { 
                    customOrderLists = unidad.genericDAL.GetAll();
                }
                return customOrderLists;
            }
            catch (Exception ex){
                throw;
            }
        }

        public bool Remove(CustomOrderList entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<CustomOrderList> unidad = new UnidadDeTrabajo<CustomOrderList>(context)) { 
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
                return result;
            }
            catch (Exception ex) {
                return result;
            }
        }

        public void RemoveRange(IEnumerable<CustomOrderList> entities)
        {
            throw new NotImplementedException();
        }

        public CustomOrderList SingleOrDefault(Expression<Func<CustomOrderList, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(CustomOrderList entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<CustomOrderList> unidad = new UnidadDeTrabajo<CustomOrderList>(context)) {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }
                return result;
            }
            catch (Exception ex) {
                return result;
            }
        }
    }
}
