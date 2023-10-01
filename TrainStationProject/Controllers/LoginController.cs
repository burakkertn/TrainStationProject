using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainStationProject.Abstract;
using TrainStationProject.Concrete.EntityFramework;
using TrainStationProject.Models;
using TrainStationProject.Models.Entites;

namespace TrainStationProject.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUserDal _userDal;

		public LoginController(IUserDal userDal)
		{
			_userDal = userDal;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(RegisterViewModel p)
		{
			User user = new User()
			{


				Username = p.Username,
				Password = p.Password


			};
			_userDal.Insert(user);
			return RedirectToAction("SignIn", "Login");
		}
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(LoginViewModel p)
		{
			if (ModelState.IsValid)
			{

				var value = _userDal.GetUserByName(p.Username);
				if (value != null)
				{
					if (value.Password == p.Password)
					{

					return	RedirectToAction("Index", "Voyage");
					}
					ViewBag.Error = "Şifre Hatalı";
					return View();
				}
				ViewBag.Error = "Böyle Bir Kullanıcı Yoktur!";

			}
			return View();
		}
	}
}