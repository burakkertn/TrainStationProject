using Microsoft.AspNetCore.Mvc;
using TrainStationProject.Abstract;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationDal _stationDal;
        private readonly IVoyageDal _voyageDal;

        public StationController(IStationDal stationDal, IVoyageDal voyageDal)
        {
            _stationDal = stationDal;
            _voyageDal = voyageDal;
        }
        public IActionResult Index()
        {
            var values = _stationDal.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddStation()

        {

            return View();
        }
        [HttpPost]
        public IActionResult AddStation(Station station)
        {
            _stationDal.Insert(station);
            return RedirectToAction("Index");

        }
        public IActionResult DeleteStation(int id)
        {
            var value = _stationDal.GetById(id);

            var voyages = _voyageDal.GetListAll();
            foreach (var voyage in voyages)
            {
                if (voyage.DepartureStationId == id)
                {
                    _voyageDal.Delete(voyage);
                }
                if (voyage.ArrivalStationId == id)
                {
                    _voyageDal.Delete(voyage);
                }
            }

            _stationDal.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStation(int id)
        {
            var values = _stationDal.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateStation(Station station)
        {
            _stationDal.Update(station);
            return RedirectToAction("Index");
        }
    }
}
