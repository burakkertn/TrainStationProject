using Microsoft.AspNetCore.Mvc;
using TrainStationProject.Abstract;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Controllers
{
	public class VoyageController : Controller
	{
		private readonly IVoyageDal _voyageDal;
		private readonly IStationDal _stationDal;

        public VoyageController(IVoyageDal voyageDal, IStationDal stationDal)
        {
            _voyageDal = voyageDal;
            _stationDal = stationDal;
        }

        public IActionResult Index()
		{
			var values = _voyageDal.GetListAll();
			return View(values);
		}
        [HttpGet]
        public IActionResult AddVoyage()

        {
            List<Station> StationList = _stationDal.GetListAll();
            ViewBag.StationList = StationList;
            return View();
        }
        [HttpPost]
        public IActionResult AddVoyage(Voyage voyage)
        {
            _voyageDal.Insert(voyage);
            return RedirectToAction("Index");

        }
        public IActionResult DeleteVoyage(int id)
		{
			var values = _voyageDal.GetById(id);
            _voyageDal.Delete(values);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateVoyage(int id)
		{
			var values = _voyageDal.GetById(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateVoyage(Voyage voyage)
		{
            _voyageDal.Update(voyage);
			return RedirectToAction("Index");
		}
	}
}
