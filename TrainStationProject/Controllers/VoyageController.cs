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
			TempData["Stations"] = _stationDal.GetListAll();
            return View(values);
		}
        [HttpGet]
        public IActionResult AddVoyage()

        {
            ICollection<Station> StationList = _stationDal.GetListAll();
			ViewBag.StationList = StationList;
            //TEMPDATA Y
			return View();
        }
        [HttpPost]
        public IActionResult AddVoyage(Voyage voyage)
        {
            if (voyage.ArrivalStationId == voyage.DepartureStationId)
			{
				ViewBag.Error = "Kalkış İstasyonuyla Varış İstasyonu Aynı Olamaz.";
                ICollection<Station> StationList = _stationDal.GetListAll();
                ViewBag.StationList = StationList;
                return View();
			}
			if (voyage.DepartureTime > voyage.ArrivalTime)
			{
                ViewBag.Error = "Kalkış Zamanı Varış Zamanından Sonra Olamaz.";
                ICollection<Station> StationList = _stationDal.GetListAll();
                ViewBag.StationList = StationList;
                return View();
            }
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
            ICollection<Station> StationList = _stationDal.GetListAll();
            ViewBag.StationList = StationList;
            var value = _voyageDal.GetById(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateVoyage(Voyage voyage)
        {
            if (voyage.ArrivalStationId == voyage.DepartureStationId)
            {
                ViewBag.Error = "Kalkış İstasyonuyla Varış İstasyonu Aynı Olamaz.";
                ICollection<Station> StationList = _stationDal.GetListAll();
                ViewBag.StationList = StationList;
                return View(voyage);
            }
            if (voyage.DepartureTime > voyage.ArrivalTime)
            {
                ViewBag.Error = "Kalkış Zamanı Varış Zamanından Sonra Olamaz.";
                ICollection<Station> StationList = _stationDal.GetListAll();
                ViewBag.StationList = StationList;
                return View(voyage);
            }

            _voyageDal.Update(voyage);
			return RedirectToAction("Index");
		}
	}
}
