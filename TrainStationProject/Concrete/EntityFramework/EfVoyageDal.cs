using Microsoft.EntityFrameworkCore;
using TrainStationProject.Abstract;
using TrainStationProject.Concrete.Repository;
using TrainStationProject.Models.Context;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Concrete.EntityFramework
{
    public class EfVoyageDal : GenericRepository<Voyage>, IVoyageDal
    {

     
    }
}