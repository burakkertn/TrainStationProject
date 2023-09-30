using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using TrainStationProject.Abstract;
using TrainStationProject.Models.Context;

namespace TrainStationProject.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new StationContext();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new StationContext();
            return c.Set<T>().Find(id);
        }
                      
        public List<T> GetListAll()
        {
            using var c = new StationContext();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new StationContext();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new StationContext();
            c.Update(t);
            c.SaveChanges();
        }
    }
}