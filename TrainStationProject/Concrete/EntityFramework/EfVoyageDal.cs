using Microsoft.EntityFrameworkCore;
using TrainStationProject.Abstract;
using TrainStationProject.Concrete.Repository;
using TrainStationProject.Models.Context;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Concrete.EntityFramework
{
    public class EfVoyageDal : GenericRepository<Voyage>, IVoyageDal
    {
        public List<Voyage> GetStationsWithVoyage()
        {
            using var context = new StationContext();
            return context.Voyages.Include(x => x.Station).ToList();
        }
    }
}
