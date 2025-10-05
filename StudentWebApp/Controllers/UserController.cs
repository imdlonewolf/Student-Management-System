using DAL.Model;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using StudentWebApp.Models;

namespace StudentWebApp.Controllers
{
    public class UserController : Controller
    {
        IRepository _repository;
        public UserController(IRepository repository) {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SingUp(UserModel model)
        {
            User user = new User();
            user.EmailId = model.EmailId;
            user.Password = model.Password;
            bool x=_repository.AddUser(user);
            if (x)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("SingUp");
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {
            User user=_repository.ValidateUser(userModel.EmailId,userModel.Password);
            if (user == null)
            {
                ViewData["Msg"] = "Email Id or Password is incorrect";
                return View("Login");
            }
            HttpContext.Session.SetString("EmailId",user.EmailId);
            return RedirectToAction("Index", "Student");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
