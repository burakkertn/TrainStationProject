using TrainStationProject.Abstract;
using TrainStationProject.Concrete.Repository;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Concrete.EntityFramework
{
	public class EfStationDal : GenericRepository<Station>, IStationDal
	{
	
	}
}
