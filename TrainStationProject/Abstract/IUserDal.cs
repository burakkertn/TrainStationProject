using TrainStationProject.Models.Context;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
		public User GetUserByName(string Username);

	}
}
