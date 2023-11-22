using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionExam.Context;
using SessionExam.Dtos;
using SessionExam.Models;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SessionExam.Controllers
{
    public class LoginController : AController
    {
		private readonly DataContext _dataContext;
		public LoginController(DataContext dataContext)
		{
			this._dataContext = dataContext;
		}

		//sayfayı kullanıcıya gösteriyor
		[HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            if(userDto is null)
                return RedirectToAction(nameof(Login));

			if (ModelState.IsValid == false)
				return View(userDto);

            var kullanici = await _dataContext.Users.FirstOrDefaultAsync(t => t.Username == userDto.Username && t.Password == userDto.Password);

			if (kullanici == null)
			{
				ModelState.AddModelError(nameof(userDto.Password), "Kullanıcı kodu veya şifre hatalı");
				return View(userDto);
			}

			//Session: Projede her yerde okuyabileceğimiz bir değişken oluşturduk -> Session lar object data taşır. Tür bağımsızdır.
			string userJson = JsonSerializer.Serialize<User>(kullanici);
			HttpContext.Session.SetString("user", userJson);

			//ClaimData ile de veri taşınabilir.

			return RedirectToAction(nameof(Index), "Home");
        }

		public IActionResult Logout()
		{
			HttpContext.Session.Remove("user");
			//HttpContent.Session.SetString("user", null);

			return RedirectToAction(nameof(Login));
		}
    }
}
