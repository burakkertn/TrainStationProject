using Microsoft.AspNetCore.Mvc;
using TrainStationProject.Abstract;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Controllers
{
	public class StationController : Controller
	{
		private readonly IStationDal _stationDal;

		public StationController(IStationDal stationDal)
		{
			_stationDal = stationDal;
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
			var values = _stationDal.GetById(id);
            _stationDal.Delete(values);
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
