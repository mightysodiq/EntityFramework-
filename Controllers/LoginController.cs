using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Hotel.Repositories.User_Repository;
using Hotel.Models;

namespace Hotel.Controllers;

public class LoginController : Controller
{

    private readonly IUserRepository _userRepository;

    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }



    public IActionResult LoginPage()
    {
        ViewBag.Message = TempData["Message"]?.ToString();
        return View();
    }




    [HttpPost]
    public IActionResult LoginPage(LoginModel loginModel)
    {

        if (ModelState.IsValid)
        {
            // Retrieve the user's input
            string? email = loginModel.Email;
            string? password = loginModel.Password;


            var UserExist = _userRepository.GetUserByEmailAndPassword(email, password);

            if (UserExist != null)
            {
                string loggedInUserId = UserExist.Id.ToString();
                HttpContext.Session.SetString("loggedIn_UserId", loggedInUserId);
                TempData["Message"] = "Login Successful";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Invalid credentials, display an error message
                TempData["ErrorMessage"] = "Invalid Sign in Credentials.";
                return View(loginModel);
            }
        }
        else
        {
            // If the model state is not valid or the login is unsuccessful,
            // return the view with validation errors or error message
            TempData["ErrorMessage"] = "A problem occurred. Please check your input.";
            return View(loginModel);
        }
    }
}

