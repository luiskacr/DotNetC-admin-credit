using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class StateDALImpl : IStatesDAL
    {
        proyectoCreditosContext context;

        public StateDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(State entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<State> unidad = new UnidadDeTrabajo<State>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public State Get(int stateId)
        {
            try
            {
                State state;
                using (UnidadDeTrabajo<State> unidad = new UnidadDeTrabajo<State>(context))
                {
                    state = unidad.genericDAL.Get(stateId);
                }
                return state;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<State> GetAll()
        {
            try
            {
                IEnumerable<State> states;
                using (UnidadDeTrabajo<State> unidad = new UnidadDeTrabajo<State>(context))
                {
                    states = unidad.genericDAL.GetAll();
                }
                return states.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(State entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<State> unidad = new UnidadDeTrabajo<State>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool Update(State entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<State> unidad = new UnidadDeTrabajo<State>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }

        //Other Opctions Not Used

        public void AddRange(IEnumerable<State> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<State> Find(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<State> entities)
        {
            throw new NotImplementedException();
        }

        public State SingleOrDefault(Expression<Func<State, bool>> predicate)
        {
            throw new NotImplementedException();
        }

    }
}
