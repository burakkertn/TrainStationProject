using TrainStationProject.Abstract;
using TrainStationProject.Concrete.Repository;
using TrainStationProject.Models.Context;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Concrete.EntityFramework
{
	public class EfUserDal : GenericRepository<User>, IUserDal
	{
		public User GetUserByName(string Username)
		{

			using var c = new StationContext();
			return c.Set<User>().FirstOrDefault(x => x.Username == Username);

		}
	}
}
