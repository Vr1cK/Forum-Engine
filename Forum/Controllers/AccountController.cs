using Forum.Users;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult RegisterPost(User user)
        {
            if (ModelState.IsValid)
            {
                // Здесь можно сохранить пользователя в базу данных или выполнить другие действия, связанные с регистрацией.

                // Пример сохранения пользователя:
                // dbContext.Users.Add(user);
                // dbContext.SaveChanges();

                return RedirectToAction("Login", "Account"); // Перенаправление на страницу входа после успешной регистрации.
            }

            return View(user); // Если модель не валидна, вернуть пользователя на страницу регистрации с сообщениями об ошибках.
        }
    }
}
