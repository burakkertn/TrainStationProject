using TrainStationProject.Models.Entites;

namespace TrainStationProject.Abstract
{
    public interface IVoyageDal : IGenericDal<Voyage>
    {
        public List<Voyage> GetStationsWithVoyage();
    }
}
