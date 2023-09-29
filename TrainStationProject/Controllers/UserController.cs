using Microsoft.AspNetCore.Mvc;
using TrainStationProject.Abstract;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserDal _userDal;

		public UserController(IUserDal userDal)
		{
			_userDal = userDal;
		}
		public IActionResult Index()
		{
			var values = _userDal.GetListAll();
			return View(values);
		}
		public IActionResult DeleteUser(int id)
		{
			var values = _userDal.GetById(id);
			_userDal.Delete(values);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateUser(int id)
		{
			var values = _userDal.GetById(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateUser(User user)
		{
			_userDal.Update(user);
			return RedirectToAction("Index");
		}
	}
}
